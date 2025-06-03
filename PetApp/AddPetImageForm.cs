using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using MySql.Data.MySqlClient;

namespace PetApp
{
    public partial class AddPetImageForm : Form
    {
        public AddPetImageForm()
        {
            InitializeComponent();
        }
        private void DostResmiEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DostResmiEkle.Image = Image.FromFile(ofd.FileName);
                DostResmiEkle.SizeMode = PictureBoxSizeMode.StretchImage;
                using (MemoryStream ms = new MemoryStream())
                {
                    DostResmiEkle.Image.Save(ms, DostResmiEkle.Image.RawFormat);
                    HayvanTemp.Resim = ms.ToArray();
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
        private void HyvnKaydetbtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string getSpeciesIdQuery = "SELECT species_id FROM species WHERE species_name = @tur";
                    MySqlCommand getSpeciesCmd = new MySqlCommand(getSpeciesIdQuery, conn);
                    getSpeciesCmd.Parameters.AddWithValue("@tur", HayvanTemp.Tur);
                    object speciesIdResult = getSpeciesCmd.ExecuteScalar();
                    if (speciesIdResult == null)
                    {
                        return;
                    }

                    int speciesId = Convert.ToInt32(speciesIdResult);
                    int? breedId = null;

                    if (!string.IsNullOrWhiteSpace(HayvanTemp.Irk))
                    {
                        string getBreedQuery = "SELECT breed_id FROM breeds WHERE breed_name = @breedName AND species_id = @speciesId";
                        MySqlCommand getBreedCmd = new MySqlCommand(getBreedQuery, conn);
                        getBreedCmd.Parameters.AddWithValue("@breedName", HayvanTemp.Irk);
                        getBreedCmd.Parameters.AddWithValue("@speciesId", speciesId);
                        object? breedIdObj = getBreedCmd.ExecuteScalar();
                        if (breedIdObj != null)
                        {
                            breedId = Convert.ToInt32(breedIdObj);
                        }
                        else
                        {
                            string insertBreedQuery = "INSERT INTO breeds (species_id, breed_name) VALUES (@speciesId, @breedName)";
                            MySqlCommand insertBreedCmd = new MySqlCommand(insertBreedQuery, conn);
                            insertBreedCmd.Parameters.AddWithValue("@speciesId", speciesId);
                            insertBreedCmd.Parameters.AddWithValue("@breedName", HayvanTemp.Irk);
                            insertBreedCmd.ExecuteNonQuery();
                            breedId = (int)insertBreedCmd.LastInsertedId;
                        }
                    }

                    string insertPetQuery = "INSERT INTO pets (pOwner, pName, pAge, species_id, breed_id, gender) " +
                                            "VALUES (@owner, @name, @age, @species, @breed, @gender)";
                    MySqlCommand insertPetCmd = new MySqlCommand(insertPetQuery, conn);
                    insertPetCmd.Parameters.AddWithValue("@owner", TempUser.KullaniciId);
                    insertPetCmd.Parameters.AddWithValue("@name", HayvanTemp.Isim);
                    insertPetCmd.Parameters.AddWithValue("@age", HayvanTemp.Yas);
                    insertPetCmd.Parameters.AddWithValue("@species", speciesId);
                    insertPetCmd.Parameters.AddWithValue("@breed", breedId.HasValue ? breedId : DBNull.Value);
                    insertPetCmd.Parameters.AddWithValue("@gender", HayvanTemp.PetCinsiyet);
                    insertPetCmd.ExecuteNonQuery();

                    long petId = insertPetCmd.LastInsertedId;
                    if (HayvanTemp.Resim != null)
                    {
                        string updateImageQuery = "UPDATE pets SET pet_images = @img WHERE pet_id = @pid";
                        MySqlCommand updateImageCmd = new MySqlCommand(updateImageQuery, conn);
                        updateImageCmd.Parameters.AddWithValue("@img", HayvanTemp.Resim);
                        updateImageCmd.Parameters.AddWithValue("@pid", petId);
                        updateImageCmd.ExecuteNonQuery();
                    }
                    HayvanTemp.Sifirla();
                    this.Close();
                    new SelectPetForm().Show();
                }
                catch (Exception) { }
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
            PetInfoEntryForm dostBilgiGir = new PetInfoEntryForm(HayvanTemp.Tur);
            dostBilgiGir.Show();
            this.Close();
        }
    }
}