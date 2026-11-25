
#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include <Servo.h>
#include <HX711.h>
#include <SoftwareSerial.h>

// --- ASIGNACIÓN DE PINES ---
const int pinBoton = 2;
const int Tdeposito = 4;
const int Edeposito = 5;
const int buzzer = 6;
const int dt = 7;
const int sck = 8;
const int pinServo = 9;

// --- OBJETOS ---
LiquidCrystal_I2C lcd(0x27, 16, 2);
Servo controlServo;
HX711 balanza;
// --- VARIABLES DE INTERRUPCIÓN (botón físico) ---
volatile bool eventoBotonManual = false;
volatile unsigned long ultimoTiempoBounce = 0;

// --- VARIABLES DE TIEMPO (millis) ---
unsigned long tiempoUltimoServido = 0;
unsigned long tiempoUltimaAlertaDeposito = 0;
unsigned long tiempoInicioServir = 0;
unsigned long tiempoUltimoReporteBT = 0;
bool sirviendoComida = false;

// --- Guardamos el último peso leído, para no tener que esperar
//     a que la báscula tenga un dato listo cada vez que lo necesitamos ---
float ultimoPesoLeido = 0.0;

// --- LÍMITES Y REGLAS FIJAS ---
const unsigned long INTERVALO_COMIDA = 30000;
const unsigned long COOLDOWN_BUZZER = 5000; // NUEVO: no suena más de una vez cada 5 seg,
                                             // aunque el sensor "parpadee" cerca del límite
const unsigned long DURACION_ABIERTO = 1000;
const unsigned long INTERVALO_TELEMETRIA = 2000;
const float UMBRAL_PLATO_LLENO = 3.0;

// --- BUFFER DE RECEPCIÓN BLUETOOTH ---
String bufferEntrante = "";
bool leyendoTrama = false;
const int LIMITE_BUFFER = 40;
// Calcula el "sello de seguridad" (checksum XOR) de un texto.
// Sirve para que la app sepa si el mensaje llegó completo y sin corromperse.
byte calcularChecksum(String cuerpo) {
  byte chk = 0;
  for (unsigned int i = 0; i < cuerpo.length(); i++) {
    chk ^= cuerpo[i];
  }
  return chk;
}

// Arma la trama completa y la manda por USB (debug) y por Bluetooth (app)
void enviarTrama(String comando, String datos) {
  String cuerpo = comando + ";" + datos;
  byte chk = calcularChecksum(cuerpo);
  String tramaCompleta = "<" + cuerpo + "*" + String(chk, HEX) + ">";

  Serial.println(tramaCompleta);
  Serial1.println(tramaCompleta);
}

// Revisa un comando recibido desde la app y decide qué hacer con él
void procesarTramaRecibida(String trama) {
  int posAsterisco = trama.lastIndexOf('*');
  if (posAsterisco == -1) return; // trama inválida, sin checksum, se ignora

  String cuerpo = trama.substring(0, posAsterisco);
  String hexRecibido = trama.substring(posAsterisco + 1);

  byte chkCalculado = calcularChecksum(cuerpo);
  byte chkRecibido = (byte) strtol(hexRecibido.c_str(), NULL, 16);

  // Si el sello no coincide, el mensaje llegó dañado: se avisa y se descarta
  if (chkCalculado != chkRecibido) {
    enviarTrama("NACK", "CHECKSUM_ERROR");
    return;
  }

  int posPuntoComa = cuerpo.indexOf(';');
  String comando = (posPuntoComa == -1) ? cuerpo : cuerpo.substring(0, posPuntoComa);
  String datos = (posPuntoComa == -1) ? "" : cuerpo.substring(posPuntoComa + 1);

  if (comando == "SERVIR") {
    // Si ya está sirviendo, no reiniciamos el servo, solo avisamos
    // que la orden no se repite.
    if (sirviendoComida) {
      enviarTrama("NACK", "YA_SIRVIENDO");
    } else {
      lcd.clear();
      lcd.print("Servido por App");
      iniciarServido();
      tone(buzzer, 800, 300);
      enviarTrama("ACK", "SERVIR_OK");
    }
  }
  else if (comando == "TARA") {
    balanza.tare();
    enviarTrama("ACK", "TARA_OK");
  }
  else if (comando == "STATUS") {
    // Usamos el último peso guardado, no pedimos una lectura nueva
    // aquí (eso podría tardar y bloquear el programa).
    float distDep = medirDistancia(Tdeposito, Edeposito);
    String dep = (distDep >= 25.0) ? "BAJO" : "OK";
    enviarTrama("ESTADO", "PLATO:" + String(ultimoPesoLeido, 0) + "g;DEP:" + dep);
  }
  else {
    enviarTrama("NACK", "COMANDO_DESCONOCIDO");
  }
}

