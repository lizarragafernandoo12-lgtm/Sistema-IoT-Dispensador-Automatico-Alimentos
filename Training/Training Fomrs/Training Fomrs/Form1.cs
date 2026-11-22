namespace Training_Fomrs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
                int second = int.Parse(lblTiempo.Text) + 1;
                lblTiempo.Text = second.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {

            lblTiempo.Text = "0";
        }
    }
}
