using JSONSerializationDeserialization.Data;
using System.Text.Json;
using System.Windows.Forms;

namespace JSONSerializationDeserialization
{
    public partial class Form1 : Form
    {
        List<Kisi> kisiler = new List<Kisi>();

        public void KisiSil()
        {
            //kullan�c�n�n se�ti�i sat�rdaki bilgileri secilenKisi ad�ndaki yeni Kisi nesnesine att�m.
            Kisi secilenKisi = new Kisi();
            secilenKisi.Ad = dgvKisiler.SelectedRows[0].Cells[0].Value.ToString();
            secilenKisi.Soyad = dgvKisiler.SelectedRows[0].Cells[1].Value.ToString();
            secilenKisi.Adres = dgvKisiler.SelectedRows[0].Cells[2].Value.ToString();

            for (int i = 0; i < kisiler.Count; i++) //Bu d�ng�de ki�iyi listeden sildik.
            {
                Kisi kisi = kisiler[i];
                //Kullan�c�n�n se�ti�i ki�inin bilgileriyle, listede bilgileri uyu�an ki�iyi listeden sildik.
                if (kisi.Ad == secilenKisi.Ad && kisi.Soyad == secilenKisi.Soyad && kisi.Adres == secilenKisi.Adres)
                {
                    kisiler.RemoveAt(i);
                }
            }
            //�nceki kisiler dosyam�z� sildik. sonras�nda yeni listedeki bilgilerle yeni bir kisiler dosyas� olu�turduk.
            File.Delete("Kisiler.txt");
            using (StreamWriter yazici = new StreamWriter("Kisiler.txt", true))
            {
                foreach (Kisi kisi in kisiler)  //Yeni listeyi tekrardan Serialize ederek kisiler.txt dosyas�na yazd�rd�k.
                {
                    yazici.WriteLine(JsonSerializer.Serialize(kisi));
                }
            }

            dgvKisiler.DataSource = null;  //dgv ye de yeni listeyi yazd�rd�k.
            dgvKisiler.DataSource = kisiler;
            MessageBox.Show("Ki�i ba�ar�yla silindi!");
            Temizle();
        }
        public void Temizle()
        {
            txtAd.Text = txtSoyad.Text = txtAdres.Text = string.Empty;
        }
        public bool BuKisiMevcutMu(string isim, string soyisim)
        {

            bool mevcutMu = false;


            //foreach (Kisi kisi in kisiler)  //Ki�iler listesinde ayn� isim ve soyisimde bir var m� kontrol edildi.
            //{
            //    if (kisi.Ad.ToLower() == isim.ToLower() && kisi.Soyad.ToLower() == soyisim.ToLower())
            //    {
            //        MessageBox.Show("Bu isim ve soyisimde biri zaten mevcut!");
            //        mevcutMu = true;
            //        break;
            //    }
            //}            
            return mevcutMu;


        }
        public void DosyadanGetir()  //kisiler.txt dosyas�ndan ald��� sat�rlar� deserialize edip listeye ekliyor.
        {
            if (!File.Exists("Kisiler.txt")) //Kisiler.txt varsa
                return;
            kisiler.Clear();
            using (StreamReader okuyucu = new StreamReader("Kisiler.txt"))
            {
                string satir = okuyucu.ReadLine();

                while (satir != null)
                {
                    Kisi kisi = JsonSerializer.Deserialize<Kisi>(satir);
                    kisiler.Add(kisi);
                    satir = okuyucu.ReadLine();
                }
            }

            dgvKisiler.DataSource = null;
            dgvKisiler.DataSource = kisiler;
        }
        public void Kaydet()  //Serializer edip kisiler.txt dosyas�na yaz�yor.
        {
            Kisi kisi = new Kisi();
            kisi.Ad = txtAd.Text;
            kisi.Soyad = txtSoyad.Text;
            kisi.Adres = txtAdres.Text;

            using (StreamWriter yazici = new StreamWriter("Kisiler.txt", true))
            {
                yazici.WriteLine(JsonSerializer.Serialize(kisi));
            }

            MessageBox.Show("Ba�ar�yla eklenmi�tir.");

            Temizle();
            DosyadanGetir();
        }
        public Form1()
        {
            InitializeComponent();
            DosyadanGetir();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            //e�er ki�i mevcutsa metot k�r�l�r, kaydetme i�lemi yap�lmaz.
            if (!string.IsNullOrEmpty(txtSoyad.Text) && !string.IsNullOrEmpty(txtSoyad.Text) && BuKisiMevcutMu(txtAd.Text, txtSoyad.Text))
                return;

            Kaydet();
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(dgvKisiler.SelectedRows.Count == 0)
            {
                MessageBox.Show("L�tfen bir sat�r se�iniz.");
                return;
            }
                
            KisiSil();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void dgvKisiler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKisiler.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow seciliSatir = dgvKisiler.SelectedRows[0];

            txtAd.Text = seciliSatir.Cells[0].Value.ToString();
            txtSoyad.Text = seciliSatir.Cells[1].Value.ToString();
            txtAdres.Text = seciliSatir.Cells[2].Value.ToString();

        }
    }
}
