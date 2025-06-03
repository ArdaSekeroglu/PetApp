using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PetApp
{
    public partial class AddPetForm : Form
    {
        public AddPetForm()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void Kedi_Click(object sender, EventArgs e)
        {
            HayvanTemp.Tur = "Kedi";
            HayvanTemp.TurId = 1;
            PetInfoEntryForm hayvanBilgileriGir = new PetInfoEntryForm("Kedi");
            hayvanBilgileriGir.Show();
            this.Hide();
        }
        private void Kopek_click(object sender, EventArgs e)
        {
            HayvanTemp.Tur = "Köpek";
            HayvanTemp.TurId = 2;
            PetInfoEntryForm hayvanBilgileriGir = new PetInfoEntryForm("Köpek");
            hayvanBilgileriGir.Show();
            this.Hide();
        }
        private void Kus_Click(object sender, EventArgs e)
        {
            HayvanTemp.Tur = "Kuş";
            HayvanTemp.TurId = 3;
            PetInfoEntryForm hayvanBilgileriGir = new PetInfoEntryForm("Kuş");
            hayvanBilgileriGir.Show();
            this.Hide();
        }
        private void Balik_click(object sender, EventArgs e)
        {
            HayvanTemp.Tur = "Balık";
            HayvanTemp.TurId = 4;
            PetInfoEntryForm hayvanBilgileriGir = new PetInfoEntryForm("Balık");
            hayvanBilgileriGir.Show();
            this.Hide();
        }
        private void Yilan_click(object sender, EventArgs e)
        {
            HayvanTemp.Tur = "Yılan";
            HayvanTemp.TurId = 5;
            PetInfoEntryForm hayvanBilgileriGir = new PetInfoEntryForm("Yılan");
            hayvanBilgileriGir.Show();
            this.Hide();
        }
        private void Orumcek_click(object sender, EventArgs e)
        {
            HayvanTemp.Tur = "Örümcek";
            HayvanTemp.TurId = 6;
            PetInfoEntryForm hayvanBilgileriGir = new PetInfoEntryForm("Örümcek");
            hayvanBilgileriGir.Show();
            this.Hide();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            HayvanTemp.Sifirla();
            SelectPetForm hayvanSec = new SelectPetForm();
            hayvanSec.Show();
            this.Close();
        }
    }
}