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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblDeposito = new Label();
            lblAct = new Label();
            swBlue = new ReaLTaiizor.Controls.HopeSwitch();
            picIcono = new PictureBox();
            lblBlue = new Label();
            materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            bntDispe = new ReaLTaiizor.Controls.ParrotButton();
            hopeRoundButton1 = new ReaLTaiizor.Controls.HopeRoundButton();
            materialCard2 = new ReaLTaiizor.Controls.MaterialCard();
            gramos = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            lblPlato = new Label();
            materialCard3 = new ReaLTaiizor.Controls.MaterialCard();
            pictureBox2 = new PictureBox();
            lblAlimento = new Label();
            picAdv = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picIcono).BeginInit();
            materialCard1.SuspendLayout();
            materialCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            materialCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAdv).BeginInit();
            SuspendLayout();
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            lblDeposito.Location = new Point(90, 66);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(164, 47);
            lblDeposito.TabIndex = 5;
            lblDeposito.Text = "Deposito";
            // 
            // lblAct
            // 
            lblAct.AutoSize = true;
            lblAct.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAct.Location = new Point(358, 423);
            lblAct.Name = "lblAct";
            lblAct.Size = new Size(65, 17);
            lblAct.TabIndex = 6;
            lblAct.Text = "Actividad ";
            // 
            // swBlue
            // 
            swBlue.AutoSize = true;
            swBlue.BackColor = Color.Transparent;
            swBlue.BaseColor = SystemColors.ButtonHighlight;
            swBlue.BaseOffColor = Color.Silver;
            swBlue.BaseOnColor = Color.FromArgb(0, 130, 252);
            swBlue.Location = new Point(6, 4);
            swBlue.Name = "swBlue";
            swBlue.Size = new Size(40, 20);
            swBlue.TabIndex = 7;
            swBlue.Text = "hopeSwitch1";
            swBlue.UseVisualStyleBackColor = false;
            swBlue.CheckedChanged += swBlue_CheckedChanged;
            // 
            // picIcono
            // 
            picIcono.BackColor = Color.Transparent;
            picIcono.Cursor = Cursors.Hand;
            picIcono.Image = (Image)resources.GetObject("picIcono.Image");
            picIcono.Location = new Point(195, 3);
            picIcono.Name = "picIcono";
            picIcono.Size = new Size(28, 21);
            picIcono.SizeMode = PictureBoxSizeMode.Zoom;
            picIcono.TabIndex = 8;
            picIcono.TabStop = false;
            picIcono.Click += picIcono_Click;
            // 
            // lblBlue
            // 
            lblBlue.AutoSize = true;
            lblBlue.BackColor = Color.Transparent;
            lblBlue.Cursor = Cursors.Hand;
            lblBlue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBlue.ForeColor = Color.FromArgb(64, 64, 64);
            lblBlue.Location = new Point(46, 1);
            lblBlue.Name = "lblBlue";
            lblBlue.Size = new Size(159, 21);
            lblBlue.TabIndex = 9;
            lblBlue.Text = "Encender Bluetooth ";
            lblBlue.Click += lblBlue_Click;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(swBlue);
            materialCard1.Controls.Add(picIcono);
            materialCard1.Controls.Add(lblBlue);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(286, 13);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(218, 28);
            materialCard1.TabIndex = 10;
            // 
            // bntDispe
            // 
            bntDispe.BackgroundColor = Color.DeepSkyBlue;
            bntDispe.ButtonImage = (Image)resources.GetObject("bntDispe.ButtonImage");
            bntDispe.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            bntDispe.ButtonText = "Dispensar             ";
            bntDispe.ClickBackColor = Color.CornflowerBlue;
            bntDispe.ClickTextColor = Color.Silver;
            bntDispe.CornerRadius = 25;
            bntDispe.Cursor = Cursors.Hand;
            bntDispe.Font = new Font("Segoe UI Emoji", 30F, FontStyle.Bold);
            bntDispe.Horizontal_Alignment = StringAlignment.Center;
            bntDispe.HoverBackgroundColor = Color.DodgerBlue;
            bntDispe.HoverTextColor = Color.FromArgb(224, 224, 224);
            bntDispe.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            bntDispe.Location = new Point(242, 337);
            bntDispe.Name = "bntDispe";
            bntDispe.Size = new Size(318, 72);
            bntDispe.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            bntDispe.TabIndex = 13;
            bntDispe.TextColor = Color.White;
            bntDispe.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            bntDispe.Vertical_Alignment = StringAlignment.Center;
            bntDispe.Click += bntDispe_Click;
            // 
            // hopeRoundButton1
            // 
            hopeRoundButton1.BorderColor = Color.FromArgb(210, 210, 210);
            hopeRoundButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeRoundButton1.DangerColor = Color.FromArgb(245, 108, 108);
            hopeRoundButton1.DefaultColor = Color.FromArgb(210, 210, 210);
            hopeRoundButton1.Font = new Font("Segoe UI", 12F);
            hopeRoundButton1.HoverTextColor = Color.FromArgb(48, 49, 51);
            hopeRoundButton1.InfoColor = Color.FromArgb(144, 147, 153);
            hopeRoundButton1.Location = new Point(242, 339);
            hopeRoundButton1.Name = "hopeRoundButton1";
            hopeRoundButton1.PrimaryColor = SystemColors.ScrollBar;
            hopeRoundButton1.Size = new Size(319, 74);
            hopeRoundButton1.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeRoundButton1.TabIndex = 14;
            hopeRoundButton1.TextColor = Color.White;
            hopeRoundButton1.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(gramos);
            materialCard2.Controls.Add(pictureBox1);
            materialCard2.Controls.Add(label2);
            materialCard2.Controls.Add(label1);
            materialCard2.Controls.Add(lblPlato);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(112, 69);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(273, 238);
            materialCard2.TabIndex = 15;
            // 
            // gramos
            // 
            gramos.AutoSize = true;
            gramos.Font = new Font("Segoe UI", 11F);
            gramos.Location = new Point(110, 127);
            gramos.Name = "gramos";
            gramos.Size = new Size(59, 20);
            gramos.TabIndex = 8;
            gramos.Text = "gramos";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(3, 93);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(56, 215);
            label2.Name = "label2";
            label2.Size = new Size(155, 21);
            label2.TabIndex = 6;
            label2.Text = "Peso Máximo 1000 g";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 14);
            label1.Name = "label1";
            label1.Size = new Size(147, 21);
            label1.TabIndex = 5;
            label1.Text = "Plato de Comida (g)";
            // 
            // lblPlato
            // 
            lblPlato.AutoSize = true;
            lblPlato.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold);
            lblPlato.Location = new Point(112, 92);
            lblPlato.Name = "lblPlato";
            lblPlato.Size = new Size(36, 32);
            lblPlato.TabIndex = 4;
            lblPlato.Text = " 0";
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Controls.Add(pictureBox2);
            materialCard3.Controls.Add(lblAlimento);
            materialCard3.Controls.Add(picAdv);
            materialCard3.Controls.Add(lblDeposito);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(430, 69);
            materialCard3.Margin = new Padding(14);
            materialCard3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(14);
            materialCard3.Size = new Size(275, 238);
            materialCard3.TabIndex = 16;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(14, 47);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(81, 135);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // lblAlimento
            // 
            lblAlimento.AutoSize = true;
            lblAlimento.Font = new Font("Segoe UI", 11F);
            lblAlimento.Location = new Point(95, 122);
            lblAlimento.Name = "lblAlimento";
            lblAlimento.Size = new Size(0, 20);
            lblAlimento.TabIndex = 7;
            // 
            // picAdv
            // 
            picAdv.Image = (Image)resources.GetObject("picAdv.Image");
            picAdv.Location = new Point(198, 81);
            picAdv.Name = "picAdv";
            picAdv.Size = new Size(29, 26);
            picAdv.SizeMode = PictureBoxSizeMode.Zoom;
            picAdv.TabIndex = 6;
            picAdv.TabStop = false;
            picAdv.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 449);
            Controls.Add(bntDispe);
            Controls.Add(lblAct);
            Controls.Add(materialCard1);
            Controls.Add(hopeRoundButton1);
            Controls.Add(materialCard3);
            Controls.Add(materialCard2);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)picIcono).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            materialCard3.ResumeLayout(false);
            materialCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAdv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblDeposito;
        private Label lblAct;
        private ReaLTaiizor.Controls.HopeSwitch swBlue;
        private PictureBox picIcono;
        private Label lblBlue;
        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.ParrotButton bntDispe;
        private ReaLTaiizor.Controls.HopeRoundButton hopeRoundButton1;
        private ReaLTaiizor.Controls.MaterialCard materialCard2;
        private ReaLTaiizor.Controls.MaterialCard materialCard3;
        private Label lblPlato;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Label gramos;
        private PictureBox picAdv;
        private Label lblAlimento;
        private PictureBox pictureBox2;
    }
}
