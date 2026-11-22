
Receptor newReceptor = new Receptor();
newReceptor.mensaje = "<SERVIR;1*03>";
newReceptor.decifrarTrama();

class Receptor
{
    public string mensaje;

    public void decifrarTrama()
    {   
        string buffer = "";
        bool write = false;
       
        
        foreach(char letter in mensaje)
        {
            if (letter == '<')
            {
                write = true;
            }
             else if (letter == '>')
            {
                write = false;
            }
            else if(write == true)
            {
                buffer = buffer + letter;
            }
        }
        int pos0 = buffer.IndexOf(';');
        int pos1 = buffer.IndexOf('*');
        if (pos0 == -1)
        {
            Console.WriteLine("Trama corrompida");
            return;
        }
        if (pos1 == -1)
        {
            Console.WriteLine("Trama corrompida");
            return;
        }

        string com = buffer.Substring(0 , pos0);
        string num = buffer.Substring(pos0 + 1 , pos1 - (pos0 + 1));
        string chk0 = buffer.Substring(pos1 + 1);
       
       int chk1 = 0;
       string body = com + ";" + num;
       foreach(char digit in body)
        {
            chk1 = chk1 ^ digit;
        }
        string hexa = chk1.ToString("X");
        if (hexa.Length == 1)
        {
            hexa = "0" + hexa;
        }
        
        if (hexa == chk0)
        {
            Console.WriteLine("Mensaje Correcto!");
            
        } else{
            Console.WriteLine("Mensaje Corrompido");
        }
    }
         
    }
