namespace PetApp
{
    partial class AddPetImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPetImageForm));
            DostResmiEkle = new PictureBox();
            HyvnKaydetbtn = new Button();
            panel1 = new Panel();
            İslemiİptalEt = new Button();
            GeriDonButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)DostResmiEkle).BeginInit();
            SuspendLayout();
            // 
            // DostResmiEkle
            // 
            resources.ApplyResources(DostResmiEkle, "DostResmiEkle");
            DostResmiEkle.BackColor = Color.Transparent;
            DostResmiEkle.BackgroundImage = Properties.Resources.AddPhotoIcon;
            DostResmiEkle.Cursor = Cursors.Hand;
            DostResmiEkle.Name = "DostResmiEkle";
            DostResmiEkle.TabStop = false;
            DostResmiEkle.Click += DostResmiEkle_Click;
            // 
            // HyvnKaydetbtn
            // 
            resources.ApplyResources(HyvnKaydetbtn, "HyvnKaydetbtn");
            HyvnKaydetbtn.BackColor = Color.White;
            HyvnKaydetbtn.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            HyvnKaydetbtn.Cursor = Cursors.Hand;
            HyvnKaydetbtn.FlatAppearance.BorderSize = 3;
            HyvnKaydetbtn.ForeColor = Color.White;
            HyvnKaydetbtn.Name = "HyvnKaydetbtn";
            HyvnKaydetbtn.UseVisualStyleBackColor = false;
            HyvnKaydetbtn.Click += HyvnKaydetbtn_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.Transparent;
            panel1.Name = "panel1";
            panel1.MouseDown += panel1_MouseDown;
            // 
            // İslemiİptalEt
            // 
            resources.ApplyResources(İslemiİptalEt, "İslemiİptalEt");
            İslemiİptalEt.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            İslemiİptalEt.Cursor = Cursors.Hand;
            İslemiİptalEt.FlatAppearance.BorderSize = 3;
            İslemiİptalEt.ForeColor = Color.Red;
            İslemiİptalEt.Name = "İslemiİptalEt";
            İslemiİptalEt.UseVisualStyleBackColor = true;
            İslemiİptalEt.Click += İslemiİptalEt_Click;
            // 
            // GeriDonButton
            // 
            resources.ApplyResources(GeriDonButton, "GeriDonButton");
            GeriDonButton.BackColor = Color.Black;
            GeriDonButton.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            GeriDonButton.Cursor = Cursors.Hand;
            GeriDonButton.ForeColor = Color.Turquoise;
            GeriDonButton.Name = "GeriDonButton";
            GeriDonButton.UseVisualStyleBackColor = false;
            GeriDonButton.Click += GeriDonButton_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Gold;
            label1.Name = "label1";
            // 
            // AddPetImageForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.SignUpBackground;
            Controls.Add(label1);
            Controls.Add(GeriDonButton);
            Controls.Add(İslemiİptalEt);
            Controls.Add(panel1);
            Controls.Add(HyvnKaydetbtn);
            Controls.Add(DostResmiEkle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddPetImageForm";
            ((System.ComponentModel.ISupportInitialize)DostResmiEkle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox DostResmiEkle;
        private Button HyvnKaydetbtn;
        private Panel panel1;
        private Button İslemiİptalEt;
        private Button GeriDonButton;
        private Label label1;
    }
}