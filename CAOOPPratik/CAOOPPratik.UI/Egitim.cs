using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAOOPPratik.UI
{
    public class Egitim
    {
        public Egitim(string egitimAdi, DateOnly egitimTarihi, string egitimSuresi)
        {
            EgitimAdi = egitimAdi;
            EgitimTarihi = egitimTarihi;
            EgitimSuresi = egitimSuresi;
        }

        public string EgitimAdi { get; set; }
        public DateOnly EgitimTarihi { get; set; }
        public string EgitimSuresi { get; set; }

        public void OzellikleriYazdir()
        {
            Console.WriteLine("Eğitim adı : "+EgitimAdi+", Eğitim Tarihi : "+EgitimTarihi+", Eğitim süresi : "+EgitimSuresi);
        }
    }
}
