namespace PetApp
{
    partial class DeleteConfirmationBox
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
            EvetBtn = new Button();
            label1 = new Label();
            HayırBtn = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // EvetBtn
            // 
            EvetBtn.BackColor = Color.Transparent;
            EvetBtn.Cursor = Cursors.Hand;
            EvetBtn.FlatStyle = FlatStyle.Flat;
            EvetBtn.Font = new Font("Candara", 9F);
            EvetBtn.ForeColor = Color.Red;
            EvetBtn.Location = new Point(411, 186);
            EvetBtn.Name = "EvetBtn";
            EvetBtn.Size = new Size(57, 24);
            EvetBtn.TabIndex = 1;
            EvetBtn.Text = "Evet";
            EvetBtn.UseVisualStyleBackColor = false;
            EvetBtn.Click += EvetBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Candara", 14F);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(74, 94);
            label1.Name = "label1";
            label1.Size = new Size(331, 23);
            label1.TabIndex = 12;
            label1.Text = "Hayvanı silmek istediğinize emin misiniz?";
            // 
            // HayırBtn
            // 
            HayırBtn.BackColor = Color.Transparent;
            HayırBtn.Cursor = Cursors.Hand;
            HayırBtn.FlatStyle = FlatStyle.Flat;
            HayırBtn.Font = new Font("Candara", 9F);
            HayırBtn.ForeColor = Color.Turquoise;
            HayırBtn.Location = new Point(348, 186);
            HayırBtn.Name = "HayırBtn";
            HayırBtn.Size = new Size(57, 24);
            HayırBtn.TabIndex = 13;
            HayırBtn.Text = "Hayır";
            HayırBtn.UseVisualStyleBackColor = false;
            HayırBtn.Click += HayırBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 25);
            panel1.TabIndex = 14;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.LogoIcon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 45);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // DeleteConfirmationBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MainMenuBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(480, 222);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(HayırBtn);
            Controls.Add(label1);
            Controls.Add(EvetBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DeleteConfirmationBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MesajKutusu";
            Load += DeleteConfirmationBox_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EvetBtn;
        private Label label1;
        private Button HayırBtn;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}