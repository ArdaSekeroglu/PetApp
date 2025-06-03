namespace PetApp
{
    partial class AddPetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPetForm));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            panel1 = new Panel();
            closeButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = Color.Black;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = Color.Black;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Kedi_Click;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Cursor = Cursors.Hand;
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Kopek_click;
            // 
            // button3
            // 
            resources.ApplyResources(button3, "button3");
            button3.Cursor = Cursors.Hand;
            button3.Name = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Kus_Click;
            // 
            // button4
            // 
            resources.ApplyResources(button4, "button4");
            button4.Cursor = Cursors.Hand;
            button4.Name = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Balik_click;
            // 
            // button5
            // 
            resources.ApplyResources(button5, "button5");
            button5.Name = "button5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Yilan_click;
            // 
            // button6
            // 
            resources.ApplyResources(button6, "button6");
            button6.Cursor = Cursors.Hand;
            button6.Name = "button6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Orumcek_click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.Transparent;
            panel1.Name = "panel1";
            panel1.MouseDown += panel1_MouseDown;
            // 
            // closeButton
            // 
            resources.ApplyResources(closeButton, "closeButton");
            closeButton.BackColor = Color.Red;
            closeButton.BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle;
            closeButton.Cursor = Cursors.Hand;
            closeButton.ForeColor = Color.Red;
            closeButton.Name = "closeButton";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Gold;
            label1.Name = "label1";
            // 
            // AddPetForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(label1);
            Controls.Add(closeButton);
            Controls.Add(panel1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddPetForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Panel panel1;
        private Button closeButton;
        private Label label1;
    }
}