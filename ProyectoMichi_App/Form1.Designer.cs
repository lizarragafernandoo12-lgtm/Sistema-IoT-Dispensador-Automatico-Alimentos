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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPrueba);
            Controls.Add(txtShow);
            Controls.Add(checkBox);
            Name = "Form1";
            Text = "Form1";
           
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox;
        private TextBox txtShow;
        private TextBox txtPrueba;
    }
}
