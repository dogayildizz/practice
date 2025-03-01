using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAOOPPratik.UI
{
    public class Atolye : Egitim
    {
        public Atolye(string egitimAdi, DateOnly egitimTarihi, string egitimSuresi,string uygulamaSuresi) : base(egitimAdi, egitimTarihi, egitimSuresi)
        {
            UygulamaSuresi = uygulamaSuresi;
        }

        public string UygulamaSuresi { get; set; }

        public void OzellikleriYazdir() 
        {
            base.OzellikleriYazdir();
            Console.WriteLine("Uygulama süresi : " + UygulamaSuresi);

        }
    }
}
