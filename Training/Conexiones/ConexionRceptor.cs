class Receptor
{

    public bool decifrarTrama(string trama)
    {   
        string buffer = "";
        bool write = false;
       
        
        foreach(char letter in trama)
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
            
            return false;
        }
        if (pos1 == -1)
        {
           
            return false;
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
        {   return true;
            
        } else{
            return false;
        }
    }
         
    }