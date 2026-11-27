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
            chartPlato.Location = new Point(20, 25);
            chartPlato.Size = new Size(200, 200);

            ChartArea area = new ChartArea();
            chartPlato.ChartAreas.Add(area);

            Series serie = new Series();
            serie.ChartType = SeriesChartType.Doughnut;
            serie["DoughnutRadius"] = "30";
            serie.Points.AddY(450);   // valor de prueba (lleno)
            serie.Points.AddY(550);   // valor de prueba (vacío, hasta llegar a 1000)
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
                    string massenenger = puerto.ReadLine();
                    tramita.mensaje = massenenger;
                    tramita.decifrarTrama();
                    if (tramita.esValida == true)
                    {
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

        private void hopeRoundButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
