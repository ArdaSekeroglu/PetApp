using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PetApp
{
    public partial class RemovePetForm : Form
    {
        public RemovePetForm()
        {
            InitializeComponent();
            this.Load += HayvanKaldir_Load;
        }
        private void HayvanKaldir_Load(object? sender, EventArgs e)
        {
            HayvanlariYukle();
        }
        int sayfaNumarasi = 0;
        int sayfaBoyutu = 3;

        private void HayvanlariYukle()
        {
            EklenenHayvanlar.Controls.Clear();
            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            string query = "SELECT pet_id, pName, pAge, pet_images FROM pets WHERE pOwner = @userId ORDER BY pName ASC LIMIT @limit OFFSET @offset";

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
                        int petId = Convert.ToInt32(reader["pet_id"]);
                        string isim = reader["pName"].ToString() ?? "";

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
                            Location = new Point(10, 40),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Cursor = Cursors.Default
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
                            Location = new Point(0, 33),
                            BackColor = Color.Gold,
                            BorderStyle = BorderStyle.None
                        };
                        Label lblIsim = new Label
                        {
                            Text = isim,
                            AutoSize = false,
                            Width = hayvanPanel.Width,
                            Height = 30,
                            Location = new Point(0, 230),
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = Color.Gold
                        };
                        Button silBtn = new Button
                        {
                            Text = "X",
                            Size = new Size(20, 21),
                            Location = new Point(180, 9),
                            BackgroundImage = Properties.Resources.NavyBlueHorizontalRectangle,
                            ForeColor = Color.Red,
                            FlatStyle = FlatStyle.Flat,
                            Cursor = Cursors.Hand,
                            Tag = hayvanPanel
                        };
                        silBtn.FlatAppearance.BorderSize = 0;
                        silBtn.Click += SilBtn_Click;
                        hayvanPanel.Controls.Add(pb);
                        hayvanPanel.Controls.Add(lblIsim);
                        hayvanPanel.Controls.Add(silBtn);
                        hayvanPanel.Controls.Add(goldBorder);
                        EklenenHayvanlar.Controls.Add(hayvanPanel);
                    }
                }
            }
            SayfaButonlariniGuncelle();
        }
        private void SilBtn_Click(object sender, EventArgs e)
        {
            Button silBtn = (Button)sender;
            Panel hayvanPanel = (Panel)silBtn.Tag!;
            int petId = (int)hayvanPanel.Tag!;
            DeleteConfirmationBox kutu = new DeleteConfirmationBox(petId);
            DialogResult sonuc = kutu.ShowDialog();

            if (sonuc == DialogResult.OK)
            {
                EklenenHayvanlar.Controls.Remove(hayvanPanel);
                HayvanlariYukle();
            }
        }
        private void SayfaButonlariniGuncelle()
        {
            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
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
        private void minimizedButtonForChoosePet_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            SelectPetForm hayvanSec = new SelectPetForm();
            hayvanSec.Show();
            this.Close();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
