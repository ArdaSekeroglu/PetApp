using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Data;

namespace PetApp
{
    public partial class GirisSayfasi : Form
    {
        private int _currentVolume;

        public GirisSayfasi()
        {
            InitializeComponent();

            _currentVolume = Properties.Settings.Default.SavedVolume;
            MusicPlayer.SetVolume(_currentVolume);
            if (!MusicPlayer.IsInitialized)
            {
                MusicPlayer.Start();
            }

            TempUser.Sifirla();
            HayvanTemp.Sifirla();

            tbVolume.Minimum = 0;
            tbVolume.Maximum = 100;
            tbVolume.Value = _currentVolume;
            tbVolume.ValueChanged += TbVolume_Scroll;
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void kaydol_Click(object sender, EventArgs e)
        {
            RegisterForm kayitOlFormu = new RegisterForm
            {
                StartPosition = FormStartPosition.CenterParent
            };
            kayitOlFormu.ShowDialog(this);
        }
        private void girisYap_Click(object sender, EventArgs e)
        {
            string accountName = kullaniciAdiGir.Text.Trim();
            string password = sifreGir.Text.Trim();
            if (string.IsNullOrEmpty(accountName) || string.IsNullOrEmpty(password))
            {
                HataLabel.Text = "Kullanýcý adý ve þifre boþ olamaz!";
                HataLabel.Visible = true;
                return;
            }
            string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    string query =
                      "SELECT * FROM users WHERE account_name = @account_name AND password = @password";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@account_name", accountName);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TempUser.KullaniciId = reader.GetInt32("user_id");
                            TempUser.Isim = reader.GetString("name");
                            TempUser.Soyisim = reader.GetString("surname");
                            TempUser.KullaniciAdi = reader.GetString("account_name");
                            TempUser.Sifre = password;
                            TempUser.Eposta = reader.GetString("eposta");
                            TempUser.TelefonNo = reader.IsDBNull(reader.GetOrdinal("phone_no"))
                                                       ? null
                                                       : reader.GetString("phone_no");
                            if (cbRememberMe.Checked)
                            {
                                Properties.Settings.Default.RememberMe = true;
                                Properties.Settings.Default.SavedUserId = TempUser.KullaniciId;
                            }
                            else
                            {
                                Properties.Settings.Default.RememberMe = false;
                                Properties.Settings.Default.SavedUserId = 0;
                            }
                            Properties.Settings.Default.Save();
                            this.Hide();
                            var hayvanSecFormu = new SelectPetForm();
                            hayvanSecFormu.Show();
                        }
                        else
                        {
                            HataLabel.Text = "Kullanýcý adý veya þifre hatalý!";
                            HataLabel.Visible = true;
                        }
                    }
                }
                catch (MySqlException) { }
                catch (Exception) { }
            }
        }
        private void kullaniciAdiGir_TextChanged(object sender, EventArgs e)
        {
            HataLabel.Visible = false;
        }
        private void sifreGir_TextChanged(object sender, EventArgs e)
        {
            HataLabel.Visible = false;
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
        private void btnVolUp_Click(object sender, EventArgs e)
        {
            tbVolume.Value = Math.Min(tbVolume.Value + 10, tbVolume.Maximum);
        }
        private void btnVolDown_Click(object sender, EventArgs e)
        {
            tbVolume.Value = Math.Max(tbVolume.Value - 10, tbVolume.Minimum);
        }
        private void TbVolume_Scroll(object sender, EventArgs e)
        {
            int vol = tbVolume.Value;
            _currentVolume = vol;
            MusicPlayer.SetVolume(vol);
            Properties.Settings.Default.SavedVolume = vol;
            Properties.Settings.Default.Save();
        }
        private void sesikapat_Click(object sender, EventArgs e)
        {
            sesikapat.Visible = false;
            sesiac.Visible = true;

            btnVolUp.Visible = true;
            btnVolDown.Visible = true;
        }

        private void sesiac_Click(object sender, EventArgs e)
        {
            sesiac.Visible = false;
            sesikapat.Visible = true;

            btnVolUp.Visible = false;
            btnVolDown.Visible = false;
        }
        private void sifreGoster_Click(object sender, EventArgs e)
        {
            sifreGir.UseSystemPasswordChar = false;
            sifreGoster.Visible = false;
            sifreGizle.Visible = true;
        }
        private void sifreGizle_Click(object sender, EventArgs e)
        {
            sifreGir.UseSystemPasswordChar = true;
            sifreGizle.Visible = false;
            sifreGoster.Visible = true;
        }
    }
}