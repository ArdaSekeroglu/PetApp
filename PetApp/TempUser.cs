using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    public static class TempUser
    {
        public static string? Isim;
        public static string? Soyisim;
        public static string? KullaniciAdi;
        public static string? Sifre;
        public static string? Eposta;
        public static string? TelefonNo;
        public static int KullaniciId;
        public static byte[]? ResimEkle;
        public static void Sifirla()
        {
            Isim = null;
            Soyisim = null;
            KullaniciAdi = null;
            Sifre = null;
            Eposta = null;
            TelefonNo = null;
            KullaniciId = 0;
            ResimEkle = null;
        }
    }
}
