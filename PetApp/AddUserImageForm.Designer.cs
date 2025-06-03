namespace PetApp
{
    partial class AddUserImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserImageForm));
            resimEkle = new PictureBox();
            kaydiBitir = new Button();
            panel1 = new Panel();
            basaDön = new Button();
            label1 = new Label();
            İslemiİptalEt = new Button();
            ((System.ComponentModel.ISupportInitialize)resimEkle).BeginInit();
            SuspendLayout();
            // 
            // resimEkle
            // 
            resources.ApplyResources(resimEkle, "resimEkle");
            resimEkle.BackColor = Color.Black;
            resimEkle.BackgroundImage = Properties.Resources.AddPhotoIcon;
            resimEkle.Name = "resimEkle";
            resimEkle.TabStop = false;
            resimEkle.Click += resimEkle_Click;
            // 
            // kaydiBitir
            // 
            resources.ApplyResources(kaydiBitir, "kaydiBitir");
            kaydiBitir.BackColor = Color.White;
            kaydiBitir.Cursor = Cursors.Hand;
            kaydiBitir.FlatAppearance.BorderColor = Color.White;
            kaydiBitir.FlatAppearance.BorderSize = 3;
            kaydiBitir.ForeColor = Color.White;
            kaydiBitir.Image = Properties.Resources.NavyBlueHorizontalRectangle;
            kaydiBitir.Name = "kaydiBitir";
            kaydiBitir.UseVisualStyleBackColor = false;
            kaydiBitir.Click += kaydiBitir_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.Transparent;
            panel1.Name = "panel1";
            panel1.MouseDown += panel1_MouseDown;
            // 
            // basaDön
            // 
            resources.ApplyResources(basaDön, "basaDön");
            basaDön.BackColor = Color.Black;
            basaDön.Cursor = Cursors.Hand;
            basaDön.ForeColor = Color.Turquoise;
            basaDön.Name = "basaDön";
            basaDön.UseVisualStyleBackColor = false;
            basaDön.Click += basaDön_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Gold;
            label1.Name = "label1";
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
            İslemiİptalEt.Click += verileriSil_Click;
            // 
            // AddUserImageForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(İslemiİptalEt);
            Controls.Add(label1);
            Controls.Add(basaDön);
            Controls.Add(panel1);
            Controls.Add(kaydiBitir);
            Controls.Add(resimEkle);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddUserImageForm";
            ((System.ComponentModel.ISupportInitialize)resimEkle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox resimEkle;
        private Button kaydiBitir;
        private Panel panel1;
        private Button basaDön;
        private Label label1;
        private Button İslemiİptalEt;
    }
}