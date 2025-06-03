namespace PetApp
{
    partial class RemovePetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemovePetForm));
            panel1 = new Panel();
            closeButton = new Button();
            EklenenHayvanlar = new FlowLayoutPanel();
            OncekiSayfaBtn = new Button();
            SonrakiSayfaBtn = new Button();
            CancelBtn = new Button();
            label1 = new Label();
            minimizeButton = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(1, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(965, 25);
            panel1.TabIndex = 9;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.Red;
            closeButton.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            closeButton.BackgroundImageLayout = ImageLayout.Stretch;
            closeButton.Cursor = Cursors.Hand;
            closeButton.FlatStyle = FlatStyle.Popup;
            closeButton.ForeColor = Color.Red;
            closeButton.ImeMode = ImeMode.NoControl;
            closeButton.Location = new Point(972, 3);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(25, 25);
            closeButton.TabIndex = 10;
            closeButton.Text = "X";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // EklenenHayvanlar
            // 
            EklenenHayvanlar.BackgroundImage = (Image)resources.GetObject("EklenenHayvanlar.BackgroundImage");
            EklenenHayvanlar.Location = new Point(125, 107);
            EklenenHayvanlar.Name = "EklenenHayvanlar";
            EklenenHayvanlar.Size = new Size(690, 280);
            EklenenHayvanlar.TabIndex = 11;
            // 
            // OncekiSayfaBtn
            // 
            OncekiSayfaBtn.BackColor = Color.Transparent;
            OncekiSayfaBtn.Cursor = Cursors.Hand;
            OncekiSayfaBtn.FlatAppearance.BorderSize = 0;
            OncekiSayfaBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            OncekiSayfaBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            OncekiSayfaBtn.FlatStyle = FlatStyle.Flat;
            OncekiSayfaBtn.Font = new Font("Segoe UI", 15.75F);
            OncekiSayfaBtn.ForeColor = Color.Turquoise;
            OncekiSayfaBtn.ImeMode = ImeMode.NoControl;
            OncekiSayfaBtn.Location = new Point(82, 200);
            OncekiSayfaBtn.Name = "OncekiSayfaBtn";
            OncekiSayfaBtn.Size = new Size(39, 89);
            OncekiSayfaBtn.TabIndex = 16;
            OncekiSayfaBtn.Text = "🡸";
            OncekiSayfaBtn.UseVisualStyleBackColor = false;
            OncekiSayfaBtn.Click += OncekiSayfaBtn_Click;
            // 
            // SonrakiSayfaBtn
            // 
            SonrakiSayfaBtn.BackColor = Color.Transparent;
            SonrakiSayfaBtn.Cursor = Cursors.Hand;
            SonrakiSayfaBtn.FlatAppearance.BorderSize = 0;
            SonrakiSayfaBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            SonrakiSayfaBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            SonrakiSayfaBtn.FlatStyle = FlatStyle.Flat;
            SonrakiSayfaBtn.Font = new Font("Segoe UI", 15.75F);
            SonrakiSayfaBtn.ForeColor = Color.Turquoise;
            SonrakiSayfaBtn.ImeMode = ImeMode.NoControl;
            SonrakiSayfaBtn.Location = new Point(821, 200);
            SonrakiSayfaBtn.Name = "SonrakiSayfaBtn";
            SonrakiSayfaBtn.Size = new Size(39, 89);
            SonrakiSayfaBtn.TabIndex = 17;
            SonrakiSayfaBtn.Text = "🡺";
            SonrakiSayfaBtn.UseVisualStyleBackColor = false;
            SonrakiSayfaBtn.Click += SonrakiSayfaBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Transparent;
            CancelBtn.Cursor = Cursors.Hand;
            CancelBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            CancelBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            CancelBtn.FlatStyle = FlatStyle.Flat;
            CancelBtn.Font = new Font("Candara", 9F);
            CancelBtn.ForeColor = Color.Red;
            CancelBtn.ImeMode = ImeMode.NoControl;
            CancelBtn.Location = new Point(763, 75);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(41, 26);
            CancelBtn.TabIndex = 19;
            CancelBtn.TabStop = false;
            CancelBtn.Text = "İptal";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe Script", 9F);
            label1.ForeColor = Color.Gold;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(12, 107);
            label1.Name = "label1";
            label1.Size = new Size(105, 19);
            label1.TabIndex = 21;
            label1.Text = "Arkadaşım Pet";
            // 
            // minimizeButton
            // 
            minimizeButton.BackColor = Color.FromArgb(255, 192, 192);
            minimizeButton.BackgroundImage = (Image)resources.GetObject("minimizeButton.BackgroundImage");
            minimizeButton.BackgroundImageLayout = ImageLayout.Stretch;
            minimizeButton.Cursor = Cursors.Hand;
            minimizeButton.FlatAppearance.BorderSize = 2;
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.ForeColor = Color.Transparent;
            minimizeButton.ImeMode = ImeMode.NoControl;
            minimizeButton.Location = new Point(972, 34);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(25, 10);
            minimizeButton.TabIndex = 22;
            minimizeButton.Text = "-";
            minimizeButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            minimizeButton.UseVisualStyleBackColor = false;
            minimizeButton.Click += minimizedButtonForChoosePet_Click;
            // 
            // RemovePetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1000, 618);
            Controls.Add(minimizeButton);
            Controls.Add(label1);
            Controls.Add(CancelBtn);
            Controls.Add(SonrakiSayfaBtn);
            Controls.Add(OncekiSayfaBtn);
            Controls.Add(EklenenHayvanlar);
            Controls.Add(closeButton);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RemovePetForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HayvanKaldır";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button closeButton;
        private FlowLayoutPanel EklenenHayvanlar;
        private Button OncekiSayfaBtn;
        private Button SonrakiSayfaBtn;
        private Button CancelBtn;
        private Label label1;
        private Button minimizeButton;
    }
}