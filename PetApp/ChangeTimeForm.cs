using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace PetApp
{
    public partial class ChangeTimeForm : Form
    {
        public ChangeTimeForm()
        {
            InitializeComponent();
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
        private void İslemiİptalEt_Click(object sender, EventArgs e)
        {
            MainMenuForm anaMenü = new MainMenuForm();
            anaMenü.Show();
            this.Close();
        }
        private Dictionary<string, TimeSpan> defaultSaatler = new()
        {
            {"Yemek Zamanı", TimeSpan.FromHours(6)},
            {"Su Değişimi", TimeSpan.FromHours(24)},
            {"Tüy Bakımı", TimeSpan.FromHours(72)},
            {"Tırnak Kesimi", TimeSpan.FromHours(168)},
            {"Tuvalet Temizliği", TimeSpan.FromHours(24)},
            {"Günlük Egzersiz", TimeSpan.FromHours(24)},
            {"Son Su Değişimi", TimeSpan.FromHours(72)},
            {"Kafes Temizliği Tarihi", TimeSpan.FromHours(48)},
            {"Konuşma Pratiği", TimeSpan.FromHours(48)},
            {"Sıcaklık Kontrolü", TimeSpan.FromHours(24)},
            {"Nem Kontrolü", TimeSpan.FromHours(24)},
            {"Son Deri Dökme Tarihi", TimeSpan.FromHours(8560)},
            {"Son Kabuk Dökme Tarihi", TimeSpan.FromHours(8560)}
        };
        private void SaatDeğiştirme_Load(object sender, EventArgs e)
        {
            saatleriGoruntule.Controls.Clear();

            Dictionary<string, int> mevcutSaatler = new();

            string? tabloAdi = HayvanTemp.TurId switch
            {
                1 or 2 => "care_dog_cat",
                3 => "care_bird",
                4 => "care_fish",
                5 or 6 => "care_reptile_spider",
                _ => null
            };

            if (tabloAdi != null)
            {
                string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = $"SELECT * FROM {tabloAdi} WHERE pet_id = @pid";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@pid", HayvanTemp.PetId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string colName = reader.GetName(i);
                                if (colName.EndsWith("_interval_hours") && !reader.IsDBNull(i))
                                {
                                    string bakim = GetBakimAdiByColumn(colName);
                                    if (!string.IsNullOrEmpty(bakim))
                                        mevcutSaatler[bakim] = reader.GetInt32(i);
                                }
                            }
                        }
                    }
                }
            }

            string[] bakimAdlari = HayvanTemp.TurId switch
            {
                1 => new[] { "Yemek Zamanı", "Su Değişimi", "Tüy Bakımı", "Tırnak Kesimi", "Tuvalet Temizliği" },
                2 => new[] { "Yemek Zamanı", "Su Değişimi", "Tüy Bakımı", "Tırnak Kesimi", "Tuvalet Temizliği", "Günlük Egzersiz" },
                3 => new[] { "Yemek Zamanı", "Su Değişimi", "Kafes Temizliği Tarihi", "Konuşma Pratiği" },
                4 => new[] { "Yemek Zamanı", "Son Su Değişimi" },
                5 => new[] { "Yemek Zamanı", "Su Değişimi", "Sıcaklık Kontrolü", "Nem Kontrolü", "Son Deri Dökme Tarihi" },
                6 => new[] { "Yemek Zamanı", "Su Değişimi", "Sıcaklık Kontrolü", "Nem Kontrolü", "Son Kabuk Dökme Tarihi" },
                _ => Array.Empty<string>()
            };

            FlowLayoutPanel headerPanel = new FlowLayoutPanel
            {
                Width = saatleriGoruntule.Width,
                Height = 30,
                FlowDirection = FlowDirection.LeftToRight
            };
            headerPanel.Controls.Add(CreateBaslikLabel("Bakım Adı", 120));
            headerPanel.Controls.Add(CreateBaslikLabel("Geçen Süre", 80));
            headerPanel.Controls.Add(CreateBaslikLabel("Yeni Süre", 80));
            saatleriGoruntule.Controls.Add(headerPanel);

            foreach (string bakimAdi in bakimAdlari)
            {
                FlowLayoutPanel satir = new FlowLayoutPanel
                {
                    Width = saatleriGoruntule.Width,
                    Height = 30,
                    FlowDirection = FlowDirection.LeftToRight,
                    Margin = new Padding(0, 0, 0, 6),
                    BackColor = Color.Transparent
                };

                satir.Controls.Add(CreateBakimLabel(bakimAdi, 120));

                int saatDegeri = mevcutSaatler.ContainsKey(bakimAdi)
                    ? mevcutSaatler[bakimAdi]
                    : (int)defaultSaatler.GetValueOrDefault(bakimAdi, TimeSpan.FromHours(0)).TotalHours;

                Label gecenSureLbl = new Label
                {
                    Text = $"+{saatDegeri} saat",
                    Width = 80,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ForeColor = Color.White,
                    Font = new Font("Candara", 10)
                };
                satir.Controls.Add(gecenSureLbl);

                TextBox yeniSaatTxt = new TextBox
                {
                    Width = 80,
                    Tag = bakimAdi,
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                };
                yeniSaatTxt.KeyPress += SayiGirisi_KeyPress;
                satir.Controls.Add(yeniSaatTxt);
                satir.Controls.Add(yeniSaatTxt);

                Panel altCizgi = new Panel
                {
                    Width = saatleriGoruntule.Width,
                    Height = 1,
                    BackColor = Color.FromArgb(60, Color.Black),
                    Margin = new Padding(0, 0, 0, 4)
                };

                saatleriGoruntule.Controls.Add(satir);
                saatleriGoruntule.Controls.Add(altCizgi);
            }
        }
        private string GetBakimAdiByColumn(string column)
        {
            return column switch
            {
                "food_interval_hours" => "Yemek Zamanı",
                "water_interval_hours" => "Su Değişimi",
                "fur_interval_hours" => "Tüy Bakımı",
                "nail_interval_hours" => "Tırnak Kesimi",
                "toilet_clean_interval_hours" => "Tuvalet Temizliği",
                "daily_exercise_interval_hours" => "Günlük Egzersiz",
                "lastWaterChange_interval_hours" => "Son Su Değişimi",
                "cage_cleaned_interval_hours" => "Kafes Temizliği Tarihi",
                "talk_progress_interval_hours" => "Konuşma Pratiği",
                "temperature_interval_hours" => "Sıcaklık Kontrolü",
                "humidityLevel_interval_hours" => "Nem Kontrolü",
                "dateOfMoltedRecently_interval_hours" => HayvanTemp.TurId == 5
                    ? "Son Deri Dökme Tarihi"
                    : "Son Kabuk Dökme Tarihi",
                _ => ""
            };
        }
        private Label CreateBaslikLabel(string text, int width)
        {
            return new Label
            {
                Text = text,
                Width = width,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Candara", 10),
                ForeColor = Color.Gold,
                Margin = new Padding(0, 0, 0, 2)
            };
        }
        private Label CreateBakimLabel(string text, int width)
        {
            return new Label
            {
                Text = text,
                Width = width,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Candara", 10),
                ForeColor = Color.White
            };
        }

        private void saatleriKaydet_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> yeniSaatler = new();

            foreach (Control control in saatleriGoruntule.Controls)
            {
                if (control is FlowLayoutPanel panel)
                {
                    TextBox? txtBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
                    Label? bakimLbl = panel.Controls.OfType<Label>().FirstOrDefault();
                    if (txtBox != null && bakimLbl != null)
                    {
                        string bakimAdi = bakimLbl.Text;
                        string girilen = txtBox.Text.Trim();
                        if (string.IsNullOrWhiteSpace(girilen))
                            continue;
                        if (int.TryParse(girilen, out int saat) && saat >= 0)
                        {
                            yeniSaatler[bakimAdi] = saat;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            string? tabloAdi = HayvanTemp.TurId switch
            {
                1 or 2 => "care_dog_cat",
                3 => "care_bird",
                4 => "care_fish",
                5 or 6 => "care_reptile_spider",
                _ => null
            };
            if (tabloAdi == null || yeniSaatler.Count == 0)
            {
                return;
            }
            string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string checkQuery = $"SELECT COUNT(*) FROM {tabloAdi} WHERE pet_id = @pid";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@pid", HayvanTemp.PetId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        string insertQuery = $"INSERT INTO {tabloAdi} (pet_id) VALUES (@pid)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@pid", HayvanTemp.PetId);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
                List<string> setKisimlari = new();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                foreach (var pair in yeniSaatler)
                {
                    string kolonAdi = GetIntervalColumnName(pair.Key);
                    if (string.IsNullOrEmpty(kolonAdi)) continue;

                    setKisimlari.Add($"{kolonAdi} = @{kolonAdi}");
                    cmd.Parameters.AddWithValue($"@{kolonAdi}", pair.Value);
                }
                cmd.CommandText = $"UPDATE {tabloAdi} SET {string.Join(", ", setKisimlari)} WHERE pet_id = @pid";
                cmd.Parameters.AddWithValue("@pid", HayvanTemp.PetId);
                cmd.ExecuteNonQuery();
            }
            MainMenuForm anaMenü = new MainMenuForm();
            anaMenü.Show();
            this.Close();
        }
        private string GetIntervalColumnName(string bakimAdi)
        {
            return bakimAdi switch
            {
                "Yemek Zamanı" => "food_interval_hours",
                "Su Değişimi" => "water_interval_hours",
                "Tüy Bakımı" => "fur_interval_hours",
                "Tırnak Kesimi" => "nail_interval_hours",
                "Tuvalet Temizliği" => "toilet_clean_interval_hours",
                "Günlük Egzersiz" => "daily_exercise_interval_hours",
                "Son Su Değişimi" => "lastWaterChange_interval_hours",
                "Kafes Temizliği Tarihi" => "cage_cleaned_interval_hours",
                "Konuşma Pratiği" => "talk_progress_interval_hours",
                "Sıcaklık Kontrolü" => "temperature_interval_hours",
                "Nem Kontrolü" => "humidityLevel_interval_hours",
                "Son Deri Dökme Tarihi" => "dateOfMoltedRecently_interval_hours",
                "Son Kabuk Dökme Tarihi" => "dateOfMoltedRecently_interval_hours",
                _ => ""
            };
        }
        private void SayiGirisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}

