        using System.IO.Ports;
        namespace ProyectoMichi_App
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                    puerto.DataReceived += Puerto_DataReceived;   
                }
                public class Receptor
                {
                    public bool esValida = false;
                    public string com;
                    public string num;
                    public string mensaje;
                    public string numPlato;
                    public string numDep;
                    public string numEvento;
                    public string numServo;
                    public string depAlerta;
                    public string down;
                    public string numManual;
                public string chk0;

            public bool evaluarPos(int a)
                    {
                        if (a != -1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    public bool evaluarPos(int a, int b)
                    {
                        if (b != -1 && a != -1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }


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
                if (evaluarPos(pos0, pos1))
                {
                     chk0 = buffer.Substring(pos1 + 1);
                    com = buffer.Substring(0, pos0);
                    num = buffer.Substring(pos0 + 1, pos1 - (pos0 + 1));
                }
                    else
                    { return; }
                        int chk1 = 0;
                        string body0 = com + ";" + num;
                        foreach (char digit in body0)
                        {
                            chk1 = chk1 ^ digit;
                        }
                        string hexa = chk1.ToString("x");
                    switch (com)
                    {
                        case "ESTADO":
                            int pos2 = num.IndexOf(';');
                            if (evaluarPos(pos2))
                            {
                                numPlato = num.Substring(0, pos2);
                                numDep = num.Substring(pos2 + 1);
                            }
                            else { return; }
                            break;
                        case "EVENTO":
                            int pos3 = num.IndexOf(';');
                            int pos_ = num.IndexOf('_');
                            if (evaluarPos(pos3, pos_))
                            {
                                numEvento = num.Substring(0, pos_);
                                numManual = num.Substring(pos_ + 1, pos3 - (pos_ + 1));
                            }
                            else { return; }
                            break;
                        case "SERVO":
                            int pos4 = num.IndexOf(';');
                            if (evaluarPos(pos4))
                            {
                                numServo = num.Substring(0, pos4);
                            }
                            else { return; }
                            break;
                        case "ALERTA":
                            int pos5 = num.IndexOf('_');
                            if (evaluarPos(pos5))
                            {
                                depAlerta = num.Substring(0, pos5);
                                down = num.Substring(pos5 + 1);
                            } else { return; }
                            break;
                    }
                        if (chk0 == hexa)
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
                               switch (tramita.com)
                                {
                                    case "ESTADO":
                                        lblPlato.Text = tramita.numPlato;
                                        lblDeposito.Text = tramita.numDep;
                                        break;
                                    case "EVENTO":
                                        lblAct.Text = tramita.numEvento + ": " + tramita.numManual;
                                        break;
                                    case "SERVO":
                                        lblAct.Text = tramita.numServo;
                                        break;
                                    case "ALERTA":
                                        lblAct.Text = tramita.depAlerta + ": " + tramita.down;
                                        break;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            txtShow.Text = "Erros de procesamiento de datos";
                        }
                    });
                }
                SerialPort puerto = new SerialPort("COM7", 9600);
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
