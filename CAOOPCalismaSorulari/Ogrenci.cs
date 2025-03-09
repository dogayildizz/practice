using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAOOPCalismaSorulari
{
    public class Ogrenci
    {
        private int ogrenciNo;
        private string isim;
        private string soyisim;
        private string okulIsmi;
        private int vize1;
        private int vize2;
        private int final;

        public Ogrenci(int ogrenciNo, string isim, string soyisim, string okulIsmi, int vize1, int vize2, int final)
        {
            this.ogrenciNo = ogrenciNo;
            this.isim = isim;
            this.soyisim = soyisim;
            this.okulIsmi = okulIsmi;
            this.vize1 = vize1;
            this.vize2 = vize2;
            this.final = final;
        }
        public void OgrenciBilgileriGoster()
        {
            Console.WriteLine("Öğrenci numarası :" + ogrenciNo);
            Console.WriteLine("Öğrenci adı soyadı :" + isim + " " + soyisim);
            Console.WriteLine("Okul adı :" + okulIsmi);
            Console.WriteLine("Vize 1 notu :" + vize1);
            Console.WriteLine("Vize 2 notu :" + vize2);
            Console.WriteLine("Final notu :" + final);

        }
        public double OgrenciOrtalamasiniBul()
        {
            double ortalama = vize1 * 0.2 + vize2 * 0.2 + final * 0.6;
            return ortalama;
        }
        public void OgrencininOkulunuGoster()
        {
            Console.WriteLine("Öğrencinin okulu : " + okulIsmi);
        }

    }
}
