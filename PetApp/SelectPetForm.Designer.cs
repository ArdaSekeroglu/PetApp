
namespace PetApp
{
    partial class SelectPetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPetForm));
            closeButton = new Button();
            minimizeButton = new Button();
            panel1 = new Panel();
            EklenenHayvanlar = new FlowLayoutPanel();
            hayvanEkle = new Button();
            hayvanKaldir = new Button();
            SonrakiSayfaBtn = new Button();
            OncekiSayfaBtn = new Button();
            CikisYapBtn = new Button();
            label1 = new Label();
            AyarlarToggleButon2 = new Button();
            AyarlarToggleButon = new Button();
            DuzenleForKullanici = new Button();
            sesikapat = new Button();
            sesiac = new Button();
            tbVolume = new TrackBar();
            btnVolDown = new Button();
            btnVolUp = new Button();
            ((System.ComponentModel.ISupportInitialize)tbVolume).BeginInit();
            SuspendLayout();
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
            // minimizeButton
            // 
            resources.ApplyResources(minimizeButton, "minimizeButton");
            minimizeButton.BackColor = Color.FromArgb(255, 192, 192);
            minimizeButton.Cursor = Cursors.Hand;
            minimizeButton.FlatAppearance.BorderSize = 2;
            minimizeButton.ForeColor = Color.Transparent;
            minimizeButton.Name = "minimizeButton";
            minimizeButton.UseVisualStyleBackColor = false;
            minimizeButton.Click += minimizedButtonForChoosePet_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.Transparent;
            panel1.Name = "panel1";
            panel1.MouseDown += panel1_MouseDown;
            // 
            // EklenenHayvanlar
            // 
            resources.ApplyResources(EklenenHayvanlar, "EklenenHayvanlar");
            EklenenHayvanlar.Name = "EklenenHayvanlar";
            // 
            // hayvanEkle
            // 
            resources.ApplyResources(hayvanEkle, "hayvanEkle");
            hayvanEkle.BackColor = Color.Transparent;
            hayvanEkle.Cursor = Cursors.Hand;
            hayvanEkle.FlatAppearance.MouseDownBackColor = Color.Transparent;
            hayvanEkle.FlatAppearance.MouseOverBackColor = Color.Transparent;
            hayvanEkle.ForeColor = Color.Turquoise;
            hayvanEkle.Name = "hayvanEkle";
            hayvanEkle.TabStop = false;
            hayvanEkle.UseVisualStyleBackColor = false;
            hayvanEkle.Click += hayvanEkle_Click;
            // 
            // hayvanKaldir
            // 
            resources.ApplyResources(hayvanKaldir, "hayvanKaldir");
            hayvanKaldir.BackColor = Color.Transparent;
            hayvanKaldir.Cursor = Cursors.Hand;
            hayvanKaldir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            hayvanKaldir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            hayvanKaldir.ForeColor = Color.Red;
            hayvanKaldir.Name = "hayvanKaldir";
            hayvanKaldir.UseVisualStyleBackColor = false;
            hayvanKaldir.Click += hayvanKaldir_Click;
            // 
            // SonrakiSayfaBtn
            // 
            resources.ApplyResources(SonrakiSayfaBtn, "SonrakiSayfaBtn");
            SonrakiSayfaBtn.BackColor = Color.Transparent;
            SonrakiSayfaBtn.Cursor = Cursors.Hand;
            SonrakiSayfaBtn.FlatAppearance.BorderSize = 0;
            SonrakiSayfaBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            SonrakiSayfaBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            SonrakiSayfaBtn.ForeColor = Color.Turquoise;
            SonrakiSayfaBtn.Name = "SonrakiSayfaBtn";
            SonrakiSayfaBtn.UseMnemonic = false;
            SonrakiSayfaBtn.UseVisualStyleBackColor = false;
            SonrakiSayfaBtn.Click += SonrakiSayfaBtn_Click;
            // 
            // OncekiSayfaBtn
            // 
            resources.ApplyResources(OncekiSayfaBtn, "OncekiSayfaBtn");
            OncekiSayfaBtn.BackColor = Color.Transparent;
            OncekiSayfaBtn.Cursor = Cursors.Hand;
            OncekiSayfaBtn.FlatAppearance.BorderSize = 0;
            OncekiSayfaBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            OncekiSayfaBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            OncekiSayfaBtn.ForeColor = Color.Turquoise;
            OncekiSayfaBtn.Name = "OncekiSayfaBtn";
            OncekiSayfaBtn.UseMnemonic = false;
            OncekiSayfaBtn.UseVisualStyleBackColor = false;
            OncekiSayfaBtn.Click += OncekiSayfaBtn_Click;
            // 
            // CikisYapBtn
            // 
            resources.ApplyResources(CikisYapBtn, "CikisYapBtn");
            CikisYapBtn.BackColor = Color.Black;
            CikisYapBtn.BackgroundImage = Properties.Resources.LogOutIcon;
            CikisYapBtn.Cursor = Cursors.Hand;
            CikisYapBtn.ForeColor = Color.Turquoise;
            CikisYapBtn.Name = "CikisYapBtn";
            CikisYapBtn.UseVisualStyleBackColor = false;
            CikisYapBtn.Click += CikisYapBtn_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Gold;
            label1.Name = "label1";
            // 
            // AyarlarToggleButon2
            // 
            resources.ApplyResources(AyarlarToggleButon2, "AyarlarToggleButon2");
            AyarlarToggleButon2.BackColor = Color.FromArgb(15, 30, 40);
            AyarlarToggleButon2.BackgroundImage = Properties.Resources.SettingsIcon;
            AyarlarToggleButon2.Cursor = Cursors.Hand;
            AyarlarToggleButon2.FlatAppearance.MouseDownBackColor = Color.FromArgb(15, 30, 40);
            AyarlarToggleButon2.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 30, 40);
            AyarlarToggleButon2.ForeColor = Color.Black;
            AyarlarToggleButon2.Name = "AyarlarToggleButon2";
            AyarlarToggleButon2.UseVisualStyleBackColor = false;
            AyarlarToggleButon2.Click += AyarlarToggleButon2_Click;
            // 
            // AyarlarToggleButon
            // 
            resources.ApplyResources(AyarlarToggleButon, "AyarlarToggleButon");
            AyarlarToggleButon.BackColor = Color.FromArgb(15, 30, 40);
            AyarlarToggleButon.BackgroundImage = Properties.Resources.SettingsIcon;
            AyarlarToggleButon.Cursor = Cursors.Hand;
            AyarlarToggleButon.FlatAppearance.MouseDownBackColor = Color.FromArgb(15, 30, 40);
            AyarlarToggleButon.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 30, 40);
            AyarlarToggleButon.ForeColor = Color.Black;
            AyarlarToggleButon.Name = "AyarlarToggleButon";
            AyarlarToggleButon.UseVisualStyleBackColor = false;
            AyarlarToggleButon.Click += AyarlarToggleButon_Click;
            // 
            // DuzenleForKullanici
            // 
            resources.ApplyResources(DuzenleForKullanici, "DuzenleForKullanici");
            DuzenleForKullanici.BackgroundImage = Properties.Resources.ProfileIcon;
            DuzenleForKullanici.Cursor = Cursors.Hand;
            DuzenleForKullanici.ForeColor = Color.Turquoise;
            DuzenleForKullanici.Name = "DuzenleForKullanici";
            DuzenleForKullanici.UseVisualStyleBackColor = true;
            DuzenleForKullanici.Click += DuzenleForKullanici_Click;
            // 
            // sesikapat
            // 
            resources.ApplyResources(sesikapat, "sesikapat");
            sesikapat.BackColor = Color.FromArgb(15, 30, 40);
            sesikapat.BackgroundImage = Properties.Resources.IncreaseVolumeIcon;
            sesikapat.Cursor = Cursors.Hand;
            sesikapat.FlatAppearance.MouseDownBackColor = Color.Transparent;
            sesikapat.FlatAppearance.MouseOverBackColor = Color.Transparent;
            sesikapat.ForeColor = Color.Turquoise;
            sesikapat.Name = "sesikapat";
            sesikapat.UseVisualStyleBackColor = false;
            sesikapat.Click += sesikapat_Click;
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
            // tbVolume
            // 
            resources.ApplyResources(tbVolume, "tbVolume");
            tbVolume.Maximum = 100;
            tbVolume.Name = "tbVolume";
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
            // SelectPetForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(btnVolUp);
            Controls.Add(btnVolDown);
            Controls.Add(tbVolume);
            Controls.Add(sesiac);
            Controls.Add(sesikapat);
            Controls.Add(DuzenleForKullanici);
            Controls.Add(AyarlarToggleButon);
            Controls.Add(AyarlarToggleButon2);
            Controls.Add(label1);
            Controls.Add(CikisYapBtn);
            Controls.Add(OncekiSayfaBtn);
            Controls.Add(SonrakiSayfaBtn);
            Controls.Add(hayvanKaldir);
            Controls.Add(hayvanEkle);
            Controls.Add(EklenenHayvanlar);
            Controls.Add(panel1);
            Controls.Add(minimizeButton);
            Controls.Add(closeButton);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SelectPetForm";
            Load += HayvanSec_Load;
            ((System.ComponentModel.ISupportInitialize)tbVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void tbVolume_Scroll_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button closeButton;
        private Button minimizeButton;
        private Panel panel1;
        private FlowLayoutPanel EklenenHayvanlar;
        private Button hayvanEkle;
        private Button hayvanKaldir;
        private Button SonrakiSayfaBtn;
        private Button OncekiSayfaBtn;
        private Button CikisYapBtn;
        private Label label1;
        private Button AyarlarToggleButon2;
        private Button AyarlarToggleButon;
        private Button DuzenleForKullanici;
        private Button sesikapat;
        private Button sesiac;
        private TrackBar tbVolume;
        private Button btnVolDown;
        private Button btnVolUp;
    }
}