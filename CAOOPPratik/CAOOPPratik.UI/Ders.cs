using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAOOPPratik.UI
{
    public class Ders : Egitim
    {
        public Ders(string egitimAdi, DateOnly egitimTarihi, string egitimSuresi) : base(egitimAdi, egitimTarihi, egitimSuresi)
        {
        }
    }
}
