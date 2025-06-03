namespace PetApp
{
    partial class PetInfoUpdateForm
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
            HyvnIsimGir = new TextBox();
            HyvnYasGir = new TextBox();
            HyvnIrkGir = new TextBox();
            HataLabel = new Label();
            CinsiyetcomboBox = new ComboBox();
            KaydetForDostDuzenle = new Button();
            panel1 = new Panel();
            DostResmiEkle = new PictureBox();
            İslemiİptalEt = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)DostResmiEkle).BeginInit();
            SuspendLayout();
            // 
            // HyvnIsimGir
            // 
            HyvnIsimGir.BackColor = Color.White;
            HyvnIsimGir.BorderStyle = BorderStyle.FixedSingle;
            HyvnIsimGir.Cursor = Cursors.IBeam;
            HyvnIsimGir.ForeColor = Color.Black;
            HyvnIsimGir.Location = new Point(145, 275);
            HyvnIsimGir.Name = "HyvnIsimGir";
            HyvnIsimGir.PlaceholderText = "isim";
            HyvnIsimGir.Size = new Size(205, 23);
            HyvnIsimGir.TabIndex = 16;
            HyvnIsimGir.Tag = "";
            HyvnIsimGir.TextAlign = HorizontalAlignment.Center;
            // 
            // HyvnYasGir
            // 
            HyvnYasGir.BackColor = Color.White;
            HyvnYasGir.BorderStyle = BorderStyle.FixedSingle;
            HyvnYasGir.Cursor = Cursors.IBeam;
            HyvnYasGir.ForeColor = Color.Black;
            HyvnYasGir.Location = new Point(145, 350);
            HyvnYasGir.Name = "HyvnYasGir";
            HyvnYasGir.PlaceholderText = "yaş";
            HyvnYasGir.Size = new Size(205, 23);
            HyvnYasGir.TabIndex = 21;
            HyvnYasGir.Tag = "";
            HyvnYasGir.TextAlign = HorizontalAlignment.Center;
            // 
            // HyvnIrkGir
            // 
            HyvnIrkGir.BackColor = Color.White;
            HyvnIrkGir.BorderStyle = BorderStyle.FixedSingle;
            HyvnIrkGir.Cursor = Cursors.IBeam;
            HyvnIrkGir.ForeColor = Color.Black;
            HyvnIrkGir.Location = new Point(145, 425);
            HyvnIrkGir.Name = "HyvnIrkGir";
            HyvnIrkGir.PlaceholderText = "ırk";
            HyvnIrkGir.Size = new Size(205, 23);
            HyvnIrkGir.TabIndex = 22;
            HyvnIrkGir.TextAlign = HorizontalAlignment.Center;
            // 
            // HataLabel
            // 
            HataLabel.AutoSize = true;
            HataLabel.BackColor = Color.Transparent;
            HataLabel.Font = new Font("Bahnschrift Condensed", 11.25F);
            HataLabel.ForeColor = Color.Red;
            HataLabel.ImeMode = ImeMode.NoControl;
            HataLabel.Location = new Point(145, 380);
            HataLabel.Name = "HataLabel";
            HataLabel.Size = new Size(64, 18);
            HataLabel.TabIndex = 23;
            HataLabel.Text = "Hata Mesajı";
            HataLabel.Visible = false;
            // 
            // CinsiyetcomboBox
            // 
            CinsiyetcomboBox.BackColor = Color.White;
            CinsiyetcomboBox.Cursor = Cursors.IBeam;
            CinsiyetcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CinsiyetcomboBox.FlatStyle = FlatStyle.Flat;
            CinsiyetcomboBox.ForeColor = Color.Black;
            CinsiyetcomboBox.FormattingEnabled = true;
            CinsiyetcomboBox.Items.AddRange(new object[] { "Erkek", "Dişi", "Bilinmiyor" });
            CinsiyetcomboBox.Location = new Point(145, 500);
            CinsiyetcomboBox.Name = "CinsiyetcomboBox";
            CinsiyetcomboBox.Size = new Size(205, 23);
            CinsiyetcomboBox.TabIndex = 26;
            // 
            // KaydetForDostDuzenle
            // 
            KaydetForDostDuzenle.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            KaydetForDostDuzenle.Cursor = Cursors.Hand;
            KaydetForDostDuzenle.FlatAppearance.BorderSize = 3;
            KaydetForDostDuzenle.FlatStyle = FlatStyle.Flat;
            KaydetForDostDuzenle.Font = new Font("Candara", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            KaydetForDostDuzenle.ForeColor = Color.White;
            KaydetForDostDuzenle.Location = new Point(443, 110);
            KaydetForDostDuzenle.Name = "KaydetForDostDuzenle";
            KaydetForDostDuzenle.Size = new Size(55, 80);
            KaydetForDostDuzenle.TabIndex = 27;
            KaydetForDostDuzenle.Text = "✓";
            KaydetForDostDuzenle.UseVisualStyleBackColor = true;
            KaydetForDostDuzenle.Click += KaydetForDostDuzenle_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 25);
            panel1.TabIndex = 29;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // DostResmiEkle
            // 
            DostResmiEkle.BackColor = Color.Transparent;
            DostResmiEkle.BackgroundImage = Properties.Resources.AddPhotoIcon;
            DostResmiEkle.BackgroundImageLayout = ImageLayout.Stretch;
            DostResmiEkle.Cursor = Cursors.Hand;
            DostResmiEkle.ImeMode = ImeMode.NoControl;
            DostResmiEkle.Location = new Point(165, 80);
            DostResmiEkle.Name = "DostResmiEkle";
            DostResmiEkle.Size = new Size(160, 160);
            DostResmiEkle.TabIndex = 30;
            DostResmiEkle.TabStop = false;
            DostResmiEkle.Click += DostResmiEkle_Click;
            // 
            // İslemiİptalEt
            // 
            İslemiİptalEt.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            İslemiİptalEt.Cursor = Cursors.Hand;
            İslemiİptalEt.FlatAppearance.BorderSize = 3;
            İslemiİptalEt.FlatStyle = FlatStyle.Flat;
            İslemiİptalEt.Font = new Font("Candara", 9.75F);
            İslemiİptalEt.ForeColor = Color.Red;
            İslemiİptalEt.Location = new Point(443, 196);
            İslemiİptalEt.Name = "İslemiİptalEt";
            İslemiİptalEt.Size = new Size(55, 80);
            İslemiİptalEt.TabIndex = 31;
            İslemiİptalEt.Text = "İşlemi İptal Et";
            İslemiİptalEt.UseVisualStyleBackColor = true;
            İslemiİptalEt.Click += İslemiİptalEt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Candara", 11F);
            label1.ForeColor = Color.White;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(294, 526);
            label1.Name = "label1";
            label1.Size = new Size(56, 18);
            label1.TabIndex = 37;
            label1.Text = "Cinsiyet";
            // 
            // PetInfoUpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.SignUpBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(500, 618);
            Controls.Add(label1);
            Controls.Add(İslemiİptalEt);
            Controls.Add(DostResmiEkle);
            Controls.Add(panel1);
            Controls.Add(KaydetForDostDuzenle);
            Controls.Add(CinsiyetcomboBox);
            Controls.Add(HataLabel);
            Controls.Add(HyvnIrkGir);
            Controls.Add(HyvnYasGir);
            Controls.Add(HyvnIsimGir);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PetInfoUpdateForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HayvanVeriGüncelle";
            Load += DostBilgiGüncelle_Load;
            ((System.ComponentModel.ISupportInitialize)DostResmiEkle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox HyvnIsimGir;
        private TextBox HyvnYasGir;
        private TextBox HyvnIrkGir;
        private Label HataLabel;
        private ComboBox CinsiyetcomboBox;
        private Button KaydetForDostDuzenle;
        private Panel panel1;
        private PictureBox DostResmiEkle;
        private Button İslemiİptalEt;
        private Label label1;
    }
}