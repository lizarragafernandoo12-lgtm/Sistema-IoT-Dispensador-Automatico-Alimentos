PuertoSimulado newPuerto = new PuertoSimulado();


newPuerto.Enviar("");
newPuerto.Conectar();
newPuerto.Enviar( "" );

class PuertoSimulado
{
    public bool conectado = false;

    public void Conectar()
    {
        conectado = true;

        Console.WriteLine("Puerto conectado");
    }
    public void Enviar (string datos)
    {
        if(conectado == false)
        {
            Console.WriteLine("Error no hay conexion");
        }
        else
        {
            Console.WriteLine("Enviados : " + datos);
        }
    }
    

}
