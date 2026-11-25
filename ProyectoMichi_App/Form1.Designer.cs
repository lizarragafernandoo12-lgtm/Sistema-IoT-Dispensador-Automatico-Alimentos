namespace ProyectoMichi_App
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
            checkBox = new CheckBox();
            lblPlato = new Label();
            lblDeposito = new Label();
            lblAct = new Label();
            btnDispe = new Button();
            SuspendLayout();
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Location = new Point(295, 12);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(130, 19);
            checkBox.TabIndex = 0;
            checkBox.Text = "Encender bluetooth";
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // lblPlato
            // 
            lblPlato.AutoSize = true;
            lblPlato.Location = new Point(198, 88);
            lblPlato.Name = "lblPlato";
            lblPlato.Size = new Size(14, 15);
            lblPlato.TabIndex = 4;
            lblPlato.Text = "P";
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(489, 88);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(15, 15);
            lblDeposito.TabIndex = 5;
            lblDeposito.Text = "D";
            // 
            // lblAct
            // 
            lblAct.AutoSize = true;
            lblAct.Location = new Point(335, 261);
            lblAct.Name = "lblAct";
            lblAct.Size = new Size(25, 15);
            lblAct.TabIndex = 6;
            lblAct.Text = "Act";
            // 
            // btnDispe
            // 
            btnDispe.Location = new Point(310, 153);
            btnDispe.Name = "btnDispe";
            btnDispe.Size = new Size(75, 23);
            btnDispe.TabIndex = 7;
            btnDispe.Text = "Dispensar ";
            btnDispe.UseVisualStyleBackColor = true;
            btnDispe.Click += btnDispe_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDispe);
            Controls.Add(lblAct);
            Controls.Add(lblDeposito);
            Controls.Add(lblPlato);
            Controls.Add(checkBox);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox;
        private Label lblPlato;
        private Label lblDeposito;
        private Label lblAct;
        private Button btnDispe;
    }
}
