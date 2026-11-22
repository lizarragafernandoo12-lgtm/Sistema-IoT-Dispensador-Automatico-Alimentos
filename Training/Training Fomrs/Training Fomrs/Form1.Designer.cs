namespace Training_Fomrs
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnIniciar = new Button();
            button2 = new Button();
            lblTiempo = new Label();
            timer = new System.Windows.Forms.Timer(components);
            btnClean = new Button();
            SuspendLayout();
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(238, 249);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(75, 23);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "Iniciar ";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(319, 249);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Detener";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Location = new Point(309, 220);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(13, 15);
            lblTiempo.TabIndex = 2;
            lblTiempo.Text = "0";
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // btnClean
            // 
            btnClean.Location = new Point(283, 287);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 3;
            btnClean.Text = "Reiniciar ";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 492);
            Controls.Add(btnClean);
            Controls.Add(lblTiempo);
            Controls.Add(button2);
            Controls.Add(btnIniciar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIniciar;
        private Button button2;
        private Label lblTiempo;
        private System.Windows.Forms.Timer timer;
        private Button btnClean;
    }
}
