namespace PetApp
{
    partial class GirisSayfasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisSayfasi));
            girisYap = new Button();
            kullaniciAdiGir = new TextBox();
            sifreGir = new TextBox();
            lblAdSoyad = new Label();
            lblSifre = new Label();
            closeButton = new Button();
            kaydol = new Button();
            HataLabel = new Label();
            panel1 = new Panel();
            label1 = new Label();
            minimizeButton = new Button();
            sifreGizle = new Button();
            sifreGoster = new Button();
            sesiac = new Button();
            sesikapat = new Button();
            cbRememberMe = new CheckBox();
            btnVolUp = new Button();
            btnVolDown = new Button();
            tbVolume = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)tbVolume).BeginInit();
            SuspendLayout();
            // 
            // girisYap
            // 
            resources.ApplyResources(girisYap, "girisYap");
            girisYap.Cursor = Cursors.Hand;
            girisYap.ForeColor = SystemColors.HighlightText;
            girisYap.Name = "girisYap";
            girisYap.UseVisualStyleBackColor = true;
            girisYap.Click += girisYap_Click;
            // 
            // kullaniciAdiGir
            // 
            resources.ApplyResources(kullaniciAdiGir, "kullaniciAdiGir");
            kullaniciAdiGir.BackColor = Color.White;
            kullaniciAdiGir.BorderStyle = BorderStyle.None;
            kullaniciAdiGir.Cursor = Cursors.IBeam;
            kullaniciAdiGir.ForeColor = Color.Black;
            kullaniciAdiGir.Name = "kullaniciAdiGir";
            kullaniciAdiGir.TextChanged += kullaniciAdiGir_TextChanged;
            // 
            // sifreGir
            // 
            resources.ApplyResources(sifreGir, "sifreGir");
            sifreGir.BackColor = Color.White;
            sifreGir.BorderStyle = BorderStyle.None;
            sifreGir.Cursor = Cursors.IBeam;
            sifreGir.ForeColor = Color.Black;
            sifreGir.Name = "sifreGir";
            sifreGir.UseSystemPasswordChar = true;
            sifreGir.TextChanged += sifreGir_TextChanged;
            // 
            // lblAdSoyad
            // 
            resources.ApplyResources(lblAdSoyad, "lblAdSoyad");
            lblAdSoyad.BackColor = Color.Transparent;
            lblAdSoyad.ForeColor = Color.Black;
            lblAdSoyad.Name = "lblAdSoyad";
            // 
            // lblSifre
            // 
            resources.ApplyResources(lblSifre, "lblSifre");
            lblSifre.BackColor = Color.Transparent;
            lblSifre.ForeColor = Color.Black;
            lblSifre.Name = "lblSifre";
            // 
            // closeButton
            // 
            resources.ApplyResources(closeButton, "closeButton");
            closeButton.BackColor = Color.Red;
            closeButton.Cursor = Cursors.Hand;
            closeButton.ForeColor = Color.Red;
            closeButton.Name = "closeButton";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // kaydol
            // 
            resources.ApplyResources(kaydol, "kaydol");
            kaydol.BackColor = Color.Orange;
            kaydol.Cursor = Cursors.Hand;
            kaydol.ForeColor = Color.Orange;
            kaydol.Name = "kaydol";
            kaydol.UseVisualStyleBackColor = false;
            kaydol.Click += kaydol_Click;
            // 
            // HataLabel
            // 
            resources.ApplyResources(HataLabel, "HataLabel");
            HataLabel.BackColor = Color.Transparent;
            HataLabel.ForeColor = Color.Red;
            HataLabel.Name = "HataLabel";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.Transparent;
            panel1.Name = "panel1";
            panel1.MouseDown += panel1_MouseDown;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Gold;
            label1.Name = "label1";
            // 
            // minimizeButton
            // 
            resources.ApplyResources(minimizeButton, "minimizeButton");
            minimizeButton.BackColor = Color.FromArgb(255, 192, 192);
            minimizeButton.Cursor = Cursors.Hand;
            minimizeButton.FlatAppearance.BorderSize = 2;
            minimizeButton.ForeColor = Color.Transparent;
            minimizeButton.Name = "minimizeButton";
            minimizeButton.UseVisualStyleBackColor = false;
            minimizeButton.Click += minimizeButton_Click;
            // 
            // sifreGizle
            // 
            resources.ApplyResources(sifreGizle, "sifreGizle");
            sifreGizle.BackColor = Color.Black;
            sifreGizle.BackgroundImage = Properties.Resources.HidePasswordIcon;
            sifreGizle.Cursor = Cursors.Hand;
            sifreGizle.FlatAppearance.BorderSize = 0;
            sifreGizle.ForeColor = Color.Black;
            sifreGizle.Name = "sifreGizle";
            sifreGizle.UseVisualStyleBackColor = false;
            sifreGizle.Click += sifreGizle_Click;
            // 
            // sifreGoster
            // 
            resources.ApplyResources(sifreGoster, "sifreGoster");
            sifreGoster.BackColor = Color.Black;
            sifreGoster.BackgroundImage = Properties.Resources.ShowPasswordIcon;
            sifreGoster.Cursor = Cursors.Hand;
            sifreGoster.FlatAppearance.BorderSize = 0;
            sifreGoster.ForeColor = Color.Black;
            sifreGoster.Name = "sifreGoster";
            sifreGoster.UseVisualStyleBackColor = false;
            sifreGoster.Click += sifreGoster_Click;
            // 
            // sesiac
            // 
            resources.ApplyResources(sesiac, "sesiac");
            sesiac.BackColor = Color.FromArgb(15, 30, 40);
            sesiac.BackgroundImage = Properties.Resources.UnmuteIcon;
            sesiac.Cursor = Cursors.Hand;
            sesiac.FlatAppearance.MouseDownBackColor = Color.Transparent;
            sesiac.FlatAppearance.MouseOverBackColor = Color.Transparent;
            sesiac.ForeColor = Color.Turquoise;
            sesiac.Name = "sesiac";
            sesiac.UseVisualStyleBackColor = false;
            sesiac.Click += sesiac_Click;
            // 
            // sesikapat
            // 
            resources.ApplyResources(sesikapat, "sesikapat");
            sesikapat.BackColor = Color.FromArgb(15, 30, 40);
            sesikapat.BackgroundImage = Properties.Resources.UnmuteIcon;
            sesikapat.Cursor = Cursors.Hand;
            sesikapat.FlatAppearance.MouseDownBackColor = Color.Transparent;
            sesikapat.FlatAppearance.MouseOverBackColor = Color.Transparent;
            sesikapat.ForeColor = Color.Turquoise;
            sesikapat.Name = "sesikapat";
            sesikapat.UseVisualStyleBackColor = false;
            sesikapat.Click += sesikapat_Click;
            // 
            // cbRememberMe
            // 
            resources.ApplyResources(cbRememberMe, "cbRememberMe");
            cbRememberMe.BackColor = Color.Transparent;
            cbRememberMe.ForeColor = Color.Black;
            cbRememberMe.Name = "cbRememberMe";
            cbRememberMe.UseVisualStyleBackColor = false;
            // 
            // btnVolUp
            // 
            resources.ApplyResources(btnVolUp, "btnVolUp");
            btnVolUp.BackColor = Color.FromArgb(15, 30, 40);
            btnVolUp.BackgroundImage = Properties.Resources.IncreaseVolumeIcon;
            btnVolUp.Cursor = Cursors.Hand;
            btnVolUp.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolUp.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolUp.ForeColor = Color.White;
            btnVolUp.Name = "btnVolUp";
            btnVolUp.UseVisualStyleBackColor = false;
            btnVolUp.Click += btnVolUp_Click;
            // 
            // btnVolDown
            // 
            resources.ApplyResources(btnVolDown, "btnVolDown");
            btnVolDown.BackColor = Color.FromArgb(15, 30, 40);
            btnVolDown.BackgroundImage = Properties.Resources.DecreaseVolumeIcon;
            btnVolDown.Cursor = Cursors.Hand;
            btnVolDown.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnVolDown.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnVolDown.ForeColor = Color.White;
            btnVolDown.Name = "btnVolDown";
            btnVolDown.UseVisualStyleBackColor = false;
            btnVolDown.Click += btnVolDown_Click;
            // 
            // tbVolume
            // 
            resources.ApplyResources(tbVolume, "tbVolume");
            tbVolume.Maximum = 100;
            tbVolume.Name = "tbVolume";
            // 
            // GirisSayfasi
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(tbVolume);
            Controls.Add(btnVolDown);
            Controls.Add(btnVolUp);
            Controls.Add(cbRememberMe);
            Controls.Add(sesikapat);
            Controls.Add(sesiac);
            Controls.Add(sifreGoster);
            Controls.Add(sifreGizle);
            Controls.Add(minimizeButton);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(HataLabel);
            Controls.Add(kaydol);
            Controls.Add(closeButton);
            Controls.Add(lblSifre);
            Controls.Add(lblAdSoyad);
            Controls.Add(sifreGir);
            Controls.Add(kullaniciAdiGir);
            Controls.Add(girisYap);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "GirisSayfasi";
            ((System.ComponentModel.ISupportInitialize)tbVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button girisYap;
        private TextBox kullaniciAdiGir;
        private TextBox sifreGir;
        private Label lblAdSoyad;
        private Label lblSifre;
        private Button closeButton;
        private Button kaydol;
        private Label HataLabel;
        private Panel panel1;
        private Label label1;
        private Button minimizeButton;
        private Button sifreGizle;
        private Button sifreGoster;
        private Button sesiac;
        private Button sesikapat;
        private CheckBox cbRememberMe;
        private Button btnVolUp;
        private Button btnVolDown;
        private TrackBar tbVolume;
    }
}
