using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAOOPPratik.UI
{
    public class Seminer : Egitim
    {
        public string KonusmaciBilgisi { get; set; }

        public Seminer(string egitimAdi, DateOnly egitimTarihi, string egitimSuresi, string konusmaciBilgisi) : base(egitimAdi, egitimTarihi, egitimSuresi)
        {
            KonusmaciBilgisi = konusmaciBilgisi;
        }

        public void BilgileriYazdir()
        {
            base.OzellikleriYazdir();
            Console.WriteLine("Konuşmacı bilgisi : "+KonusmaciBilgisi);
        }
    }
}
