using System.Runtime.InteropServices;

namespace PetApp
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            kytKulAdiGir = new TextBox();
            kytSoyisimGir = new TextBox();
            kytSifreGir = new TextBox();
            kytEpostaGir = new TextBox();
            panel1 = new Panel();
            kytIsimGir = new TextBox();
            kytOlbtn = new Button();
            kytTelNoGir = new MaskedTextBox();
            HataLabel = new Label();
            label1 = new Label();
            İslemiİptalEt = new Button();
            SuspendLayout();
            // 
            // kytKulAdiGir
            // 
            resources.ApplyResources(kytKulAdiGir, "kytKulAdiGir");
            kytKulAdiGir.BackColor = Color.White;
            kytKulAdiGir.BorderStyle = BorderStyle.None;
            kytKulAdiGir.Cursor = Cursors.IBeam;
            kytKulAdiGir.Name = "kytKulAdiGir";
            // 
            // kytSoyisimGir
            // 
            resources.ApplyResources(kytSoyisimGir, "kytSoyisimGir");
            kytSoyisimGir.BackColor = Color.White;
            kytSoyisimGir.BorderStyle = BorderStyle.None;
            kytSoyisimGir.Cursor = Cursors.IBeam;
            kytSoyisimGir.ForeColor = Color.Black;
            kytSoyisimGir.Name = "kytSoyisimGir";
            kytSoyisimGir.KeyPress += kytSoyisimGir_KeyPress;
            // 
            // kytSifreGir
            // 
            resources.ApplyResources(kytSifreGir, "kytSifreGir");
            kytSifreGir.BackColor = Color.White;
            kytSifreGir.BorderStyle = BorderStyle.None;
            kytSifreGir.Cursor = Cursors.IBeam;
            kytSifreGir.ForeColor = Color.Black;
            kytSifreGir.Name = "kytSifreGir";
            kytSifreGir.UseSystemPasswordChar = true;
            // 
            // kytEpostaGir
            // 
            resources.ApplyResources(kytEpostaGir, "kytEpostaGir");
            kytEpostaGir.BackColor = Color.White;
            kytEpostaGir.BorderStyle = BorderStyle.None;
            kytEpostaGir.Cursor = Cursors.IBeam;
            kytEpostaGir.ForeColor = Color.Black;
            kytEpostaGir.Name = "kytEpostaGir";
            kytEpostaGir.KeyPress += kytEpostaGir_KeyPress;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.Transparent;
            panel1.Name = "panel1";
            panel1.MouseDown += panel1_MouseDown;
            // 
            // kytIsimGir
            // 
            resources.ApplyResources(kytIsimGir, "kytIsimGir");
            kytIsimGir.BackColor = Color.White;
            kytIsimGir.BorderStyle = BorderStyle.None;
            kytIsimGir.Cursor = Cursors.IBeam;
            kytIsimGir.ForeColor = Color.Black;
            kytIsimGir.Name = "kytIsimGir";
            kytIsimGir.Tag = "";
            kytIsimGir.KeyPress += kytIsimGir_KeyPress;
            // 
            // kytOlbtn
            // 
            resources.ApplyResources(kytOlbtn, "kytOlbtn");
            kytOlbtn.BackColor = Color.White;
            kytOlbtn.Cursor = Cursors.Hand;
            kytOlbtn.FlatAppearance.BorderSize = 3;
            kytOlbtn.ForeColor = Color.White;
            kytOlbtn.Name = "kytOlbtn";
            kytOlbtn.UseVisualStyleBackColor = false;
            kytOlbtn.Click += kytOlbtn_Click;
            // 
            // kytTelNoGir
            // 
            resources.ApplyResources(kytTelNoGir, "kytTelNoGir");
            kytTelNoGir.BackColor = Color.White;
            kytTelNoGir.BorderStyle = BorderStyle.None;
            kytTelNoGir.Cursor = Cursors.IBeam;
            kytTelNoGir.Name = "kytTelNoGir";
            // 
            // HataLabel
            // 
            resources.ApplyResources(HataLabel, "HataLabel");
            HataLabel.BackColor = Color.Transparent;
            HataLabel.ForeColor = Color.Red;
            HataLabel.Name = "HataLabel";
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
            İslemiİptalEt.Click += İslemiİptalEt_Click;
            // 
            // RegisterForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(İslemiİptalEt);
            Controls.Add(label1);
            Controls.Add(HataLabel);
            Controls.Add(kytTelNoGir);
            Controls.Add(kytOlbtn);
            Controls.Add(panel1);
            Controls.Add(kytEpostaGir);
            Controls.Add(kytSifreGir);
            Controls.Add(kytSoyisimGir);
            Controls.Add(kytKulAdiGir);
            Controls.Add(kytIsimGir);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            Load += KayitOl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox kytKulAdiGir;
        private TextBox kytSoyisimGir;
        private TextBox kytSifreGir;
        private TextBox kytEpostaGir;
        private Panel panel1;
        private TextBox kytIsimGir;
        private Button kytOlbtn;
        private MaskedTextBox kytTelNoGir;

        private void kytSoyisimGir_TextChanged(object sender, EventArgs e)
        {
            
        }
        private Label HataLabel;
        private Label label1;
        private Button İslemiİptalEt;
    }
}
