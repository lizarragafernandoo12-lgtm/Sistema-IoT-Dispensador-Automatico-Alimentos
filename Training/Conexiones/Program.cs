Mensaje newMensaje = new Mensaje();
Receptor newReceptor = new Receptor();

bool esValido = newReceptor.decifrarTrama("<ACK;SERVIR_OK*20>");
bool esValido2 = newReceptor.decifrarTrama("<ACK;SERVIR_OK*FF>");
Console.WriteLine(esValido2);
Console.WriteLine(esValido);
newMensaje.comando = "SERVIR";
newMensaje.datos = "1";
string trama = newMensaje.calcularCheckSum();
PuertoSimulado newPuerto = new PuertoSimulado();

newPuerto.Enviar(trama);
newPuerto.Conectar();
newPuerto.Enviar(trama);