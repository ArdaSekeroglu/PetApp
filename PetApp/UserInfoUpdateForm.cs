using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PetApp
{
    public partial class UserInfoUpdateForm : Form
    {
        public UserInfoUpdateForm()
        {
            InitializeComponent();
        }

        private void KulBilgiGuncelle_Load(object sender, EventArgs e)
        {
            mevcutSifreTxt.TextChanged += SifreKontrolleriYap;
            yeniSifreTxt.TextChanged += SifreKontrolleriYap;
            yeniSifreTekrarTxt.TextChanged += SifreKontrolleriYap;
            SifreDegis.BringToFront();
            kytIsimGir.Text = TempUser.Isim ?? "";
            kytSoyisimGir.Text = TempUser.Soyisim ?? "";
            kytKulAdiGir.Text = TempUser.KullaniciAdi ?? "";
            mevcutSifreTxt.Text = "";
            kytEpostaGir.Text = TempUser.Eposta ?? "";
            kytTelNoGir.Text = TempUser.TelefonNo ?? "";
            HataLabel1.Text = "";
            if (TempUser.ResimEkle == null)
            {
                string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT image_data FROM users WHERE user_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", TempUser.KullaniciId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            TempUser.ResimEkle = (byte[])result;
                            using (MemoryStream ms = new MemoryStream(TempUser.ResimEkle))
                            {
                                using (Image orijinal = Image.FromStream(ms))
                                {
                                    Bitmap kopya = new Bitmap(orijinal);
                                    KulResmiEkle.Image = kopya;
                                    KulResmiEkle.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(TempUser.ResimEkle))
                {
                    using (Image orijinal = Image.FromStream(ms))
                    {
                        Bitmap kopya = new Bitmap(orijinal);
                        KulResmiEkle.Image = kopya;
                        KulResmiEkle.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
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
        public bool AnaMenudenMiGeldim { get; set; } = false;

        private void SifreKontrolleriYap(object sender, EventArgs e)
        {
            SifreKontrolleriGecerliMi();
        }
        private bool SifreKontrolleriGecerliMi()
        {
            string mevcutGirilen = mevcutSifreTxt.Text.Trim();
            string mevcutGercek = TempUser.Sifre;
            string yeniSifre = yeniSifreTxt.Text.Trim();
            string yeniSifreTekrar = yeniSifreTekrarTxt.Text.Trim();
            bool herhangiBiriDolu =
                !string.IsNullOrEmpty(mevcutGirilen) ||
                !string.IsNullOrEmpty(yeniSifre) ||
                !string.IsNullOrEmpty(yeniSifreTekrar);
            if (!herhangiBiriDolu)
            {
                KaydetForKulDuzenle.Enabled = true;
                HataLabel1.Text = "";
                HataLabel1.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(mevcutGirilen) ||
                string.IsNullOrEmpty(yeniSifre) ||
                string.IsNullOrEmpty(yeniSifreTekrar))
            {
                KaydetForKulDuzenle.Enabled = false;
                HataLabel1.Text = "";
                HataLabel1.ForeColor = Color.Red;
                HataLabel1.Visible = true;
                return false;
            }
            if (mevcutGirilen != mevcutGercek)
            {
                KaydetForKulDuzenle.Enabled = false;
                HataLabel1.Text = "Mevcut şifre hatalı!";
                HataLabel1.ForeColor = Color.Red;
                HataLabel1.Visible = true;
                return false;
            }
            if (yeniSifre != yeniSifreTekrar)
            {
                KaydetForKulDuzenle.Enabled = false;
                HataLabel1.Text = "Yeni şifreler uyuşmuyor!";
                HataLabel1.ForeColor = Color.Red;
                HataLabel1.Visible = true;
                return false;
            }
            HataLabel1.Text = "";
            return true;
        }
        private void KaydetForKulDuzenle_Click(object sender, EventArgs e)
        {
            string isim = kytIsimGir.Text.Trim();
            string soyisim = kytSoyisimGir.Text.Trim();
            string kullaniciAdi = kytKulAdiGir.Text.Trim();
            string eposta = kytEpostaGir.Text.Trim();
            string telefon = kytTelNoGir.Text.Trim();
            byte[]? resim = null;
            if (!eposta.Contains("@") ||
                !(eposta.EndsWith(".com") || eposta.EndsWith(".net") || eposta.EndsWith(".org")))
            {
                HataLabel.Text = "E-posta geçerli formatta olmalı (@ ve .com, .net, .org vb.)";
                HataLabel.Visible = true;
                return;
            }
            else
            {
                HataLabel.Visible = false;
            }
            if (KulResmiEkle.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    KulResmiEkle.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    resim = ms.ToArray();
                    TempUser.ResimEkle = resim;
                }
            }
            string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string updateQuery = @"UPDATE users 
                SET name = @name, surname = @surname, account_name = @account, 
                eposta = @eposta, phone_no = @phone, image_data = @img 
                WHERE user_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@name", isim);
                    cmd.Parameters.AddWithValue("@surname", soyisim);
                    cmd.Parameters.AddWithValue("@account", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@eposta", eposta);
                    cmd.Parameters.AddWithValue("@phone", telefon);
                    if (resim == null)
                        cmd.Parameters.AddWithValue("@img", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@img", resim);
                    cmd.Parameters.AddWithValue("@id", TempUser.KullaniciId);
                    cmd.ExecuteNonQuery();
                }
            }
            TempUser.Isim = isim;
            TempUser.Soyisim = soyisim;
            TempUser.KullaniciAdi = kullaniciAdi;
            TempUser.Eposta = eposta;
            TempUser.TelefonNo = telefon;
            this.Close();
            if (AnaMenudenMiGeldim)
                new MainMenuForm().Show();
            else
                new SelectPetForm().Show();
        }
        private void KulResmiEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Profil Fotoğrafı Seç";
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image secilenResim = Image.FromFile(ofd.FileName);
                    KulResmiEkle.Image = secilenResim;
                    KulResmiEkle.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch { }
            }
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
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void İslemiİptalEt_Click(object sender, EventArgs e)
        {
            this.Close();
            if (AnaMenudenMiGeldim)
                new MainMenuForm().Show();
            else
                new SelectPetForm().Show();

        }
        private void sifreGoster_Click(object sender, EventArgs e)
        {
            mevcutSifreTxt.UseSystemPasswordChar = false;
            yeniSifreTxt.UseSystemPasswordChar = false;
            yeniSifreTekrarTxt.UseSystemPasswordChar = false;
            sifreGoster.Visible = false;
            sifreGizle.Visible = true;
        }

        private void sifreGizle_Click(object sender, EventArgs e)
        {
            mevcutSifreTxt.UseSystemPasswordChar = true;
            yeniSifreTxt.UseSystemPasswordChar = true;
            yeniSifreTekrarTxt.UseSystemPasswordChar = true;
            sifreGizle.Visible = false;
            sifreGoster.Visible = true;
        }

        private void SifreDegis_Click(object sender, EventArgs e)
        {
            sifrepanel.Visible = true;
            SifreDegis.Visible = false;
        }

        private void sifreVazgec_Click(object sender, EventArgs e)
        {
           sifrepanel.Visible = false;
           SifreDegis.Visible = true;
        }
        private void sifreKaydet_Click(object sender, EventArgs e)
        {
            if (!SifreKontrolleriGecerliMi()) return;
            string yeniSifre = yeniSifreTxt.Text.Trim();
            try
            {
                string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE users SET password = @sifre WHERE user_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sifre", yeniSifre);
                        cmd.Parameters.AddWithValue("@id", TempUser.KullaniciId);
                        cmd.ExecuteNonQuery();
                    }
                }
                TempUser.Sifre = yeniSifre;
                HataLabel1.Text = "Şifre başarıyla güncellendi!";
                HataLabel1.ForeColor = Color.LimeGreen;
            }
            catch
            {
                HataLabel1.Text = "Şifre güncellenirken hata oluştu.";
                HataLabel1.ForeColor = Color.Red;
                return;
            }
            sifrepanel.Visible = false;
            SifreDegis.Visible = true;
            KaydetForKulDuzenle.Enabled = true;
        }
    }
}