// Lee los datos que van llegando por Bluetooth, caracter por caracter,
// armando el "sobre" entre '<' y '>' sin detener el resto del programa.
void escucharBluetooth() {
  while (Serial1.available() > 0) {
    char c = Serial1.read();

    if (c == '<') {
      bufferEntrante = "";
      leyendoTrama = true;
    }
    else if (c == '>') {
      if (leyendoTrama) {
        procesarTramaRecibida(bufferEntrante);
        leyendoTrama = false;
      }
    }
    else if (leyendoTrama) {
      bufferEntrante += c;
      if (bufferEntrante.length() > LIMITE_BUFFER) {
        leyendoTrama = false;
        bufferEntrante = "";
      }
    }
  }
}

void ISR_botonManual() {
  unsigned long tiempoActual = millis();
  if (tiempoActual - ultimoTiempoBounce > 200) { // antirrebote: ignora pulsos dobles
    eventoBotonManual = true;
    ultimoTiempoBounce = tiempoActual;
  }
}

void setup() {
  Serial.begin(9600);
  Serial1.begin(9600);

  pinMode(pinBoton, INPUT_PULLUP);
  attachInterrupt(digitalPinToInterrupt(pinBoton), ISR_botonManual, FALLING);

  pinMode(Tdeposito, OUTPUT);
  pinMode(Edeposito, INPUT);
  pinMode(buzzer, OUTPUT);

  controlServo.attach(pinServo);
  controlServo.write(0); // compuerta cerrada al iniciar

  lcd.init();
  lcd.backlight();
  lcd.setCursor(0, 0);
  lcd.print("Dispensador BT");
  lcd.setCursor(0, 1);
  lcd.print("Esperando App...");
  delay(1500); // Este delay sí está bien: solo ocurre UNA vez al encender,
               // no afecta el funcionamiento normal del sistema.
  lcd.clear();

  balanza.begin(dt, sck);
  balanza.set_scale(1043.3);
  balanza.tare();

  tiempoUltimoServido = millis();

  enviarTrama("INIT", "SISTEMA_OK;ACK");
}

