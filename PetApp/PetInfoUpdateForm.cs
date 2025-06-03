using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PetApp
{
    public partial class PetInfoUpdateForm : Form
    {
        public PetInfoUpdateForm()
        {
            InitializeComponent();
        }

        private void DostBilgiGüncelle_Load(object sender, EventArgs e)
        {
            HataLabel.Visible = false;

            string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"
                SELECT p.pName, p.pAge, p.gender, p.pet_images, b.breed_name
                FROM pets p
                LEFT JOIN breeds b ON p.breed_id = b.breed_id
                WHERE p.pet_id = @petId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@petId", HayvanTemp.PetId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        HyvnIsimGir.Text = reader.GetString("pName");
                        HyvnYasGir.Text = reader.IsDBNull(reader.GetOrdinal("pAge"))
                            ? ""
                            : reader.GetInt32(reader.GetOrdinal("pAge")).ToString();
                        CinsiyetcomboBox.Text = reader.GetString("gender");
                        HyvnIrkGir.Text = reader.IsDBNull(reader.GetOrdinal("breed_name")) ? "" : reader.GetString("breed_name");

                        if (!reader.IsDBNull(reader.GetOrdinal("pet_images")))
                        {
                            byte[] imgBytes = (byte[])reader["pet_images"];
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                DostResmiEkle.Image = Image.FromStream(ms);
                                DostResmiEkle.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                }
            }
            HyvnIsimGir.KeyPress += HyvnIsimGir_KeyPress!;
            HyvnYasGir.KeyPress += HyvnYasGir_KeyPress!;
            HyvnIrkGir.KeyPress += HyvnIrkGir_KeyPress!;
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
        private void KaydetForDostDuzenle_Click(object sender, EventArgs e)
        {
            string isim = HyvnIsimGir.Text.Trim();
            string yasText = HyvnYasGir.Text.Trim();
            string irk = HyvnIrkGir.Text.Trim();
            string secilenCinsiyet = CinsiyetcomboBox.SelectedItem?.ToString() ?? "Bilinmiyor";
            byte[]? foto = null;
            if (string.IsNullOrWhiteSpace(isim))
                return;
            if (!int.TryParse(yasText, out int yas))
            {
                HataLabel.Text = "Yaş geçersiz!";
                HataLabel.Visible = true;
                return;
            }
            if (yas >= 50)
            {
                HataLabel.Text = "Gerçekçi bir yaş giriniz (50 yaş altı).";
                HataLabel.Visible = true;
                return;
            }
            HataLabel.Visible = false;
            if (DostResmiEkle.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    DostResmiEkle.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    foto = ms.ToArray();
                }
            }
            int? breedId = null;
            string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                if (!string.IsNullOrWhiteSpace(irk) && HayvanTemp.TurId != null)
                {
                    string breedCheckQuery = "SELECT breed_id FROM breeds WHERE breed_name = @breedName AND species_id = @speciesId";
                    using (MySqlCommand checkCmd = new MySqlCommand(breedCheckQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@breedName", irk);
                        checkCmd.Parameters.AddWithValue("@speciesId", HayvanTemp.TurId);
                        object? result = checkCmd.ExecuteScalar();
                        if (result != null)
                        {
                            breedId = Convert.ToInt32(result);
                        }
                        else
                        {
                            string insertBreedQuery = "INSERT INTO breeds (species_id, breed_name) VALUES (@speciesId, @breedName)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertBreedQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@speciesId", HayvanTemp.TurId);
                                insertCmd.Parameters.AddWithValue("@breedName", irk);
                                insertCmd.ExecuteNonQuery();
                                breedId = (int)insertCmd.LastInsertedId;
                            }
                        }
                    }
                }
                string updateQuery = @"UPDATE pets 
                SET pName = @name, pAge = @age, gender = @gender, breed_id = @breedId, pet_images = @img 
                WHERE pet_id = @petId";
                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@name", isim);
                    updateCmd.Parameters.AddWithValue("@age", yas);
                    updateCmd.Parameters.AddWithValue("@gender", secilenCinsiyet);
                    updateCmd.Parameters.AddWithValue("@breedId", breedId.HasValue ? breedId : DBNull.Value);
                    updateCmd.Parameters.AddWithValue("@img", foto != null ? foto : (object)DBNull.Value);
                    updateCmd.Parameters.AddWithValue("@petId", HayvanTemp.PetId);
                    updateCmd.ExecuteNonQuery();
                }
                MainMenuForm anaMenü = new MainMenuForm();
                anaMenü.Show();
                this.Close();
            }
        }
        private void DostResmiEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Hayvan Fotoğrafı Seç";
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image secilenResim = Image.FromFile(ofd.FileName);
                    DostResmiEkle.Image = secilenResim;
                    DostResmiEkle.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch { }
            }
        }
        private void HyvnIsimGir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }
        private void HyvnYasGir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (sender is TextBox tb && !char.IsControl(e.KeyChar) && tb.Text.Length >= 2)
            {
                e.Handled = true;
            }
        }
        private void HyvnIrkGir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }
        private void İslemiİptalEt_Click(object sender, EventArgs e)
        {
            MainMenuForm anaMenü = new MainMenuForm();
            anaMenü.Show();
            this.Close();
        }
    }
}
