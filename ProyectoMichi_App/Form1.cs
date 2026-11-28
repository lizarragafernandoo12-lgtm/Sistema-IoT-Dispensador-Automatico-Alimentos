using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Ports;

namespace ProyectoMichi_App
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            chartPlato = new Chart();
            chartPlato.Location = new Point(50, 30);
            chartPlato.Size = new Size(175, 175);

            ChartArea area = new ChartArea();
            chartPlato.ChartAreas.Add(area);

            Series serie = new Series();
            serie.ChartType = SeriesChartType.Doughnut;
            serie["DoughnutRadius"] = "30";
            chartPlato.Series.Add(serie);
            materialCard2.Controls.Add(chartPlato);
            puerto.DataReceived += Puerto_DataReceived;
        }
        public class Checksum
        {
            public string comChecksum = "SERVIR";
            public string numChecksum = "1";

            public string armarChecksum(string comChecksum, string numChecksum)
            {
                int chk = 0;
                string body = comChecksum + ";" + numChecksum;
                foreach (char digit in body)
                {
                    chk = chk ^ digit;
                }
                string hex = chk.ToString("x");
                string trama = "<" + body + "*" + hex + ">";
                return trama;
            }
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
            public int gramitos;
            public string depEstado;
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
                            int posP = numPlato.IndexOf(':');
                            int posG = numPlato.IndexOf('g');
                            gramitos = int.Parse(numPlato.Substring(posP + 1, posG - (posP + 1)));
                            int posD = numDep.IndexOf(':');
                            depEstado = numDep.Substring(posD + 1);


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
                        }
                        else { return; }
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
                    picAdv.Visible = false;
                    string massenenger = puerto.ReadLine();
                    tramita.mensaje = massenenger;
                    tramita.decifrarTrama();
                    if (tramita.esValida == true)
                    {
                        switch (tramita.com)
                        {
                            case "ESTADO":

                                chartPlato.Series[0].Points.Clear();
                                chartPlato.Series[0].Points.AddY(tramita.gramitos);
                                chartPlato.Series[0].Points.AddY(1000 - tramita.gramitos);
                                chartPlato.Series[0].Points[0].Color = Color.DeepSkyBlue;
                                chartPlato.Series[0].Points[1].Color = Color.LightGray;
                                lblPlato.Text = tramita.gramitos.ToString();
                                lblDeposito.Text = tramita.depEstado;
                                lblAlimento.Text = "Nivel de alimento: " + tramita.depEstado;
                                if (tramita.depEstado == "BAJO")
                                {

                                    lblDeposito.ForeColor = Color.FromArgb(255, 255, 20);
                                    picAdv.Visible = true;

                                }
                                else
                                {
                                    lblDeposito.ForeColor = Color.FromArgb(64, 64, 64);
                                    picAdv.Visible = false;
                                }
                                break;
                            case "EVENTO":
                                if (tramita.numManual == "MANUAL")
                                {
                                   
                                    lblAct.Text = "Servido " + tramita.numManual;
                                }
                                else
                                {

                                    lblAct.Text = "Servido Automatico";
                                }
                                break;
                            case "SERVO":
                                lblAct.Text = "Compuerta: " + tramita.numServo;
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    lblAct.Text = "Error en transmisión de datos";
                }
            });
        }
        SerialPort puerto = new SerialPort("COM7", 9600);
        Receptor tramita = new Receptor();
        Checksum checkador = new Checksum();
        Chart chartPlato;
        private async void swBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (cambiandoEstado)
            {
                return;

            }
            swBlue.Enabled = false;
            this.UseWaitCursor = true;
            try
            {
                if (swBlue.Checked)
                {
                    await Task.Run(() => puerto.Open());
                    lblBlue.ForeColor = Color.FromArgb(0, 120, 215);
                }
                else if (puerto.IsOpen)
                {
                    puerto.Close();
                    lblBlue.ForeColor = Color.FromArgb(64, 64, 64);
                    picAdv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                cambiandoEstado = true;
                swBlue.Checked = false;
                cambiandoEstado = false;

                MessageBox.Show("Revisa tu conexión", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
                swBlue.Enabled = true;
            }

        }
        private bool cambiandoEstado = false;
        private void lblBlue_Click(object sender, EventArgs e)
        {
            swBlue.Checked = !swBlue.Checked;
        }

        private void picIcono_Click(object sender, EventArgs e)
        {
            swBlue.Checked = !swBlue.Checked;
        }

        private void bntDispe_Click(object sender, EventArgs e)
        {
            try
            {
                puerto.WriteLine(checkador.armarChecksum(checkador.comChecksum, checkador.numChecksum));
            }
            catch (Exception)
            {
                MessageBox.Show("Error al enviar comando", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    
    }
}