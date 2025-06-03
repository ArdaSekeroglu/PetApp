using System;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;

namespace PetApp
{
    public partial class SelectPetForm : Form
    {
        public SelectPetForm()
        {
            InitializeComponent();
            _currentVolume = Properties.Settings.Default.SavedVolume;
            btnVolUp.Click += btnVolUp_Click;
            btnVolDown.Click += btnVolDown_Click;
            tbVolume.Scroll += TbVolume_Scroll;
            tbVolume.ValueChanged += TbVolume_Scroll;
            this.Load += HayvanSec_Load;
        }
        private int _currentVolume;

        private void HayvanSec_Load(object? sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            _currentVolume = Properties.Settings.Default.SavedVolume;
            MusicPlayer.SetVolume(_currentVolume);
            if (!MusicPlayer.IsInitialized)
            {
                MusicPlayer.Start();
            }
            tbVolume.Minimum = 0;
            tbVolume.Maximum = 100;
            tbVolume.Value = _currentVolume;
            HayvanlariYukle();
        }
        int sayfaNumarasi = 0;
        private void HayvanlariYukle()
        {
            EklenenHayvanlar.Controls.Clear();
            int sayfaBoyutu = 3;
            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            string query = "SELECT pet_id, pName, pAge, pet_images, species_id FROM pets WHERE pOwner = @userId ORDER BY pName ASC LIMIT @limit OFFSET @offset";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", TempUser.KullaniciId);
                cmd.Parameters.AddWithValue("@limit", sayfaBoyutu);
                cmd.Parameters.AddWithValue("@offset", sayfaNumarasi * sayfaBoyutu);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string? isim = reader["pName"].ToString();
                        int petId = Convert.ToInt32(reader["pet_id"]);
                        int turId = Convert.ToInt32(reader["species_id"]);
                        Panel hayvanPanel = new Panel
                        {
                            Size = new Size(200, 350),
                            BorderStyle = BorderStyle.None,
                            BackColor = Color.Transparent,
                            Margin = new Padding(15),
                            Tag = petId
                        };
                        PictureBox pb = new PictureBox
                        {
                            Size = new Size(180, 180),
                            Location = new Point(10, 10),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Cursor = Cursors.Hand
                        };
                        if (!reader.IsDBNull(reader.GetOrdinal("pet_images")))
                        {
                            byte[] imgBytes = (byte[])reader["pet_images"];
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                pb.Image = Image.FromStream(ms);
                            }
                        }
                        Panel goldBorder = new Panel
                        {
                            Size = new Size(200, 200),
                            Location = new Point(0, 3),
                            BackColor = Color.Transparent,
                            BorderStyle = BorderStyle.None,
                            Cursor = Cursors.Arrow
                        };
                        goldBorder.Controls.Add(pb);
                        pb.Click += (s, e) =>
                        {
                            HayvanTemp.PetId = petId;
                            HayvanTemp.TurId = turId;
                            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
                            using (MySqlConnection conn = new MySqlConnection(connectionString))
                            {
                                conn.Open();
                                string turQuery = "SELECT species_name FROM species WHERE species_id = @speciesId";
                                using (MySqlCommand cmd = new MySqlCommand(turQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@speciesId", turId);
                                    object? result = cmd.ExecuteScalar();
                                    if (result != null)
                                    {
                                        HayvanTemp.Tur = result.ToString();
                                    }
                                }
                                string hayvanQuery = "SELECT pName, pAge, breed_id, gender, pet_images FROM pets WHERE pet_id = @petId";
                                using (MySqlCommand cmd = new MySqlCommand(hayvanQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@petId", petId);
                                    using (MySqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            HayvanTemp.Isim = reader["pName"].ToString();
                                            HayvanTemp.Yas = reader.IsDBNull(reader.GetOrdinal("pAge")) ? null : reader.GetInt32("pAge");
                                            HayvanTemp.PetCinsiyet = reader["gender"].ToString();
                                            if (!reader.IsDBNull(reader.GetOrdinal("pet_images")))
                                            {
                                                HayvanTemp.Resim = (byte[])reader["pet_images"];
                                            }
                                            if (!reader.IsDBNull(reader.GetOrdinal("breed_id")))
                                            {
                                                int breedId = reader.GetInt32("breed_id");
                                                reader.Close();
                                                string irkQuery = "SELECT breed_name FROM breeds WHERE breed_id = @breedId";
                                                using (MySqlCommand irkCmd = new MySqlCommand(irkQuery, conn))
                                                {
                                                    irkCmd.Parameters.AddWithValue("@breedId", breedId);
                                                    object? irkResult = irkCmd.ExecuteScalar();
                                                    HayvanTemp.Irk = irkResult?.ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            MainMenuForm anaMenu = new MainMenuForm();
                            anaMenu.Show();
                            this.Hide();
                        };
                        Label lblIsim = new Label
                        {
                            Text = isim ?? "",
                            AutoSize = false,
                            Width = hayvanPanel.Width,
                            Height = 30,
                            Location = new Point(0, 190),
                            Font = new Font("Candara", 14, FontStyle.Bold),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = Color.Transparent
                        };
                        hayvanPanel.Controls.Add(pb);
                        hayvanPanel.Controls.Add(lblIsim);
                        hayvanPanel.Controls.Add(goldBorder);
                        EklenenHayvanlar.Controls.Add(hayvanPanel);
                    }
                }
            }
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string countQuery = "SELECT COUNT(*) FROM pets WHERE pOwner = @userId";
                MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                countCmd.Parameters.AddWithValue("@userId", TempUser.KullaniciId);
                int toplamHayvan = Convert.ToInt32(countCmd.ExecuteScalar());
                int sonrakiSayfaIndex = (sayfaNumarasi + 1) * sayfaBoyutu;
                SonrakiSayfaBtn.Enabled = toplamHayvan > sonrakiSayfaIndex;
                OncekiSayfaBtn.Enabled = sayfaNumarasi > 0;
            }
        }
        private void minimizedButtonForChoosePet_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        private void hayvanEkle_Click(object sender, EventArgs e)
        {
            AddPetForm hayvanEkle = new AddPetForm();
            hayvanEkle.Show();
            this.Hide();
        }
        private void SonrakiSayfaBtn_Click(object sender, EventArgs e)
        {
            sayfaNumarasi++;
            HayvanlariYukle();
        }
        private void OncekiSayfaBtn_Click(object sender, EventArgs e)
        {
            if (sayfaNumarasi > 0)
                sayfaNumarasi--;

            HayvanlariYukle();
        }
        private void hayvanKaldir_Click(object sender, EventArgs e)
        {
            RemovePetForm hayvanKaldır = new RemovePetForm();
            hayvanKaldır.Show();
            this.Hide();
        }
        private void CikisYapBtn_Click(object sender, EventArgs e)
        {
            bool hatirlaAcikMi = Properties.Settings.Default.RememberMe;
            TempUser.Sifirla();
            Properties.Settings.Default.RememberMe = false;
            Properties.Settings.Default.SavedUserId = 0;
            Properties.Settings.Default.Save();

            var mevcutGirisFormu = Application.OpenForms.OfType<GirisSayfasi>().FirstOrDefault();
            if (mevcutGirisFormu == null)
            {
                GirisSayfasi yeniGiris = new GirisSayfasi();
                yeniGiris.Show();
            }
            else
            {
                mevcutGirisFormu.Show();
            }
            this.Hide();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AyarlarToggleButon_Click(object sender, EventArgs e)
        {
            CikisYapBtn.Visible = true;
            DuzenleForKullanici.Visible = true;
            AyarlarToggleButon.Visible = false;
            AyarlarToggleButon2.Visible = true;
            sesikapat.Visible = true;
        }
        private void AyarlarToggleButon2_Click(object sender, EventArgs e)
        {
            CikisYapBtn.Visible = false;
            DuzenleForKullanici.Visible = false;
            AyarlarToggleButon.Visible = true;
            AyarlarToggleButon2.Visible = false;
            sesikapat.Visible = false;
            sesiac.Visible = false;
            btnVolUp.Visible = false;
            btnVolDown.Visible = false;
        }
        private void DuzenleForKullanici_Click(object sender, EventArgs e)
        {
            UserInfoUpdateForm kulForm = new UserInfoUpdateForm();
            kulForm.Show();
            this.Hide();
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
        private void btnVolUp_Click(object sender, EventArgs e)
        {
            if (tbVolume.Value < tbVolume.Maximum)
            {
                tbVolume.Value = Math.Min(tbVolume.Value + 5, tbVolume.Maximum);
            }
        }

        private void btnVolDown_Click(object sender, EventArgs e)
        {
            if (tbVolume.Value > tbVolume.Minimum)
            {
                tbVolume.Value = Math.Max(tbVolume.Value - 5, tbVolume.Minimum);
            }
        }

        private void TbVolume_Scroll(object sender, EventArgs e)
        {
            _currentVolume = tbVolume.Value;
            MusicPlayer.SetVolume(_currentVolume);
            Properties.Settings.Default.SavedVolume = _currentVolume;
            Properties.Settings.Default.Save();
        }

        private void tbVolume_Scroll_2(object sender, EventArgs e)
        {

        }
    }
}

