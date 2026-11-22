using System.IO.Ports;
namespace ProyectoMichi_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           puerto.DataReceived += Puerto_DataReceived;
            InitializeComponent();
             }
       public class Receptor
        {
            public bool esValida = false;
            public  string com;
            public string num;
            public string mensaje;

            public void decifrarTrama()
            {
                esValida = false;
                 string buffer = "";
                bool write = false;

                foreach (char letter in mensaje)
                {
                    if (letter == '<')
                    {
                        write = true;
                    }
                    else if (letter == '>')
                    {
                        write = false;
                    }
                    else if (write == true)
                    {
                        buffer = buffer + letter;
                    }
                }
                int pos0 = buffer.IndexOf(';');
                int pos1 = buffer.IndexOf('*');
                if (pos0 == -1 || pos1 == -1)
                {
                    return;
                }

                 com = buffer.Substring(0, pos0);
                       num = buffer.Substring(pos0 + 1 , pos1 - (pos0 + 1));
                    string chk0 = buffer.Substring(pos1 + 1);
                
                    int chk1 = 0;
                    string body0 = com + ";" + num;
                    foreach (char digit in body0)
                    {
                        chk1 = chk1 ^ digit;
                    }
                    string hexa = chk1.ToString("x");
                    if (hexa.Length == 1)
                    {
                        hexa = "0" + hexa;
                    }
                if (hexa == chk0)
                {
                    esValida = true;
                }
            }

        }
             private void Puerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(() =>
            {
                try
                {
                    string massenenger = puerto.ReadLine();
                    txtShow.AppendText(massenenger + Environment.NewLine);
                    tramita.mensaje = massenenger;
                    tramita.decifrarTrama();
                    if (tramita.esValida == true)
                    {
                        txtPrueba.AppendText(tramita.com + Environment.NewLine);
                        txtPrueba.AppendText(tramita.num + Environment.NewLine);
                    }
                }
                catch (Exception) {
                    txtShow.Text = "Tiempo de espera agotado";
                    }
            });
        }

        SerialPort puerto = new SerialPort("COM7" , 9600);
        Receptor tramita = new Receptor();
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox.Checked)
                {
                    puerto.Open();
                }
                else
                {
                    puerto.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Revisa tus conexiones");
            }
        }

       
    }
}
