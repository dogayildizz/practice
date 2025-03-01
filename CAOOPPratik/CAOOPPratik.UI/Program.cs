using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;

namespace CAOOPPratik.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Ornek1
            //Bir Egitim sınıfı oluşturun ve bu sınıftan Ders, Seminer ve Atolye sınıflarını türetin. 
            //Her eğitim türünün adı, tarihi ve süresi olsun.Ders sınıfı için öğretim yöntemi, 
            //Seminer sınıfı için konuşmacı bilgisi, Atolye sınıfı için uygulama süresi gibi ek özellikler ekleyin.
            //Eğitimlerin özelliklerini detaylı şekilde ekrana yazdıran bir metot oluşturun.

            Atolye atolye = new Atolye("Ahşap Boyama", new DateOnly(2025, 4, 1), "1 ay", "Günde 2 saat");
            atolye.OzellikleriYazdir();



            #endregion
            #region Ornek2
            //Soru:
            //Bir Hayvan(Animal) sınıfı oluşturun. Bu sınıfta her hayvanın adı ve yaşı gibi özellikleri olsun. Ayrıca her hayvanın sesi çıkarmasını sağlayan bir metot ekleyin. 
            //Encapsulation(Kapsülleme):
            //	• Adı ve yaşı gibi özellikleri yalnızca metotlar aracılığıyla değiştirilebilecek şekilde ayarlayın. 
            //Inheritance(Kalıtım):
            //	• Kedi ve Köpek adında iki alt sınıf oluşturun. 
            //	• Bu sınıflar Hayvan sınıfından türetilsin ve ek özellikler ekleyin(örneğin, kediler tırmalayabilir, köpekler havlayabilir).
            //Abstraction(Soyutlama):
            //	• Hayvan sınıfını abstract (soyut) bir sınıf yapın.
            //	• Hayvan sınıfında soyut bir metot (örneğin, SesCikar()) tanımlayın ve alt sınıfların bunu kendilerine özgü şekilde doldurmasını sağlayın.

            Cat cat = new Cat("Çizmeli kedi", 10);
            Dog dog = new Dog("Dog", 15);            
            Console.WriteLine("Kedinin adı : "+cat.Name+ " Kedinin yaşı :"+cat.Age);
            cat.SesCikar();
            cat.Tirmala();
            dog.SesCikar();

            #endregion
        }
    }
}
