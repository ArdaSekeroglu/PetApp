using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PetApp
{
    public partial class DeleteConfirmationBox : Form
    {
        private int _petId;
        public DeleteConfirmationBox(int petId)
        {
            InitializeComponent();
            _petId = petId;
        }
        private void EvetBtn_Click(object sender, EventArgs e)
        {
            SilPet(_petId);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void HayırBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void SilPet(int petId)
        {
            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string[] deleteQueries = new[]
                    {
                "DELETE FROM care_dog_cat WHERE pet_id = @id",
                "DELETE FROM care_fish WHERE pet_id = @id",
                "DELETE FROM care_bird WHERE pet_id = @id",
                "DELETE FROM care_reptile_spider WHERE pet_id = @id",
                "DELETE FROM vet_visits WHERE pet_id = @id",
                "DELETE FROM note_section WHERE pet_id = @id"
            };
                    foreach (var query in deleteQueries)
                    {
                        MySqlCommand tempCmd = new MySqlCommand(query, conn);
                        tempCmd.Parameters.AddWithValue("@id", petId);
                        tempCmd.ExecuteNonQuery();
                    }
                    string deletePet = "DELETE FROM pets WHERE pet_id = @id";
                    MySqlCommand cmd = new MySqlCommand(deletePet, conn);
                    cmd.Parameters.AddWithValue("@id", petId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception) { }
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

        private void DeleteConfirmationBox_Load(object sender, EventArgs e)
        {

        }
    }
}