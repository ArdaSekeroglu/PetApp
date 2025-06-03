using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace PetApp
{
    public partial class AddUserImageForm : Form
    {
        private RegisterForm kayitOlForm;
        public AddUserImageForm(RegisterForm kayitOlForm)
        {
            InitializeComponent();
            this.kayitOlForm = kayitOlForm;
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
        private void resimEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = ofd.FileName;
                resimEkle.Image = Image.FromFile(dosyaYolu);
                resimEkle.SizeMode = PictureBoxSizeMode.StretchImage;
                TempUser.ResimEkle = File.ReadAllBytes(dosyaYolu);
            }
        }

        private void verileriSil_Click(object sender, EventArgs e)
        {
            TempUser.Sifirla();
            this.Close();
        }
        private void kaydiBitir_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            byte[]? imageData = null;
            if (resimEkle.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    resimEkle.Image.Save(ms, resimEkle.Image.RawFormat);
                    imageData = ms.ToArray();
                }
            }
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO users (name, surname, account_name, password, eposta, phone_no, image_data) " +
                                         "VALUES (@name, @surname, @account_name, @password, @eposta, @phone_no, @image_data)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@name", TempUser.Isim);
                    cmd.Parameters.AddWithValue("@surname", TempUser.Soyisim);
                    cmd.Parameters.AddWithValue("@account_name", TempUser.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@password", TempUser.Sifre);
                    cmd.Parameters.AddWithValue("@eposta", TempUser.Eposta);
                    cmd.Parameters.AddWithValue("@phone_no", string.IsNullOrWhiteSpace(TempUser.TelefonNo) ? (object)DBNull.Value : TempUser.TelefonNo);
                    cmd.Parameters.AddWithValue("@image_data", imageData ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                    TempUser.KullaniciId = (int)cmd.LastInsertedId;
                    TempUser.Sifirla();
                    kayitOlForm?.Close();
                    this.Close();
                }
                catch (Exception){}
            }
        }
        private void basaDön_Click(object sender, EventArgs e)
        {
            this.Close();
            kayitOlForm?.Show();
        }
    }
}
