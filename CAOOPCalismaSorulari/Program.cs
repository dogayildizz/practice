namespace CAOOPCalismaSorulari
{
    internal class Program
    {
        static void IslemleriGoster()
        {
            Console.WriteLine("1 - Öğrenci bilgilerini göster.");
            Console.WriteLine("2 - Öğrenci ortalamasını göster.");
            Console.WriteLine("3 - Öğrencinin okulunu göster.");
            Console.WriteLine("4 - Çıkış yap.");
        }
        static void Main(string[] args)
        {
            #region Ornek1
            //bool kontrol = true;
            //Ogrenci ogrenci = new Ogrenci(200420702, "Doğa", "Yıldız", "Gazi Üniversitesi", 96, 80, 100);
            //Console.WriteLine("Uygulamamıza hoşgeldiniz. Yapmak istediğiniz işlemi seçiniz.");
            //IslemleriGoster();


            //while (kontrol)
            //{
            //    string secim = Console.ReadLine();
            //    switch (secim)
            //    {
            //        case "1":
            //            ogrenci.OgrenciBilgileriGoster();
            //            break;
            //        case "2":
            //            double ortalama = ogrenci.OgrenciOrtalamasiniBul();
            //            Console.WriteLine("Öğrencinin ortalaması : " + ortalama);
            //            break;
            //        case "3":
            //            ogrenci.OgrencininOkulunuGoster();
            //            break;
            //        case "4":
            //            kontrol = false;
            //            break;



            //    }
            //}
            #endregion
            #region Ornek2
            Personel personel1 = new Personel();

            personel1.TCKimlikNo = "12345678959";
            Console.WriteLine(personel1.TCKimlikNo);

            

            #endregion
        }
    }
}
