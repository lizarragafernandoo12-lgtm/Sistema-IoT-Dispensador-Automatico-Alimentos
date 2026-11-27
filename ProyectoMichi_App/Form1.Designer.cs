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
            lblPlato = new Label();
            materialCard3 = new ReaLTaiizor.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)picIcono).BeginInit();
            materialCard1.SuspendLayout();
            materialCard2.SuspendLayout();
            materialCard3.SuspendLayout();
            SuspendLayout();
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeposito.Location = new Point(70, 111);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(104, 25);
            lblDeposito.TabIndex = 5;
            lblDeposito.Text = "DEP: BAJO";
            // 
            // lblAct
            // 
            lblAct.AutoSize = true;
            lblAct.Location = new Point(85, 161);
            lblAct.Name = "lblAct";
            lblAct.Size = new Size(0, 15);
            lblAct.TabIndex = 6;
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
            bntDispe.Font = new Font("Segoe UI Emoji", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            hopeRoundButton1.Click += hopeRoundButton1_Click;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(lblPlato);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(147, 69);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(238, 238);
            materialCard2.TabIndex = 15;
            // 
            // lblPlato
            // 
            lblPlato.AutoSize = true;
            lblPlato.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlato.Location = new Point(73, 111);
            lblPlato.Name = "lblPlato";
            lblPlato.Size = new Size(93, 21);
            lblPlato.TabIndex = 4;
            lblPlato.Text = "PLATO: 0G";
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Controls.Add(lblDeposito);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(430, 69);
            materialCard3.Margin = new Padding(14);
            materialCard3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(14);
            materialCard3.Size = new Size(238, 238);
            materialCard3.TabIndex = 16;
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
            materialCard3.ResumeLayout(false);
            materialCard3.PerformLayout();
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
    }
}
