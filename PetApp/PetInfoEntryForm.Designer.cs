namespace PetApp
{
    partial class PetInfoEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PetInfoEntryForm));
            panel1 = new Panel();
            HyvnIsimGir = new TextBox();
            HyvnIrkGir = new TextBox();
            bilgilerBtn = new Button();
            HyvnYasGir = new TextBox();
            HataLabel = new Label();
            CinsiyetcomboBox = new ComboBox();
            İslemiİptalEt = new Button();
            GeriDonButton = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.Transparent;
            panel1.Name = "panel1";
            panel1.MouseDown += panel1_MouseDown;
            // 
            // HyvnIsimGir
            // 
            resources.ApplyResources(HyvnIsimGir, "HyvnIsimGir");
            HyvnIsimGir.BackColor = Color.White;
            HyvnIsimGir.BorderStyle = BorderStyle.FixedSingle;
            HyvnIsimGir.Cursor = Cursors.IBeam;
            HyvnIsimGir.ForeColor = Color.Black;
            HyvnIsimGir.Name = "HyvnIsimGir";
            HyvnIsimGir.Tag = "";
            HyvnIsimGir.KeyPress += HyvnIsimGir_KeyPress;
            // 
            // HyvnIrkGir
            // 
            resources.ApplyResources(HyvnIrkGir, "HyvnIrkGir");
            HyvnIrkGir.BackColor = Color.White;
            HyvnIrkGir.BorderStyle = BorderStyle.FixedSingle;
            HyvnIrkGir.Cursor = Cursors.IBeam;
            HyvnIrkGir.ForeColor = Color.Black;
            HyvnIrkGir.Name = "HyvnIrkGir";
            HyvnIrkGir.KeyPress += HyvnIrkGir_KeyPress;
            // 
            // bilgilerBtn
            // 
            resources.ApplyResources(bilgilerBtn, "bilgilerBtn");
            bilgilerBtn.BackColor = Color.Red;
            bilgilerBtn.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            bilgilerBtn.Cursor = Cursors.Hand;
            bilgilerBtn.FlatAppearance.BorderSize = 3;
            bilgilerBtn.ForeColor = Color.White;
            bilgilerBtn.Name = "bilgilerBtn";
            bilgilerBtn.UseVisualStyleBackColor = false;
            bilgilerBtn.Click += bilgilerBtn_Click;
            // 
            // HyvnYasGir
            // 
            resources.ApplyResources(HyvnYasGir, "HyvnYasGir");
            HyvnYasGir.BackColor = Color.White;
            HyvnYasGir.BorderStyle = BorderStyle.FixedSingle;
            HyvnYasGir.Cursor = Cursors.IBeam;
            HyvnYasGir.ForeColor = Color.Black;
            HyvnYasGir.Name = "HyvnYasGir";
            HyvnYasGir.Tag = "";
            HyvnYasGir.KeyPress += HyvnYasGir_KeyPress;
            // 
            // HataLabel
            // 
            resources.ApplyResources(HataLabel, "HataLabel");
            HataLabel.BackColor = Color.Transparent;
            HataLabel.ForeColor = Color.Red;
            HataLabel.Name = "HataLabel";
            // 
            // CinsiyetcomboBox
            // 
            resources.ApplyResources(CinsiyetcomboBox, "CinsiyetcomboBox");
            CinsiyetcomboBox.BackColor = Color.White;
            CinsiyetcomboBox.Cursor = Cursors.IBeam;
            CinsiyetcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CinsiyetcomboBox.ForeColor = Color.Black;
            CinsiyetcomboBox.FormattingEnabled = true;
            CinsiyetcomboBox.Items.AddRange(new object[] { resources.GetString("CinsiyetcomboBox.Items"), resources.GetString("CinsiyetcomboBox.Items1"), resources.GetString("CinsiyetcomboBox.Items2") });
            CinsiyetcomboBox.Name = "CinsiyetcomboBox";
            CinsiyetcomboBox.Tag = "";
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
            GeriDonButton.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            GeriDonButton.Cursor = Cursors.Hand;
            GeriDonButton.ForeColor = Color.Turquoise;
            GeriDonButton.Name = "GeriDonButton";
            GeriDonButton.UseVisualStyleBackColor = true;
            GeriDonButton.Click += GeriDonButton_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Gold;
            label2.Name = "label2";
            // 
            // PetInfoEntryForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.SignUpBackground;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GeriDonButton);
            Controls.Add(İslemiİptalEt);
            Controls.Add(CinsiyetcomboBox);
            Controls.Add(HataLabel);
            Controls.Add(HyvnYasGir);
            Controls.Add(bilgilerBtn);
            Controls.Add(HyvnIrkGir);
            Controls.Add(HyvnIsimGir);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PetInfoEntryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private TextBox HyvnIsimGir;
        private TextBox HyvnIrkGir;
        private Button bilgilerBtn;
        private TextBox HyvnYasGir;
        private Label HataLabel;
        private ComboBox CinsiyetcomboBox;
        private Button İslemiİptalEt;
        private Button GeriDonButton;
        private Label label1;
        private Label label2;
    }
}