void loop() {
  // --- Siempre escuchamos Bluetooth primero, pase lo que pase ---
  escucharBluetooth();
    unsigned long tiempoActual = millis();

  if (balanza.is_ready()) {
    float lectura = balanza.get_units(1);
    if (lectura < 0) lectura = 0.0;
    // Redondeamos a entero: el ruido eléctrico hace que los decimales
    // varíen todo el tiempo (ej. 123.4, 123.7, 122.9) sin que el peso
    // real esté cambiando. Entero es más estable y más fácil de leer.
    ultimoPesoLeido = round(lectura);
  }
  // Si el sensor no está listo todavía, simplemente seguimos usando
  // ultimoPesoLeido (el valor más reciente que sí alcanzamos a leer).

  // --- 1. GESTIÓN NO BLOQUEANTE DEL SERVO ---
  if (sirviendoComida) {
    if (tiempoActual - tiempoInicioServir >= DURACION_ABIERTO) {
      controlServo.write(0);
      sirviendoComida = false;
      enviarTrama("SERVO", "CERRADO;ACK");
    }
    return; // mientras sirve, no hacemos nada más en esta vuelta del loop
  }

  // --- LECTURA DEL SENSOR ULTRASÓNICO DEL DEPÓSITO ---
  float distanciaDeposito = medirDistancia(Tdeposito, Edeposito);
  bool depositoBajo = (distanciaDeposito >= 22.0);

  // --- 2. BOTÓN MANUAL (atendido aquí, la interrupción solo avisó) ---
  if (eventoBotonManual) {
    eventoBotonManual = false;
    lcd.clear();
    lcd.print("Sirviendo manual");
    iniciarServido();
    tone(buzzer, 800, 300);
    enviarTrama("EVENTO", "BOTON_MANUAL;ACK");
    return;
  }

  // --- 3. ALERTA DE DEPÓSITO BAJO ---
  // CORREGIDO: ya no se reinicia tiempoUltimaAlertaDeposito a 0 cuando el
  // sensor deja de marcar "bajo" por un instante (ruido/movimiento). Eso
  // causaba que sonara sin parar si la distancia andaba justo en el límite.
  // Ahora simplemente exige que pasen al menos COOLDOWN_BUZZER (5 seg)
  // desde el último sonido, sin importar los parpadeos de en medio.
  if (depositoBajo) {
    if (tiempoActual - tiempoUltimaAlertaDeposito >= COOLDOWN_BUZZER) {
      tone(buzzer, 900, 400);
      tiempoUltimaAlertaDeposito = tiempoActual;
      enviarTrama("ALERTA", "DEPOSITO_BAJO");
    }
  }

  // --- 4. DISPENSAR AUTOMÁTICO CADA 30 SEGUNDOS SI EL PLATO ESTÁ VACÍO ---
  if (tiempoActual - tiempoUltimoServido >= INTERVALO_COMIDA) {
    if (ultimoPesoLeido < UMBRAL_PLATO_LLENO) {
      lcd.clear();
      lcd.print("Hora de comer!");
      iniciarServido();
      tone(buzzer, 1000, 500);
      enviarTrama("EVENTO", "AUTO_TIEMPO;ACK");
    }
    tiempoUltimoServido = millis();
  }

  // --- 5. PANTALLA LCD CON EL ESTADO DEL SISTEMA ---
  if (depositoBajo) {
    lcd.setCursor(0, 0);
    lcd.print("Alerta Deposito ");
  } else {
    lcd.setCursor(0, 0);
    lcd.print("Sistema Activo  ");
  }
    // El peso se muestra siempre en la segunda línea, haya o no alerta de
    // depósito: antes, la alerta tapaba por completo esta línea y parecía
    // que el conteo de la báscula se "reseteaba", cuando en realidad el
    // dato seguía intacto, solo dejaba de imprimirse.
  lcd.setCursor(0, 1);
  lcd.print("Plato: ");
  lcd.print(ultimoPesoLeido, 0);
  lcd.print("g   ");

  // --- 6. TELEMETRÍA CADA 2 SEGUNDOS HACIA LA APP ---
  if (tiempoActual - tiempoUltimoReporteBT >= INTERVALO_TELEMETRIA) {
    String estadoDep = depositoBajo ? "BAJO" : "OK";
    String datos = "PLATO:" + String(ultimoPesoLeido, 0) + "g;DEP:" + estadoDep;
    enviarTrama("ESTADO", datos);
    tiempoUltimoReporteBT = tiempoActual;
  }
}
// Abre la compuerta (servo) y arranca el cronómetro para cerrarla después,
// sin bloquear el programa mientras tanto.
void iniciarServido() {
  controlServo.write(50);
  tiempoInicioServir = millis();
  sirviendoComida = true;
}

// Mide la distancia del sensor ultrasónico del depósito.
// Manda un pulso y mide cuánto tarda en regresar el eco.
float medirDistancia(int trigPin, int echoPin) {
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);

  long duracion = pulseIn(echoPin, HIGH, 25000); // espera máx 25ms por el eco

  float distancia = duracion * 0.034 / 2;
  return distancia;
}
