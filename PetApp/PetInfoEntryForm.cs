using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PetApp
{
    public partial class PetInfoEntryForm : Form
    {
        private string? secilenTur;

        public PetInfoEntryForm(string tur)
        {
            InitializeComponent();
            secilenTur = tur;
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
        private void bilgilerBtn_Click(object sender, EventArgs e)
        {
            string isim = HyvnIsimGir.Text.Trim();
            string yasText = HyvnYasGir.Text.Trim();
            string irk = HyvnIrkGir.Text.Trim();
            string? secilenCinsiyet = CinsiyetcomboBox.SelectedItem?.ToString();
            HayvanTemp.PetCinsiyet = string.IsNullOrEmpty(secilenCinsiyet) ? "Bilinmiyor" : secilenCinsiyet;
            if (string.IsNullOrWhiteSpace(isim))
                return;
            if (string.IsNullOrWhiteSpace(yasText))
            {
                HayvanTemp.Yas = null;
            }
            else if (int.TryParse(yasText, out int yas))
            {
                if (yas >= 50)
                {
                    HataLabel.Text = "Gerçekçi bir yaş giriniz (50 yaş altı).";
                    HataLabel.Visible = true;
                    return;
                }
                HayvanTemp.Yas = yas;
            }
            else
            {
                HataLabel.Text = "Yaş geçersiz!";
                HataLabel.Visible = true;
                return;
            }
            HataLabel.Visible = false;
            HayvanTemp.Isim = isim;
            HayvanTemp.Irk = string.IsNullOrWhiteSpace(irk) ? "Bilinmiyor" : irk;
            HayvanTemp.Tur = secilenTur;
            AddPetImageForm hayvanResmiEkleme = new AddPetImageForm();
            hayvanResmiEkleme.Show();
            this.Hide();
        }
        private void HyvnYasGir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (sender is TextBox tb)
            {
                if (!char.IsControl(e.KeyChar) && tb.Text.Length >= 2)
                {
                    e.Handled = true;
                }
            }
        }
        private void HyvnIsimGir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void HyvnIrkGir_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }    
        private void İslemiİptalEt_Click(object sender, EventArgs e)
        {
            SelectPetForm dostSec = new SelectPetForm();
            dostSec.Show();
            this.Close();
        }
        private void GeriDonButton_Click(object sender, EventArgs e)
        {
            HayvanTemp.Sifirla();
            AddPetForm dostEkle = new AddPetForm();
            dostEkle.Show();
            this.Close();
        }
    }
}