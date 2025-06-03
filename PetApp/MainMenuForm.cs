using MySql.Data.MySqlClient;
using RestSharp;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Linq;
using PetApp.Properties;
using System.IO;
using System.Drawing;


namespace PetApp
{
    public partial class MainMenuForm : Form
    {
        private string apiKey = "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";
        private string? sonYanıt = null;
        private int _currentVolume;
        private string? SorulansonSoru;
        private string? oncekiNotMetni = null;
        private int seciliNoteId = -1;
        private Dictionary<int, DateTime> aktifReminderlar = new();

        private void Satir(string adi, string? tarihColumnName, string? boolColumnName = null)
        {
            DateTime? zaman = null;
            if (!string.IsNullOrEmpty(tarihColumnName))
                bakimZamanlari.TryGetValue(tarihColumnName, out zaman);

            int boolDeger = -1;
            if (!string.IsNullOrEmpty(boolColumnName)
                && boolBakimlar.TryGetValue(boolColumnName, out int? tmp))
            {
                boolDeger = tmp.GetValueOrDefault(-1);
            }

            YeniBakimSatiri(adi, zaman, boolDeger, tarihColumnName ?? "");
        }
        private Dictionary<string, string> aliasToGercekAd = new()
        {
            {"Son Deri Dökme Tarihi", "Son Tüy Dökme Tarihi"},
            {"Son Kabuk Dökme Tarihi", "Son Tüy Dökme Tarihi"},
        };
        private Dictionary<string, TimeSpan> sureler = new()
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
            {"Son Tüy Dökme Tarihi", TimeSpan.FromHours(168)},
            {"Nem Kontrolü", TimeSpan.FromHours(24)},
            {"Sıcaklık Kontrolü", TimeSpan.FromHours(24)}

        };
        private void LoadCustomIntervals(int petId)
        {
            string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = @"
                SELECT care_key, hours
                FROM pet_care_intervals
                WHERE pet_id = @pid";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@pid", petId);

        }

        private Dictionary<string, string> mesajlar = new()
        {
            {"Yemek Zamanı", "Yemek vakti!"},
            {"Su Değişimi", "Su değişimi zamanı!"},
            {"Tüy Bakımı", "Tüy bakımı vakti!"},
            {"Tırnak Kesimi", "Tırnak kesme zamanı!"},
            {"Tuvalet Temizliği", "Temizlik zamanı!"},
            {"Günlük Egzersiz", "Egzersiz zamanı!"},
            {"Son Su Değişimi", "Su değişim zamanı!"},
            {"Kafes Temizliği Tarihi", "Kafes temizliği zamanı!"},
            {"Konuşma Pratiği", "Konuşma çalışması zamanı!"},
            {"Son Tüy Dökme Tarihi", "Tüy dökme takibi zamanı!"},
            {"Nem Kontrolü", "Nem kontrolü gerekli!"},
            {"Sıcaklık Kontrolü", "Sıcaklık kontrolü gerekli!"}
        };
        Dictionary<string, int?> boolBakimlar = new();

        public MainMenuForm()
        {
            InitializeComponent();
            tbVolume.Scroll += TbVolume_Scroll;
            tbVolume.ValueChanged += TbVolume_Scroll;
            btnVolUp.Click += btnVolUp_Click;
            btnVolDown.Click += btnVolDown_Click;
        }

        private void AnaMenü_Load(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            _currentVolume = Properties.Settings.Default.SavedVolume;
            tbVolume.Minimum = 0;
            tbVolume.Maximum = 100;
            tbVolume.Value = _currentVolume;
            MusicPlayer.SetVolume(_currentVolume);


            if (!MusicPlayer.IsInitialized)
            {
                MusicPlayer.Start();
            }

            tbVolume.Minimum = 0;
            tbVolume.Maximum = 100;
            tbVolume.Value = _currentVolume;
            string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"SELECT name, surname, account_name, password, eposta, phone_no 
                     FROM users WHERE user_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", TempUser.KullaniciId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        TempUser.Isim = reader["name"].ToString();
                        TempUser.Soyisim = reader["surname"].ToString();
                        TempUser.KullaniciAdi = reader["account_name"].ToString();
                        TempUser.Sifre = reader["password"].ToString();
                        TempUser.Eposta = reader["eposta"].ToString();
                        TempUser.TelefonNo = reader["phone_no"].ToString();
                    }
                }
            }
            NotBasliklariniYukle();
            if (HayvanTemp.PetId != 0)
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT p.pName, p.pAge, p.gender, p.pet_images, b.breed_name 
                         FROM pets p
                         LEFT JOIN breeds b ON p.breed_id = b.breed_id
                         WHERE p.pet_id = @petId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@petId", HayvanTemp.PetId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            HayvanTemp.Isim = reader.GetString("pName");
                            HayvanTemp.Yas = reader.IsDBNull(reader.GetOrdinal("pAge"))
                                ? null
                                : reader.GetInt32(reader.GetOrdinal("pAge"));
                            HayvanTemp.PetCinsiyet = reader.GetString("gender");
                            HayvanTemp.Irk = reader.IsDBNull(reader.GetOrdinal("breed_name"))
                                            ? null
                                            : reader.GetString("breed_name");

                            if (!reader.IsDBNull(reader.GetOrdinal("pet_images")))
                            {
                                HayvanTemp.Resim = (byte[])reader["pet_images"];
                            }
                        }
                    }
                }
                BakimFormuYukle();
            }
            if (HayvanTemp.Resim != null)
            {
                using (MemoryStream ms = new MemoryStream(HayvanTemp.Resim))
                {
                    HayvanFoto.Image = Image.FromStream(ms);
                    HayvanFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT image_data FROM users WHERE user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", TempUser.KullaniciId);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])result;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        KullaniciFoto.Image = Image.FromStream(ms);
                        KullaniciFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                string? table = HayvanTemp.TurId switch
                {
                    1 or 2 => "care_dog_cat",
                    3 => "care_bird",
                    4 => "care_fish",
                    5 or 6 => "care_reptile_spider",
                    _ => null
                };
                bakimZamanlari.Clear();
                boolBakimlar.Clear();
                if (table != null)
                {
                    string bakimQuery = $"SELECT * FROM {table} WHERE pet_id = @pid";
                    MySqlCommand bakimCmd = new MySqlCommand(bakimQuery, conn);
                    bakimCmd.Parameters.AddWithValue("@pid", HayvanTemp.PetId);
                    using (var reader = bakimCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string column = reader.GetName(i);
                                if (column == "pet_id") continue;

                                if (!reader.IsDBNull(i))
                                {
                                    object value = reader.GetValue(i);
                                    if (value is sbyte || value is byte || value is int)
                                        boolBakimlar[column] = Convert.ToInt32(value);
                                    else if (value is DateTime dt)
                                        bakimZamanlari[column] = dt;
                                }
                            }
                        }
                    }
                }
                if (HayvanTemp.PetId.HasValue && HayvanTemp.PetId.Value != 0)
                {
                    LoadCustomIntervals(HayvanTemp.PetId.Value);
                }
                Tablolar.RowStyles.Clear();
                Tablolar.Controls.Clear();
                Tablolar.RowCount = 0;
                Tablolar.ColumnCount = 4;
                Tablolar.RowCount++;
                Tablolar.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                Tablolar.Controls.Add(CreateHeaderLabel("Bakım Adı"), 0, 0);
                Tablolar.Controls.Add(CreateHeaderLabel("Son Bakım"), 1, 0);
                Tablolar.Controls.Add(CreateHeaderLabel("Durum"), 2, 0);
                Tablolar.Controls.Add(CreateHeaderLabel("Tamamla"), 3, 0);
                if (HayvanTemp.TurId == 2)
                {
                    Satir("Yemek Zamanı", "food");
                    Satir("Su Değişimi", "water");
                    Satir("Tüy Bakımı", "fur");
                    Satir("Tırnak Kesimi", "nail");
                    Satir("Tuvalet Temizliği", "toilet_clean");
                    Satir("Kısır Mı?", null, "neutered");
                    Satir("Günlük Egzersiz", "daily_exercise");
                }
                else if (HayvanTemp.TurId == 1)
                {
                    Satir("Yemek Zamanı", "food");
                    Satir("Su Değişimi", "water");
                    Satir("Tüy Bakımı", "fur");
                    Satir("Tırnak Kesimi", "nail");
                    Satir("Tuvalet Temizliği", "toilet_clean");
                    Satir("Kısır Mı?", null, "neutered");
                }
                else if (HayvanTemp.TurId == 4)
                {
                    Satir("Yemek Zamanı", "food");
                    Satir("Son Su Değişimi", "lastWaterChange");
                    Satir("Sıcaklık Kontrolü", "temperature");
                }
                else if (HayvanTemp.TurId == 5)
                {
                    Satir("Yemek Zamanı", "food");
                    Satir("Su Değişimi", "water");
                    Satir("Sıcaklık Kontrolü", "temperature");
                    Satir("Nem Kontrolü", "humidityLevel");
                    Satir("Son Deri Dökme Tarihi", "dateOfMoltedRecently");
                }
                else if (HayvanTemp.TurId == 6)
                {
                    Satir("Yemek Zamanı", "food");
                    Satir("Su Değişimi", "water");
                    Satir("Sıcaklık Kontrolü", "temperature");
                    Satir("Nem Kontrolü", "humidityLevel");
                    Satir("Son Kabuk Dökme Tarihi", "dateOfMoltedRecently");
                }
                else if (HayvanTemp.TurId == 3)
                {
                    Satir("Yemek Zamanı", "food");
                    Satir("Su Değişimi", "water");
                    Satir("Kafes Temizliği Tarihi", "cage_cleaned");
                    Satir("Konuşma Pratiği", "talk_progress");
                }

            }

            IsimLbl.Text = HayvanTemp.Isim;
            YasLbl.Text = HayvanTemp.Yas?.ToString() ?? "Belirtilmedi";
            TurLbl.Text = HayvanTemp.Tur ?? "Belirtilmedi";
            IrkLbl.Text = HayvanTemp.Irk ?? "Belirtilmedi";
            CinsiyetLbl.Text = HayvanTemp.PetCinsiyet ?? "Belirtilmedi";

            KulIsimLbl.Text = TempUser.Isim ?? "Belirtilmedi";
            SoyadLbl.Text = TempUser.Soyisim ?? "Belirtilmedi";
            KulAdLbl.Text = TempUser.KullaniciAdi ?? "Belirtilmedi";
            EpostaLbl.Text = TempUser.Eposta ?? "Belirtilmedi";
            TelNoLbl.Text = string.IsNullOrWhiteSpace(TempUser.TelefonNo) ? "Belirtilmedi" : "0" + TempUser.TelefonNo;

        }
        private List<Panel> tumNotlar = new();
        private int sayfaIndex = 0;
        private const int notSayisiPerSayfa = 9;

        private void NotBasliklariniYukle()
        {
            tumNotlar.Clear();
            aktifReminderlar.Clear();
            string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            string remSql = "SELECT note_id, reminder_time FROM note_reminders";
            using (var remCmd = new MySqlCommand(remSql, conn))
            using (var remReader = remCmd.ExecuteReader())
            {
                while (remReader.Read())
                {
                    int nid = remReader.GetInt32("note_id");
                    DateTime zaman = remReader.GetDateTime("reminder_time");

                    if (zaman <= DateTime.Now)
                        aktifReminderlar[nid] = zaman;
                }
            }
            string query = "SELECT note_id, header FROM note_section WHERE user_id = @uid AND pet_id = @pid";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", TempUser.KullaniciId);
            cmd.Parameters.AddWithValue("@pid", HayvanTemp.PetId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int noteId = reader.GetInt32("note_id");
                string baslik = reader.GetString("header");
                tumNotlar.Add(NotPaneliOlustur(baslik, noteId));
            }
            sayfaIndex = 0;
            NotSayfayiGoster(sayfaIndex);
        }
        private void NotSayfayiGoster(int sayfa)
        {
            NotGoruntule.Controls.Clear();
            NotGoruntule.WrapContents = true;
            NotGoruntule.FlowDirection = FlowDirection.LeftToRight;
            int baslangic = sayfa * notSayisiPerSayfa;
            int bitis = Math.Min(baslangic + notSayisiPerSayfa, tumNotlar.Count);
            for (int i = baslangic; i < bitis; i++)
                NotGoruntule.Controls.Add(tumNotlar[i]);
            GeriButon.Enabled = sayfa > 0;
            IleriButon.Enabled = bitis < tumNotlar.Count;
        }
        private Panel NotPaneliOlustur(string baslik, int noteId)
        {
            Panel panel = new Panel
            {
                Width = 110,
                Height = 34,
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.FixedSingle,
                ForeColor = Color.White,
                Margin = new Padding(2),
                Tag = noteId,
                Cursor = Cursors.Hand,
            };
            Label lbl = new Label
            {
                Text = baslik,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font("Candara", 9),
                AutoSize = false,
                Width = 96,
                Height = 24,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.None,
                AutoEllipsis = false,
                MaximumSize = new Size(96, 24),
                MinimumSize = new Size(96, 24),
                Cursor = Cursors.Hand,
            };
            panel.Controls.Add(lbl);
            if (aktifReminderlar.ContainsKey(noteId))
            {
                byte[] resimVerisi = Properties.Resources.RedDotIcon;
                using var ms = new MemoryStream(resimVerisi);
                Image image = Image.FromStream(ms);

                var dot = new PictureBox
                {
                    Size = new Size(14, 14),
                    Location = new Point(panel.Width - 16, 8),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = image,
                    BackColor = Color.Transparent,
                    Tag = "dot"
                };
                panel.Controls.Add(dot);
                dot.BringToFront();


            }


            lbl.Click += (s, e) =>
            {
                int noteId = -1;
                if (s is Label lblSender && lblSender.Parent is Panel parentPanel && parentPanel.Tag is int id)
                {
                    noteId = id;

                    const string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
                    using var conn = new MySqlConnection(connStr);
                    conn.Open();
                    const string query = "SELECT note, created_at FROM note_section WHERE note_id = @nid";
                    using var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nid", noteId);
                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string icerik = reader["note"]?.ToString() ?? "İçerik bulunamadı.";
                        NotOku.Text = icerik;
                        oncekiNotMetni = icerik;
                        if (!reader.IsDBNull(reader.GetOrdinal("created_at")))
                        {
                            DateTime createdAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                            nottrhlabel.Text = createdAt.ToString("dd.MM.yyyy HH:mm");
                        }
                        else
                        {
                            nottrhlabel.Text = "";
                        }
                    }
                    NotOku.Visible = true;
                    NotKapat.Visible = true;
                    nottrhlabel.Visible = true;
                    NotOku.ForeColor = Color.White;
                    NotOku.Font = new Font("Candara", 9);
                    NotAlButon.Visible = false;
                    YapayZekaButon.Visible = false;
                    NotKapat.BringToFront();
                    GuncelleNotBtn.BringToFront();
                    AlarmBtn1.BringToFront();
                    AlarmBtn2.BringToFront();
                    seciliNoteId = noteId;
                    AlarmBtn1.Visible = true;
                }
                if (aktifReminderlar.ContainsKey(noteId))
                {
                    string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
                    using var silConn = new MySqlConnection(connStr);
                    silConn.Open();
                    string silSql = "DELETE FROM note_reminders WHERE note_id = @nid";
                    using var silCmd = new MySqlCommand(silSql, silConn);
                    silCmd.Parameters.AddWithValue("@nid", noteId);
                    silCmd.ExecuteNonQuery();

                    aktifReminderlar.Remove(noteId);

                    var dot = panel.Controls.OfType<PictureBox>().FirstOrDefault(x => (string?)x.Tag == "dot");
                    if (dot != null)
                        panel.Controls.Remove(dot);
                }
            };
            return panel;
        }
        private void GeriButon_Click(object sender, EventArgs e)
        {
            if (sayfaIndex > 0)
            {
                sayfaIndex--;
                NotSayfayiGoster(sayfaIndex);
            }
        }
        private void IleriButon_Click(object sender, EventArgs e)
        {
            int maxSayfa = (tumNotlar.Count - 1) / notSayisiPerSayfa;
            if (sayfaIndex < maxSayfa)
            {
                sayfaIndex++;
                NotSayfayiGoster(sayfaIndex);
            }
        }
        private void KaydetForNot_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            string notMetni = NotAlma.Text.Trim();
            string baslik = NotBasligiYaz.Text.Trim();
            if (string.IsNullOrWhiteSpace(notMetni) || string.IsNullOrWhiteSpace(baslik))
                return;
            int yeniNoteId;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO note_section (user_id, pet_id, note, header) VALUES (@user_id, @pet_id, @note, @header)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user_id", TempUser.KullaniciId);
                cmd.Parameters.AddWithValue("@pet_id", HayvanTemp.PetId);
                cmd.Parameters.AddWithValue("@note", notMetni);
                cmd.Parameters.AddWithValue("@header", baslik);
                cmd.ExecuteNonQuery();
                MySqlCommand lastIdCmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);
                yeniNoteId = Convert.ToInt32(lastIdCmd.ExecuteScalar());
            }
            NotAlma.Clear();
            NotBasligiYaz.Clear();
            tumNotlar.Add(NotPaneliOlustur(baslik, yeniNoteId));
            NotSayfayiGoster(sayfaIndex);
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
        private void sendMessageAi_Click(object sender, EventArgs e)
        {
            string soru = writeMessageAi.Text.Trim();
            if (string.IsNullOrWhiteSpace(soru)) return;
            SorulansonSoru = soru;
            SendMessageToOpenAi(soru);
            writeMessageAi.Clear();
        }
        private async void SendMessageToOpenAi(string kullaniciMesaji)
        {
            getAnswerAi.Text = "Yanıt bekleniyor...";

            var client = new RestClient("https://api.openai.com/v1/chat/completions");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Authorization", $"Bearer {apiKey}");
            request.AddHeader("Content-Type", "application/json");

            var body = new
            {
                model = "gpt-4o-mini",
                messages = new[]
                {
            new { role = "user", content = kullaniciMesaji }
        }
            };
            request.AddJsonBody(body);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful && !string.IsNullOrWhiteSpace(response.Content))
            {
                var jsonDoc = JsonDocument.Parse(response.Content);
                var reply = jsonDoc.RootElement
                                   .GetProperty("choices")[0]
                                   .GetProperty("message")
                                   .GetProperty("content")
                                   .GetString();
                sonYanıt = reply;
                getAnswerAi.Text = reply;
            }
            else
            {
                sonYanıt = null;
                getAnswerAi.Text = "Bir hata oluştu.";
            }
        }

        private Dictionary<string, DateTime?> bakimZamanlari = new();
        private void BakimFormuYukle()
        {
            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string? table = HayvanTemp.TurId switch
                {
                    1 or 2 => "care_dog_cat",
                    3 => "care_bird",
                    4 => "care_fish",
                    5 or 6 => "care_reptile_spider",
                    _ => null
                };
                if (table != null)
                {
                    string query = $"SELECT * FROM {table} WHERE pet_id = @pid";
                    using var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@pid", HayvanTemp.PetId);
                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string col = reader.GetName(i);
                            if (col == "pet_id" || reader.IsDBNull(i)) continue;
                            object value = reader.GetValue(i);
                            if (value is DateTime dt)
                                bakimZamanlari[col] = dt;
                            else if (value is sbyte || value is byte || value is int)
                                boolBakimlar[col] = Convert.ToInt32(value);
                        }
                    }
                }
            }

            Tablolar.RowStyles.Clear();
            Tablolar.Controls.Clear();
            Tablolar.RowCount = 0;
            Tablolar.ColumnCount = 4;
            Tablolar.RowCount++;
            Tablolar.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            Tablolar.Controls.Add(CreateHeaderLabel("Bakım Adı"), 0, 0);
            Tablolar.Controls.Add(CreateHeaderLabel("Son Bakım"), 1, 0);
            Tablolar.Controls.Add(CreateHeaderLabel("Durum"), 2, 0);
            Tablolar.Controls.Add(CreateHeaderLabel("Güncelle"), 3, 0);
            void Satir(string adi, string? tarihCol, string? boolCol = null)
            {
                bakimZamanlari.TryGetValue(tarihCol ?? "", out DateTime? zaman);
                boolBakimlar.TryGetValue(boolCol ?? "", out int? boolDeger);
                YeniBakimSatiri(adi, zaman, boolDeger ?? -1, tarihCol ?? "");
            }

            switch (HayvanTemp.TurId)
            {
                case 1:
                case 2:
                    Satir("Yemek Zamanı", "food");
                    Satir("Su Değişimi", "water");
                    Satir("Tüy Bakımı", "fur");
                    Satir("Tırnak Kesimi", "nail");
                    Satir("Tuvalet Temizliği", "toilet_clean");
                    Satir("Kısır Mı?", null, "neutered");
                    if (HayvanTemp.TurId == 2)
                        Satir("Günlük Egzersiz", "daily_exercise");
                    break;

                case 4:
                    Satir("Yemek Zamanı", "food");
                    Satir("Son Su Değişimi", "lastWaterChange");
                    Satir("Sıcaklık Kontrolü", "temperature");
                    break;

                case 5:
                case 6:
                    Satir("Yemek Zamanı", "food");
                    Satir("Su Değişimi", "water");
                    Satir("Sıcaklık Kontrolü", "temperature");
                    Satir("Nem Kontrolü", "humidityLevel");
                    if (HayvanTemp.TurId == 5)
                        Satir("Son Deri Dökme Tarihi", "dateOfMoltedRecently");
                    if (HayvanTemp.TurId == 6)
                        Satir("Son Kabuk Dökme Tarihi", "dateOfMoltedRecently");
                    break;

                case 3:
                    Satir("Yemek Zamanı", "food");
                    Satir("Su Değişimi", "water");
                    Satir("Kafes Temizliği Tarihi", "cage_cleaned");
                    Satir("Konuşma Pratiği", "talk_progress");
                    break;
            }
        }
        private void YeniBakimSatiri(string bakimAdi, DateTime? sonUygulamaZamani, int boolDeger, string columnName)
        {
            int rowIndex = Tablolar.RowCount++;
            Tablolar.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            var lblBakim = CreateCellLabel(bakimAdi);
            Tablolar.Controls.Add(lblBakim, 0, rowIndex);
            if (bakimAdi == "Kısır Mı?")
            {
                lblBakim.TextAlign = ContentAlignment.TopCenter;
                lblBakim.Padding = new Padding(0, 12, 0, 0);
            }


            var tarihLabel = new Label
            {
                Text = sonUygulamaZamani?.ToString("dd.MM HH:mm") ?? "",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Font = new Font("Candara", 9)
            };
            Tablolar.Controls.Add(tarihLabel, 1, rowIndex);
            if (bakimAdi == "Kısır Mı?")
            {
                var butonPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    AutoSize = true,
                    Padding = new Padding(0),
                    Margin = new Padding(0)
                };
                var btnEvet = new Button
                {
                    Text = "Evet",
                    Width = 70,
                    Height = 35,
                    Font = new Font("Candara", 10),
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 2 },
                    Cursor = Cursors.Hand,
                    Enabled = boolDeger != 1
                };
                btnEvet.FlatAppearance.BorderSize = 2;
                var btnHayir = new Button
                {
                    Text = "Hayır",
                    Width = 70,
                    Height = 35,
                    Font = new Font("Candara", 10),
                    BackColor = Color.Transparent,
                    ForeColor = Color.Red,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 2 },
                    Cursor = Cursors.Hand,
                    Enabled = boolDeger != 0
                };
                btnHayir.FlatAppearance.BorderSize = 2;

                btnEvet.Click += (s, e) =>
                {
                    if (GuncelleKisirlik(1))
                    {
                        btnEvet.Enabled = false;
                        btnHayir.Enabled = true;
                    }
                };
                btnHayir.Click += (s, e) =>
                {
                    if (GuncelleKisirlik(0))
                    {
                        btnEvet.Enabled = true;
                        btnHayir.Enabled = false;
                    }
                };
                butonPanel.Controls.Add(btnEvet);
                butonPanel.Controls.Add(btnHayir);
                Tablolar.Controls.Add(butonPanel, 2, rowIndex);
                Tablolar.Controls.Add(new Label(), 3, rowIndex);
                return;
            }
            var durumLabel = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Font = new Font("Candara", 9)
            };
            var tamamlaBtn = new Button
            {
                Text = "✓",
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Candara", 12, FontStyle.Bold),
                FlatAppearance = { BorderSize = 2 },
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            tamamlaBtn.MouseEnter += (s, e) =>
            {
                tamamlaBtn.BackColor = Color.Black;
                tamamlaBtn.ForeColor = Color.White;
            };
            tamamlaBtn.MouseLeave += (s, e) =>
            {
                tamamlaBtn.BackColor = Color.Transparent;
                tamamlaBtn.ForeColor = Color.White;
            };
            tamamlaBtn.Click += (s, e) =>
            {
                DateTime now = DateTime.Now;
                tarihLabel.Text = now.ToString("dd.MM HH:mm");
                durumLabel.Text = "✓";
                durumLabel.Font = new Font("Candara", 19, FontStyle.Bold);
                durumLabel.ForeColor = Color.PaleGreen;

                string? tablo = HayvanTemp.TurId switch
                {
                    1 or 2 => "care_dog_cat",
                    3 => "care_bird",
                    4 => "care_fish",
                    5 or 6 => "care_reptile_spider",
                    _ => null
                };
                if (tablo == null) return;
                using var conn = new MySqlConnection("Server=localhost;Database=petapp;Uid=root;Pwd=root;");
                conn.Open();
                string kontrol = $"SELECT COUNT(*) FROM {tablo} WHERE pet_id = @pid";
                using var kontrolCmd = new MySqlCommand(kontrol, conn);
                kontrolCmd.Parameters.AddWithValue("@pid", HayvanTemp.PetId);
                int varMi = Convert.ToInt32(kontrolCmd.ExecuteScalar());
                string sql = varMi > 0
                    ? $"UPDATE {tablo} SET {columnName} = @tarih WHERE pet_id = @pid"
                    : $"INSERT INTO {tablo} (pet_id, {columnName}) VALUES (@pid, @tarih)";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", HayvanTemp.PetId);
                cmd.Parameters.AddWithValue("@tarih", now);
                cmd.ExecuteNonQuery();
            };
            Tablolar.Controls.Add(tamamlaBtn, 3, rowIndex);
            if (bakimAdi.Contains("Sıcaklık"))
            {
                if (!sonUygulamaZamani.HasValue)
                {
                    durumLabel.Text = "-";
                    durumLabel.ForeColor = Color.Black;
                }
                else if (sureler.TryGetValue("Sıcaklık Kontrolü", out var sıcaklıkSüresi) &&
                         DateTime.Now - sonUygulamaZamani.Value >= sıcaklıkSüresi)
                {
                    durumLabel.Text = mesajlar["Sıcaklık Kontrolü"];
                    durumLabel.ForeColor = Color.Red;
                    durumLabel.Font = new Font("Candara", 9);
                }
                else
                {
                    durumLabel.Text = "✓";
                    durumLabel.ForeColor = Color.PaleGreen;
                    durumLabel.Font = new Font("Candara", 19, FontStyle.Bold);
                }
                Tablolar.Controls.Add(durumLabel, 2, rowIndex);
                Tablolar.Controls.Add(tamamlaBtn, 3, rowIndex);
                return;
            }
            else if (bakimAdi.Contains("Nem"))
            {
                if (!sonUygulamaZamani.HasValue)
                {
                    durumLabel.Text = "-";
                    durumLabel.ForeColor = Color.Black;
                }
                else if (sureler.TryGetValue("Nem Kontrolü", out var nemSuresi) &&
                         DateTime.Now - sonUygulamaZamani.Value >= nemSuresi)
                {
                    durumLabel.Text = mesajlar["Nem Kontrolü"];
                    durumLabel.ForeColor = Color.Red;
                    durumLabel.Font = new Font("Candara", 9);
                }
                else
                {
                    durumLabel.Text = "✓";
                    durumLabel.ForeColor = Color.PaleGreen;
                    durumLabel.Font = new Font("Candara", 19, FontStyle.Bold);
                }
                Tablolar.Controls.Add(durumLabel, 2, rowIndex);
                Tablolar.Controls.Add(tamamlaBtn, 3, rowIndex);
                return;
            }
            string bakimKey = aliasToGercekAd.ContainsKey(bakimAdi) ? aliasToGercekAd[bakimAdi] : bakimAdi;
            if (sureler.TryGetValue(bakimKey, out var beklemeSuresi) && sonUygulamaZamani.HasValue)
            {
                var fark = DateTime.Now - sonUygulamaZamani.Value;
                if (fark >= beklemeSuresi)
                {
                    durumLabel.Text = mesajlar[bakimKey];
                    durumLabel.ForeColor = Color.Red;
                    durumLabel.Font = new Font("Candara Light", 9);
                }
                else
                {
                    durumLabel.Text = "✓";
                    durumLabel.ForeColor = Color.PaleGreen;
                    durumLabel.Font = new Font("Candara", 19, FontStyle.Bold);
                }
            }
            else
            {
                durumLabel.Text = "-";
                durumLabel.ForeColor = Color.Black;
                durumLabel.Font = new Font("Candara Light", 19);
            }
            Tablolar.Controls.Add(durumLabel, 2, rowIndex);

        }

        bool GuncelleKisirlik(int deger)
        {
            try
            {
                string? tablo = HayvanTemp.TurId switch
                {
                    1 or 2 => "care_dog_cat",
                    _ => null
                };
                if (tablo == null) return false;
                using var conn = new MySqlConnection("Server=localhost;Database=petapp;Uid=root;Pwd=root;");
                conn.Open();
                string query = $"UPDATE {tablo} SET neutered = @deg WHERE pet_id = @pid";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@deg", deger);
                cmd.Parameters.AddWithValue("@pid", HayvanTemp.PetId);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private Label CreateCellLabel(string text)
        {
            return new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Candara", 10),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None
            };
        }
        private Label CreateHeaderLabel(string text)
        {
            return new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Candara", 10),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None
            };
        }
        private void NotAlmayaDon_Click(object sender, EventArgs e)
        {
            getAnswerAi.Visible = false;
            writeMessageAi.Visible = false;
            sendMessageAi.Visible = false;
            KaydetForAi.Visible = false;
            NotAlButon.Visible = false;
            YapayZekaButon.Visible = true;

            NotAlma.Visible = true;
            KaydetForNot.Visible = true;
            NotBasligiYaz.Visible = true;
        }
        private void YapayZekayaDon_Click(object sender, EventArgs e)
        {
            NotAlma.Visible = false;
            KaydetForNot.Visible = false;
            NotBasligiYaz.Visible = false;

            getAnswerAi.Visible = true;
            writeMessageAi.Visible = true;
            sendMessageAi.Visible = true;
            KaydetForAi.Visible = true;
            NotAlButon.Visible = true;
            YapayZekaButon.Visible = false;
        }
        private void GeriDonButton_Click(object sender, EventArgs e)
        {
            HayvanTemp.Sifirla();
            SelectPetForm hayvanSec = new SelectPetForm();
            hayvanSec.Show();
            this.Close();
        }
        private void ProfilButon_Click(object sender, EventArgs e)
        {
            ProfilButon.Visible = false;
            HayvanButon.Visible = true;
            HayvanProfili.Visible = false;
            KullaniciProfili.Visible = true;
            DuzenleForDost.Visible = false;
            DuzenleForKullanici.Visible = true;
        }
        private void HayvanButon_Click(object sender, EventArgs e)
        {
            HayvanButon.Visible = false;
            ProfilButon.Visible = true;
            HayvanProfili.Visible = true;
            KullaniciProfili.Visible = false;
            DuzenleForDost.Visible = true;
            DuzenleForKullanici.Visible = false;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void minimizeButton_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void KaydetForAi_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            string notMetni = getAnswerAi.Text.Trim();
            string baslik = SorulansonSoru ?? "Yapay Zeka Yanıtı";

            if (string.IsNullOrWhiteSpace(notMetni))
                return;

            int yeniNoteId;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO note_section (user_id, pet_id, note, header) VALUES (@user_id, @pet_id, @note, @header)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user_id", TempUser.KullaniciId);
                cmd.Parameters.AddWithValue("@pet_id", HayvanTemp.PetId);
                cmd.Parameters.AddWithValue("@note", notMetni);
                cmd.Parameters.AddWithValue("@header", baslik);
                cmd.ExecuteNonQuery();
                MySqlCommand lastIdCmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);
                yeniNoteId = Convert.ToInt32(lastIdCmd.ExecuteScalar());
            }
            getAnswerAi.Clear();
            SorulansonSoru = null;
            tumNotlar.Add(NotPaneliOlustur(baslik, yeniNoteId));
            NotSayfayiGoster(sayfaIndex);
        }



        private void Tablolar_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutPanel? panel = sender as TableLayoutPanel;
            if (e.Row < panel?.RowCount - 1)
            {
                Rectangle rect = e.CellBounds;
                Graphics g = e.Graphics;
                if (e.Row == 0)
                {
                    using (Pen penWhite = new Pen(Color.White, 0.1f))
                    {
                        g.DrawLine(penWhite, rect.Left, rect.Bottom - 1, rect.Right, rect.Bottom - 1);
                    }
                }
                else
                {
                    using (Pen penBlack = new Pen(Color.FromArgb(60, Color.Black), 0.1f))
                    {
                        g.DrawLine(penBlack, rect.Left, rect.Bottom - 1, rect.Right, rect.Bottom - 1);
                    }
                }
            }
        }
        private void HayvanProfili_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(60, Color.Black), 0.1f))
            {
                TableLayoutPanel? panel = sender as TableLayoutPanel;
                if (e.Row < panel?.RowCount - 1)
                {
                    Rectangle rect = e.CellBounds;
                    Graphics g = e.Graphics;
                    g.DrawLine(pen, rect.Left, rect.Bottom - 1, rect.Right, rect.Bottom - 1);
                }
            }
        }
        private void HyvnBilgiTablo_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (sender is not TableLayoutPanel panel)
                return;

            if (e.Row == 4)
                return;

            if (e.Column == 0)
            {
                using (Pen pen = new Pen(Color.FromArgb(60, Color.Black), 0.1f))
                {
                    int fullWidth = panel.GetColumnWidths().Sum();
                    Rectangle cellRect = e.CellBounds;
                    e.Graphics.DrawLine(pen, 0, cellRect.Bottom - 1, fullWidth, cellRect.Bottom - 1);
                }
            }
        }
        private void HayvanVerileri_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (sender is not TableLayoutPanel panel)
                return;

            if (e.Row == 4)
                return;

            if (e.Column == 0)
            {
                using (Pen pen = new Pen(Color.FromArgb(60, Color.Black), 0.1f))
                {
                    int fullWidth = panel.GetColumnWidths().Sum();
                    int xStart = panel.GetColumnWidths().Take(0).Sum();
                    Rectangle cellRect = e.CellBounds;
                    e.Graphics.DrawLine(pen, xStart, cellRect.Bottom - 1, xStart + fullWidth, cellRect.Bottom - 1);
                }
            }
        }
        private void KullaniciBilgiTablo_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (sender is not TableLayoutPanel panel)
                return;

            if (e.Row == 4)
                return;

            if (e.Column == 0)
            {
                using (Pen pen = new Pen(Color.FromArgb(60, Color.Black), 0.1f))
                {
                    int fullWidth = panel.GetColumnWidths().Sum();
                    int xStart = panel.GetColumnWidths().Take(0).Sum();
                    Rectangle cellRect = e.CellBounds;
                    e.Graphics.DrawLine(pen, xStart, cellRect.Bottom - 1, xStart + fullWidth, cellRect.Bottom - 1);
                }
            }
        }
        private void KullaniciVerileri_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (sender is not TableLayoutPanel panel)
                return;

            if (e.Row == 4)
                return;

            if (e.Column == 0)
            {
                using (Pen pen = new Pen(Color.FromArgb(60, Color.Black), 0.1f))
                {
                    int fullWidth = panel.GetColumnWidths().Sum();
                    int xStart = panel.GetColumnWidths().Take(0).Sum();
                    Rectangle cellRect = e.CellBounds;
                    e.Graphics.DrawLine(pen, xStart, cellRect.Bottom - 1, xStart + fullWidth, cellRect.Bottom - 1);
                }
            }
        }
        private void CikisYapBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            var login = Application.OpenForms.OfType<GirisSayfasi>().FirstOrDefault()
                        ?? new GirisSayfasi();
            login.Show();
            this.Close();
            Properties.Settings.Default.RememberMe = false;
            Properties.Settings.Default.SavedUserId = 0;
            Properties.Settings.Default.Save();
        }

        private void AyarlarToggleButon_Click(object sender, EventArgs e)
        {
            CikisYapBtn.Visible = true;
            AyarlarToggleButon.Visible = false;
            AyarlarToggleButon2.Visible = true;
            sesikapat.Visible = true;
            WebsiteBtn1.Visible = true;
        }
        private void AyarlarToggleButon2_Click(object sender, EventArgs e)
        {
            CikisYapBtn.Visible = false;
            AyarlarToggleButon.Visible = true;
            AyarlarToggleButon2.Visible = false;
            sesikapat.Visible = false;
            sesiac.Visible = false;
            btnVolUp.Visible = false;
            btnVolDown.Visible = false;
            WebsiteBtn1.Visible = false;
            WebsiteBtn2.Visible = false;
            Websitemiz.Visible = false;
        }
        private void DuzenleForDost_Click(object sender, EventArgs e)
        {
            if (HayvanTemp.PetId == null)
            {
                return;
            }
            PetInfoUpdateForm dostBilgiGüncelle = new PetInfoUpdateForm();
            dostBilgiGüncelle.Show();
            this.Close();
        }
        private void DuzenleForKullanici_Click(object sender, EventArgs e)
        {
            UserInfoUpdateForm kulForm = new UserInfoUpdateForm();
            kulForm.AnaMenudenMiGeldim = true;
            kulForm.Show();
            this.Close();
        }
        private void NotKapat_Click(object sender, EventArgs e)
        {
            NotKapat.Visible = false;
            NotOku.Visible = false;
            YapayZekaButon.Visible = true;
            NotAlButon.Visible = true;
            nottrhlabel.Visible = false;
            GuncelleNotBtn.Visible = false;
            AlarmBtn1.Visible = false;
            AlarmBtn2.Visible = false;
            HatirlaticiPanel.Visible = false;
        }
        private void saatDegis_Click(object sender, EventArgs e)
        {
            ChangeTimeForm saatDeğiştirme = new ChangeTimeForm();
            saatDeğiştirme.Show();
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
        private void btnVolUp_Click(object? sender, EventArgs e)
        {
            tbVolume.Value = Math.Min(tbVolume.Value + 10, tbVolume.Maximum);
        }
        private void btnVolDown_Click(object? sender, EventArgs e)
        {
            tbVolume.Value = Math.Max(tbVolume.Value - 10, tbVolume.Minimum);
        }
        private void TbVolume_Scroll(object? sender, EventArgs e)
        {
            _currentVolume = tbVolume.Value;
            MusicPlayer.SetVolume(_currentVolume);
            Properties.Settings.Default.SavedVolume = _currentVolume;
            Properties.Settings.Default.Save();
        }
        private void GuncelleNotBtn_Click(object sender, EventArgs e)
        {
            if (seciliNoteId == -1 || NotOku.Text == oncekiNotMetni)
                return;

            string connStr = "Server=localhost;Database=petapp;Uid=root;Pwd=root;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE note_section SET note = @note, updated_at = NOW() WHERE note_id = @nid";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@note", NotOku.Text.Trim());
                    cmd.Parameters.AddWithValue("@nid", seciliNoteId);
                    cmd.ExecuteNonQuery();
                }
            }

            oncekiNotMetni = NotOku.Text;
            GuncelleNotBtn.Visible = false;
        }
        private void NotOku_TextChanged(object sender, EventArgs e)
        {
            if (NotOku.Text != oncekiNotMetni)
            {
                GuncelleNotBtn.Visible = true;
            }
            else
            {
                GuncelleNotBtn.Visible = false;
            }
        }
        private void AlarmBtn1_Click(object sender, EventArgs e)
        {
            HatirlaticiPanel.Visible = true;
            AlarmBtn1.Visible = false;
            AlarmBtn2.Visible = true;
        }
        private void AlarmBtn2_Click(object sender, EventArgs e)
        {
            HatirlaticiPanel.Visible = false;
            AlarmBtn2.Visible = false;
            AlarmBtn1.Visible = true;
        }
        private void AlarmTarih_KeyUp(object sender, KeyEventArgs e)
        {
            string giris = new string(AlarmTarih.Text.Where(char.IsDigit).ToArray());
            if (giris.Length == 0) return;
            string gun = "", ay = "";
            int year = DateTime.Now.Year;
            if (giris.Length >= 1)
            {
                gun = giris.Substring(0, Math.Min(2, giris.Length));
                if (gun.Length == 1)
                    gun = "0" + gun;
            }
            if (giris.Length >= 3)
            {
                ay = giris.Substring(2, Math.Min(2, giris.Length - 2));
                if (ay.Length == 1)
                    ay = "0" + ay;
            }
            if (int.TryParse(gun, out int g))
            {
                if (g <= 0) g = 1;
                if (g > 31) g = 31;
                gun = g.ToString("D2");
            }
            if (int.TryParse(ay, out int a))
            {
                if (a <= 0) a = 1;
                if (a > 12) a = 12;
                ay = a.ToString("D2");
            }
            string sonuc = gun;
            if (!string.IsNullOrEmpty(ay))
                sonuc += "." + ay;
            if (ay.Length == 2)
                sonuc += "." + year;

            AlarmTarih.Text = sonuc;
            AlarmTarih.SelectionStart = AlarmTarih.Text.Length;
        }
        private void SadeceSayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void AlarmSaat_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(AlarmSaat.Text, out int saat))
            {
                if (saat < 0) saat = 0;
                if (saat > 23) saat = 23;
                AlarmSaat.Text = saat.ToString("D2");
            }
            else
            {
                AlarmSaat.Text = "00";
            }
        }
        private void AlarmDakika_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(AlarmDakika.Text, out int dakika))
            {
                if (dakika < 0) dakika = 0;
                if (dakika > 59) dakika = 59;
                AlarmDakika.Text = dakika.ToString("D2");
            }
            else
            {
                AlarmDakika.Text = "00";
            }
        }
        private void AlarmKaydet_Click(object sender, EventArgs e)
        {
            if (seciliNoteId == -1)
                return;

            string tarihStr = AlarmTarih.Text.Trim();
            string saatStr = AlarmSaat.Text.Trim();
            string dakikaStr = AlarmDakika.Text.Trim();

            if (string.IsNullOrWhiteSpace(tarihStr))
            {
                HataLabel.Text = "Tarih boş olamaz.";
                HataLabel.Visible = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(saatStr))
            {
                HataLabel.Text = "Saat boş olamaz.";
                HataLabel.Visible = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(dakikaStr))
            {
                HataLabel.Text = "Dakika boş olamaz.";
                HataLabel.Visible = true;
                return;
            }

            DateTime tarih = DateTime.ParseExact(tarihStr, "dd.MM.yyyy", null);
            int saat = int.Parse(saatStr);
            int dakika = int.Parse(dakikaStr);

            DateTime alarmZamani = new DateTime(tarih.Year, tarih.Month, tarih.Day, saat, dakika, 0);

            using var conn = new MySqlConnection("Server=localhost;Database=petapp;Uid=root;Pwd=root;");
            conn.Open();
            string sql = "INSERT INTO note_reminders (note_id, reminder_time) VALUES (@note_id, @reminder_time)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@note_id", seciliNoteId);
            cmd.Parameters.AddWithValue("@reminder_time", alarmZamani);
            cmd.ExecuteNonQuery();

            HatirlaticiPanel.Visible = false;
            AlarmBtn1.Visible = true;
            AlarmBtn2.Visible = false;
        }
        private void AlarmTarih_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsControl(ch) && !char.IsDigit(ch) && ch != '.')
            {
                e.Handled = true;
            }
        }

        private void WebsiteBtn1_Click(object sender, EventArgs e)
        {
            Websitemiz.Visible = true;
            WebsiteBtn1.Visible = false;
            WebsiteBtn2.Visible = true;
        }

        private void WebsiteBtn2_Click(object sender, EventArgs e)
        {
            Websitemiz.Visible = false;
            WebsiteBtn1.Visible = true;
            WebsiteBtn2.Visible = false;
        }
    }
}