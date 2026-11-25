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
            txtShow = new TextBox();
            txtPrueba = new TextBox();
            lblPlato = new Label();
            lblDeposito = new Label();
            lblAct = new Label();
            SuspendLayout();
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Location = new Point(282, 12);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(130, 19);
            checkBox.TabIndex = 0;
            checkBox.Text = "Encender bluetooth";
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // txtShow
            // 
            txtShow.Location = new Point(155, 48);
            txtShow.Multiline = true;
            txtShow.Name = "txtShow";
            txtShow.Size = new Size(401, 61);
            txtShow.TabIndex = 1;
            // 
            // txtPrueba
            // 
            txtPrueba.Location = new Point(155, 136);
            txtPrueba.Multiline = true;
            txtPrueba.Name = "txtPrueba";
            txtPrueba.Size = new Size(401, 61);
            txtPrueba.TabIndex = 3;
            // 
            // lblPlato
            // 
            lblPlato.AutoSize = true;
            lblPlato.Location = new Point(222, 220);
            lblPlato.Name = "lblPlato";
            lblPlato.Size = new Size(14, 15);
            lblPlato.TabIndex = 4;
            lblPlato.Text = "P";
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(427, 220);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(15, 15);
            lblDeposito.TabIndex = 5;
            lblDeposito.Text = "D";
            // 
            // lblAct
            // 
            lblAct.AutoSize = true;
            lblAct.Location = new Point(324, 327);
            lblAct.Name = "lblAct";
            lblAct.Size = new Size(25, 15);
            lblAct.TabIndex = 6;
            lblAct.Text = "Act";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblAct);
            Controls.Add(lblDeposito);
            Controls.Add(lblPlato);
            Controls.Add(txtPrueba);
            Controls.Add(txtShow);
            Controls.Add(checkBox);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox;
        private TextBox txtShow;
        private TextBox txtPrueba;
        private Label lblPlato;
        private Label lblDeposito;
        private Label lblAct;
    }
}
