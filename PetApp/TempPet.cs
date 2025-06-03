using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    public static class HayvanTemp
    {
        public static string? Tur;
        public static int? TurId;
        public static string? Isim;
        public static int? Yas;
        public static string? Irk;
        public static byte[]? Resim;
        public static int? PetId;
        public static string? PetCinsiyet;

        public static string? YapayZekayaSorulanSoru;

        public static void Sifirla()
        {
            Tur = null;
            TurId = null;
            Isim = null;
            Yas = null;
            Irk = null;
            Resim = null;
            PetId = null;
            PetCinsiyet = null;
        }
    }
}