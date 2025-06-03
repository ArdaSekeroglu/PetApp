namespace PetApp
{
    partial class UserInfoUpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            kytIsimGir = new TextBox();
            kytSoyisimGir = new TextBox();
            kytKulAdiGir = new TextBox();
            kytEpostaGir = new TextBox();
            mevcutSifreTxt = new TextBox();
            kytTelNoGir = new MaskedTextBox();
            HataLabel = new Label();
            KaydetForKulDuzenle = new Button();
            KulResmiEkle = new PictureBox();
            İslemiİptalEt = new Button();
            yeniSifreTxt = new TextBox();
            yeniSifreTekrarTxt = new TextBox();
            HataLabel1 = new Label();
            sifreGoster = new Button();
            sifreGizle = new Button();
            SifreDegis = new Button();
            sifreVazgec = new Button();
            sifreKaydet = new Button();
            sifrepanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)KulResmiEkle).BeginInit();
            sifrepanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe Script", 9F);
            label1.ForeColor = Color.Gold;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(0, 75);
            label1.Name = "label1";
            label1.Size = new Size(105, 19);
            label1.TabIndex = 20;
            label1.Text = "Arkadaşım Pet";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 25);
            panel1.TabIndex = 21;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // kytIsimGir
            // 
            kytIsimGir.BackColor = Color.White;
            kytIsimGir.BorderStyle = BorderStyle.None;
            kytIsimGir.Cursor = Cursors.IBeam;
            kytIsimGir.ForeColor = Color.Black;
            kytIsimGir.Location = new Point(15, 285);
            kytIsimGir.Name = "kytIsimGir";
            kytIsimGir.PlaceholderText = "isim";
            kytIsimGir.Size = new Size(202, 16);
            kytIsimGir.TabIndex = 23;
            kytIsimGir.Tag = "";
            kytIsimGir.TextAlign = HorizontalAlignment.Center;
            kytIsimGir.KeyPress += kytIsimGir_KeyPress;
            // 
            // kytSoyisimGir
            // 
            kytSoyisimGir.BackColor = Color.White;
            kytSoyisimGir.BorderStyle = BorderStyle.None;
            kytSoyisimGir.Cursor = Cursors.IBeam;
            kytSoyisimGir.ForeColor = Color.Black;
            kytSoyisimGir.Location = new Point(285, 285);
            kytSoyisimGir.Name = "kytSoyisimGir";
            kytSoyisimGir.PlaceholderText = "soyad";
            kytSoyisimGir.Size = new Size(202, 16);
            kytSoyisimGir.TabIndex = 24;
            kytSoyisimGir.TextAlign = HorizontalAlignment.Center;
            kytSoyisimGir.KeyPress += kytSoyisimGir_KeyPress;
            // 
            // kytKulAdiGir
            // 
            kytKulAdiGir.BackColor = Color.White;
            kytKulAdiGir.BorderStyle = BorderStyle.None;
            kytKulAdiGir.Cursor = Cursors.IBeam;
            kytKulAdiGir.Location = new Point(15, 410);
            kytKulAdiGir.Name = "kytKulAdiGir";
            kytKulAdiGir.PlaceholderText = "kullanıcı adı";
            kytKulAdiGir.Size = new Size(202, 16);
            kytKulAdiGir.TabIndex = 25;
            kytKulAdiGir.TextAlign = HorizontalAlignment.Center;
            // 
            // kytEpostaGir
            // 
            kytEpostaGir.BackColor = Color.White;
            kytEpostaGir.BorderStyle = BorderStyle.None;
            kytEpostaGir.Cursor = Cursors.IBeam;
            kytEpostaGir.ForeColor = Color.Black;
            kytEpostaGir.Location = new Point(15, 535);
            kytEpostaGir.Name = "kytEpostaGir";
            kytEpostaGir.PlaceholderText = "ornek@mail.com";
            kytEpostaGir.Size = new Size(202, 16);
            kytEpostaGir.TabIndex = 26;
            kytEpostaGir.TextAlign = HorizontalAlignment.Center;
            kytEpostaGir.KeyPress += kytEpostaGir_KeyPress;
            // 
            // mevcutSifreTxt
            // 
            mevcutSifreTxt.BackColor = Color.White;
            mevcutSifreTxt.BorderStyle = BorderStyle.None;
            mevcutSifreTxt.Cursor = Cursors.IBeam;
            mevcutSifreTxt.Font = new Font("Segoe UI", 9F);
            mevcutSifreTxt.ForeColor = Color.Black;
            mevcutSifreTxt.Location = new Point(61, 0);
            mevcutSifreTxt.Name = "mevcutSifreTxt";
            mevcutSifreTxt.PlaceholderText = "mevcut şifre";
            mevcutSifreTxt.Size = new Size(202, 16);
            mevcutSifreTxt.TabIndex = 27;
            mevcutSifreTxt.TextAlign = HorizontalAlignment.Center;
            mevcutSifreTxt.UseSystemPasswordChar = true;
            // 
            // kytTelNoGir
            // 
            kytTelNoGir.BackColor = Color.White;
            kytTelNoGir.BorderStyle = BorderStyle.None;
            kytTelNoGir.Cursor = Cursors.IBeam;
            kytTelNoGir.Location = new Point(285, 535);
            kytTelNoGir.Mask = "(999) 000 0000";
            kytTelNoGir.Name = "kytTelNoGir";
            kytTelNoGir.RightToLeft = RightToLeft.No;
            kytTelNoGir.Size = new Size(202, 16);
            kytTelNoGir.TabIndex = 28;
            kytTelNoGir.TextAlign = HorizontalAlignment.Center;
            // 
            // HataLabel
            // 
            HataLabel.AutoSize = true;
            HataLabel.BackColor = Color.Transparent;
            HataLabel.Font = new Font("Bahnschrift Condensed", 11.25F);
            HataLabel.ForeColor = Color.Red;
            HataLabel.ImeMode = ImeMode.NoControl;
            HataLabel.Location = new Point(15, 555);
            HataLabel.Name = "HataLabel";
            HataLabel.Size = new Size(64, 18);
            HataLabel.TabIndex = 29;
            HataLabel.Text = "Hata Mesajı";
            HataLabel.Visible = false;
            // 
            // KaydetForKulDuzenle
            // 
            KaydetForKulDuzenle.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            KaydetForKulDuzenle.Cursor = Cursors.Hand;
            KaydetForKulDuzenle.FlatAppearance.BorderSize = 3;
            KaydetForKulDuzenle.FlatStyle = FlatStyle.Flat;
            KaydetForKulDuzenle.Font = new Font("Candara", 21.75F, FontStyle.Bold);
            KaydetForKulDuzenle.ForeColor = Color.White;
            KaydetForKulDuzenle.Location = new Point(443, 80);
            KaydetForKulDuzenle.Name = "KaydetForKulDuzenle";
            KaydetForKulDuzenle.Size = new Size(55, 80);
            KaydetForKulDuzenle.TabIndex = 31;
            KaydetForKulDuzenle.Text = "✓";
            KaydetForKulDuzenle.UseVisualStyleBackColor = true;
            KaydetForKulDuzenle.Click += KaydetForKulDuzenle_Click;
            // 
            // KulResmiEkle
            // 
            KulResmiEkle.BackColor = Color.Black;
            KulResmiEkle.BackgroundImage = Properties.Resources.AddPhotoIcon;
            KulResmiEkle.BackgroundImageLayout = ImageLayout.Stretch;
            KulResmiEkle.ImeMode = ImeMode.NoControl;
            KulResmiEkle.Location = new Point(165, 80);
            KulResmiEkle.Name = "KulResmiEkle";
            KulResmiEkle.Size = new Size(160, 160);
            KulResmiEkle.TabIndex = 32;
            KulResmiEkle.TabStop = false;
            KulResmiEkle.Click += KulResmiEkle_Click;
            // 
            // İslemiİptalEt
            // 
            İslemiİptalEt.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            İslemiİptalEt.Cursor = Cursors.Hand;
            İslemiİptalEt.FlatAppearance.BorderSize = 3;
            İslemiİptalEt.FlatStyle = FlatStyle.Flat;
            İslemiİptalEt.Font = new Font("Candara", 9.75F);
            İslemiİptalEt.ForeColor = Color.Red;
            İslemiİptalEt.Location = new Point(443, 166);
            İslemiİptalEt.Name = "İslemiİptalEt";
            İslemiİptalEt.Size = new Size(55, 80);
            İslemiİptalEt.TabIndex = 33;
            İslemiİptalEt.Text = "İşlemi İptal Et";
            İslemiİptalEt.UseVisualStyleBackColor = true;
            İslemiİptalEt.Click += İslemiİptalEt_Click;
            // 
            // yeniSifreTxt
            // 
            yeniSifreTxt.BackColor = Color.White;
            yeniSifreTxt.BorderStyle = BorderStyle.None;
            yeniSifreTxt.Cursor = Cursors.IBeam;
            yeniSifreTxt.Font = new Font("Segoe UI", 9F);
            yeniSifreTxt.ForeColor = Color.Black;
            yeniSifreTxt.Location = new Point(62, 32);
            yeniSifreTxt.Name = "yeniSifreTxt";
            yeniSifreTxt.PlaceholderText = "yeni şifre";
            yeniSifreTxt.Size = new Size(202, 16);
            yeniSifreTxt.TabIndex = 34;
            yeniSifreTxt.TextAlign = HorizontalAlignment.Center;
            yeniSifreTxt.UseSystemPasswordChar = true;
            // 
            // yeniSifreTekrarTxt
            // 
            yeniSifreTekrarTxt.BackColor = Color.White;
            yeniSifreTekrarTxt.BorderStyle = BorderStyle.None;
            yeniSifreTekrarTxt.Cursor = Cursors.IBeam;
            yeniSifreTekrarTxt.Font = new Font("Segoe UI", 9F);
            yeniSifreTekrarTxt.ForeColor = Color.Black;
            yeniSifreTekrarTxt.Location = new Point(62, 68);
            yeniSifreTekrarTxt.Name = "yeniSifreTekrarTxt";
            yeniSifreTekrarTxt.PlaceholderText = "yeni şifre tekrar";
            yeniSifreTekrarTxt.Size = new Size(202, 16);
            yeniSifreTekrarTxt.TabIndex = 35;
            yeniSifreTekrarTxt.TextAlign = HorizontalAlignment.Center;
            yeniSifreTekrarTxt.UseSystemPasswordChar = true;
            // 
            // HataLabel1
            // 
            HataLabel1.AutoSize = true;
            HataLabel1.BackColor = Color.Transparent;
            HataLabel1.Font = new Font("Bahnschrift Condensed", 11.25F);
            HataLabel1.ForeColor = Color.Red;
            HataLabel1.ImeMode = ImeMode.NoControl;
            HataLabel1.Location = new Point(62, 87);
            HataLabel1.Name = "HataLabel1";
            HataLabel1.Size = new Size(64, 18);
            HataLabel1.TabIndex = 36;
            HataLabel1.Text = "Hata Mesajı";
            // 
            // sifreGoster
            // 
            sifreGoster.BackColor = Color.Black;
            sifreGoster.BackgroundImage = Properties.Resources.ShowPasswordIcon;
            sifreGoster.BackgroundImageLayout = ImageLayout.Stretch;
            sifreGoster.Cursor = Cursors.Hand;
            sifreGoster.FlatAppearance.BorderSize = 0;
            sifreGoster.FlatStyle = FlatStyle.Flat;
            sifreGoster.Font = new Font("Segoe UI", 5F);
            sifreGoster.ForeColor = Color.Black;
            sifreGoster.Location = new Point(248, -2);
            sifreGoster.Name = "sifreGoster";
            sifreGoster.Size = new Size(16, 16);
            sifreGoster.TabIndex = 37;
            sifreGoster.UseVisualStyleBackColor = false;
            sifreGoster.Visible = false;
            sifreGoster.Click += sifreGoster_Click;
            // 
            // sifreGizle
            // 
            sifreGizle.BackColor = Color.Black;
            sifreGizle.BackgroundImage = Properties.Resources.HidePasswordIcon;
            sifreGizle.BackgroundImageLayout = ImageLayout.Stretch;
            sifreGizle.Cursor = Cursors.Hand;
            sifreGizle.FlatAppearance.BorderSize = 0;
            sifreGizle.FlatStyle = FlatStyle.Flat;
            sifreGizle.Font = new Font("Segoe UI", 5F);
            sifreGizle.ForeColor = Color.Black;
            sifreGizle.Location = new Point(248, -1);
            sifreGizle.Name = "sifreGizle";
            sifreGizle.Size = new Size(16, 16);
            sifreGizle.TabIndex = 38;
            sifreGizle.UseVisualStyleBackColor = false;
            sifreGizle.Visible = false;
            sifreGizle.Click += sifreGizle_Click;
            // 
            // SifreDegis
            // 
            SifreDegis.BackColor = Color.Transparent;
            SifreDegis.Cursor = Cursors.Hand;
            SifreDegis.FlatStyle = FlatStyle.Flat;
            SifreDegis.Font = new Font("Segoe UI", 9F);
            SifreDegis.ForeColor = Color.White;
            SifreDegis.Location = new Point(285, 405);
            SifreDegis.Name = "SifreDegis";
            SifreDegis.Size = new Size(202, 25);
            SifreDegis.TabIndex = 39;
            SifreDegis.Text = "Şifre Değiştirmek İçin Tıkla";
            SifreDegis.UseVisualStyleBackColor = false;
            SifreDegis.Click += SifreDegis_Click;
            // 
            // sifreVazgec
            // 
            sifreVazgec.Cursor = Cursors.Hand;
            sifreVazgec.FlatStyle = FlatStyle.Flat;
            sifreVazgec.Font = new Font("Candara", 9F);
            sifreVazgec.ForeColor = Color.Red;
            sifreVazgec.Location = new Point(3, 59);
            sifreVazgec.Name = "sifreVazgec";
            sifreVazgec.Size = new Size(53, 25);
            sifreVazgec.TabIndex = 40;
            sifreVazgec.Text = "Vazgeç";
            sifreVazgec.UseVisualStyleBackColor = true;
            sifreVazgec.Click += sifreVazgec_Click;
            // 
            // sifreKaydet
            // 
            sifreKaydet.Cursor = Cursors.Hand;
            sifreKaydet.FlatStyle = FlatStyle.Flat;
            sifreKaydet.Font = new Font("Candara", 9F);
            sifreKaydet.ForeColor = Color.FromArgb(224, 224, 224);
            sifreKaydet.Location = new Point(3, 27);
            sifreKaydet.Name = "sifreKaydet";
            sifreKaydet.Size = new Size(53, 25);
            sifreKaydet.TabIndex = 41;
            sifreKaydet.Text = "Kaydet";
            sifreKaydet.UseVisualStyleBackColor = true;
            sifreKaydet.Click += sifreKaydet_Click;
            // 
            // sifrepanel
            // 
            sifrepanel.BackColor = Color.Transparent;
            sifrepanel.Controls.Add(mevcutSifreTxt);
            sifrepanel.Controls.Add(sifreVazgec);
            sifrepanel.Controls.Add(sifreKaydet);
            sifrepanel.Controls.Add(sifreGizle);
            sifrepanel.Controls.Add(sifreGoster);
            sifrepanel.Controls.Add(yeniSifreTxt);
            sifrepanel.Controls.Add(HataLabel1);
            sifrepanel.Controls.Add(yeniSifreTekrarTxt);
            sifrepanel.ForeColor = SystemColors.ControlText;
            sifrepanel.Location = new Point(223, 410);
            sifrepanel.Name = "sifrepanel";
            sifrepanel.Size = new Size(264, 119);
            sifrepanel.TabIndex = 42;
            sifrepanel.Visible = false;
            // 
            // UserInfoUpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.SignUpBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(500, 618);
            Controls.Add(sifrepanel);
            Controls.Add(SifreDegis);
            Controls.Add(İslemiİptalEt);
            Controls.Add(KulResmiEkle);
            Controls.Add(KaydetForKulDuzenle);
            Controls.Add(HataLabel);
            Controls.Add(kytTelNoGir);
            Controls.Add(kytEpostaGir);
            Controls.Add(kytKulAdiGir);
            Controls.Add(kytSoyisimGir);
            Controls.Add(kytIsimGir);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserInfoUpdateForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KulVeriGuncelle";
            Load += KulBilgiGuncelle_Load;
            ((System.ComponentModel.ISupportInitialize)KulResmiEkle).EndInit();
            sifrepanel.ResumeLayout(false);
            sifrepanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox kytIsimGir;
        private TextBox kytSoyisimGir;
        private TextBox kytKulAdiGir;
        private TextBox kytEpostaGir;
        private TextBox mevcutSifreTxt;
        private MaskedTextBox kytTelNoGir;
        private Label HataLabel;
        private Button KaydetForKulDuzenle;
        private PictureBox KulResmiEkle;
        private Button İslemiİptalEt;
        private TextBox yeniSifreTxt;
        private TextBox yeniSifreTekrarTxt;
        private Label HataLabel1;
        private Button sifreGoster;
        private Button sifreGizle;
        private Button SifreDegis;
        private Button sifreVazgec;
        private Button sifreKaydet;
        private Panel sifrepanel;
    }
}