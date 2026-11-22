Mensaje newMensaje = new Mensaje();
newMensaje.comando = "SERVIR";
newMensaje.datos = "1";
string trama = newMensaje.calcularCheckSum();
Console.WriteLine(trama);

class Mensaje
{
    public string comando;
    public string datos;
    
    public string calcularCheckSum()
    {
      string cuerpo = comando + ";" + datos;
      int checksum = 0;

    foreach (char digit in cuerpo)
        {
            checksum = checksum ^ digit;
        }
        string hex = checksum.ToString("X");
            if(hex.Length == 1)
            {
                hex = "0" + hex;
            }
            string information = "<" + cuerpo + "*" + hex + ">";
            return information;
    }
}