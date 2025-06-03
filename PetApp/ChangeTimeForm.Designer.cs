namespace PetApp
{
    partial class ChangeTimeForm
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
            saatleriGoruntule = new FlowLayoutPanel();
            saatleriKaydet = new Button();
            İslemiİptalEt = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // saatleriGoruntule
            // 
            saatleriGoruntule.BackColor = Color.Transparent;
            saatleriGoruntule.Location = new Point(75, 158);
            saatleriGoruntule.Name = "saatleriGoruntule";
            saatleriGoruntule.Size = new Size(345, 270);
            saatleriGoruntule.TabIndex = 0;
            // 
            // saatleriKaydet
            // 
            saatleriKaydet.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            saatleriKaydet.Cursor = Cursors.Hand;
            saatleriKaydet.FlatAppearance.BorderSize = 3;
            saatleriKaydet.FlatStyle = FlatStyle.Flat;
            saatleriKaydet.Font = new Font("Candara", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            saatleriKaydet.ForeColor = Color.White;
            saatleriKaydet.Location = new Point(443, 110);
            saatleriKaydet.Name = "saatleriKaydet";
            saatleriKaydet.Size = new Size(55, 80);
            saatleriKaydet.TabIndex = 28;
            saatleriKaydet.Text = "✓";
            saatleriKaydet.UseVisualStyleBackColor = true;
            saatleriKaydet.Click += saatleriKaydet_Click;
            // 
            // İslemiİptalEt
            // 
            İslemiİptalEt.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            İslemiİptalEt.Cursor = Cursors.Hand;
            İslemiİptalEt.FlatAppearance.BorderSize = 3;
            İslemiİptalEt.FlatStyle = FlatStyle.Flat;
            İslemiİptalEt.Font = new Font("Candara", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            İslemiİptalEt.ForeColor = Color.Red;
            İslemiİptalEt.Location = new Point(443, 196);
            İslemiİptalEt.Name = "İslemiİptalEt";
            İslemiİptalEt.Size = new Size(55, 80);
            İslemiİptalEt.TabIndex = 32;
            İslemiİptalEt.Text = "İşlemi İptal Et";
            İslemiİptalEt.UseVisualStyleBackColor = true;
            İslemiİptalEt.Click += İslemiİptalEt_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 25);
            panel1.TabIndex = 33;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // ChangeTimeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.SignUpBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(500, 618);
            Controls.Add(panel1);
            Controls.Add(İslemiİptalEt);
            Controls.Add(saatleriKaydet);
            Controls.Add(saatleriGoruntule);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChangeTimeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += SaatDeğiştirme_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel saatleriGoruntule;
        private Button saatleriKaydet;
        private Button İslemiİptalEt;
        private Panel panel1;
    }
}