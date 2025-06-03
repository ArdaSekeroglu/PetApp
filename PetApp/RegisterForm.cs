using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PetApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            kytOlbtn.Enabled = false;
            kytIsimGir.TextChanged += TextBox_TextChanged!;
            kytSoyisimGir.TextChanged += TextBox_TextChanged!;
            kytKulAdiGir.TextChanged += TextBox_TextChanged!;
            kytEpostaGir.TextChanged += TextBox_TextChanged!;
            kytSifreGir.TextChanged += TextBox_TextChanged!;
            kytSifreGir.UseSystemPasswordChar = true;
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
        private void KayitOl_Load(object sender, EventArgs e)
        {
            HataLabel.Visible = false;
        }
        private void kytOlbtn_Click(object sender, EventArgs e)
        {
            string name = kytIsimGir.Text.Trim();
            string surname = kytSoyisimGir.Text.Trim();
            string account_name = kytKulAdiGir.Text.Trim();
            string eposta = kytEpostaGir.Text.Trim();
            string password = kytSifreGir.Text.Trim();
            string telefon_no = kytTelNoGir.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(account_name) ||
                string.IsNullOrWhiteSpace(eposta) ||
                string.IsNullOrWhiteSpace(password))
                if (!eposta.Contains("@") || !(eposta.EndsWith(".com") || eposta.EndsWith(".net") || eposta.EndsWith(".org")))
                {
                    HataLabel.Text = "E-posta geçerli formatta olmalı (@ ve .com, .net, .org vb.)";
                    HataLabel.Visible = true;
                    return;
                }
            HataLabel.Visible = false;
            TempUser.Isim = name;
            TempUser.Soyisim = surname;
            TempUser.KullaniciAdi = account_name;
            TempUser.Sifre = password;
            TempUser.Eposta = eposta;
            TempUser.TelefonNo = telefon_no;
            this.Hide();
            AddUserImageForm resimForm = new AddUserImageForm(this);
            resimForm.ShowDialog();
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool isFormValid = !string.IsNullOrWhiteSpace(kytIsimGir.Text) &&
                               !string.IsNullOrWhiteSpace(kytSoyisimGir.Text) &&
                               !string.IsNullOrWhiteSpace(kytKulAdiGir.Text) &&
                               !string.IsNullOrWhiteSpace(kytEpostaGir.Text) &&
                               !string.IsNullOrWhiteSpace(kytSifreGir.Text);

            kytOlbtn.Enabled = isFormValid;
        }
        private void kytIsimGir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void kytSoyisimGir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void kytEpostaGir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != '@' &&
                e.KeyChar != '.' &&
                !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void İslemiİptalEt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

