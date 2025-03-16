using JSONSerializationDeserialization.Data;
using System.Text.Json;
using System.Windows.Forms;

namespace JSONSerializationDeserialization
{
    public partial class Form1 : Form
    {
        List<Kisi> kisiler = new List<Kisi>();

        //Silme ve güncelleme iþlemlerini list üzerinde yaptýk. Sonrasýnda bu list ile kisiler.txt yi ve datagridviewi güncelledik.

        public void TextDosyasiniVeDataGridViewiGuncelle()
        {
            //önceki kisiler dosyamýzý sildik. sonrasýnda yeni listedeki bilgilerle yeni bir kisiler dosyasý oluþturduk.
            File.Delete("Kisiler.txt");
            using (StreamWriter yazici = new StreamWriter("Kisiler.txt", true))
            {
                foreach (Kisi kisi in kisiler)  //Yeni listeyi tekrardan Serialize ederek kisiler.txt dosyasýna yazdýrdýk.
                {
                    yazici.WriteLine(JsonSerializer.Serialize(kisi));
                }
            }

            dgvKisiler.DataSource = null;  //dgv ye de yeni listeyi yazdýrdýk.
            dgvKisiler.DataSource = kisiler;
        }
        public void KisiGuncelle()
        {
            Kisi secilenKisi = new Kisi();
            secilenKisi.Ad = dgvKisiler.SelectedRows[0].Cells[0].Value.ToString();
            secilenKisi.Soyad = dgvKisiler.SelectedRows[0].Cells[1].Value.ToString();
            secilenKisi.Adres = dgvKisiler.SelectedRows[0].Cells[2].Value.ToString();

            for (int i = 0; i < kisiler.Count; i++)  //Listede kullanýcýnýn seçtiðiyle ayný bilgilere sahip olan kiþiyi bulup yeni deðerlerini içine atadýk.
            {
                Kisi kisi = kisiler[i];
                if (kisi.Ad == secilenKisi.Ad && kisi.Soyad == secilenKisi.Soyad && kisi.Adres == secilenKisi.Adres)
                {
                    kisi.Ad = txtAd.Text;
                    kisi.Soyad = txtSoyad.Text;
                    kisi.Adres  = txtAdres.Text;
                }
            }
            //Listedeki kiþi güncellendi.
            TextDosyasiniVeDataGridViewiGuncelle();
            MessageBox.Show("Kiþi baþarýyla güncellendi!");
            TextBoxlariTemizle();

        }
        public void KisiSil()
        {
            //kullanýcýnýn seçtiði satýrdaki bilgileri secilenKisi adýndaki yeni Kisi nesnesine attým.
            Kisi secilenKisi = new Kisi();
            secilenKisi.Ad = dgvKisiler.SelectedRows[0].Cells[0].Value.ToString();
            secilenKisi.Soyad = dgvKisiler.SelectedRows[0].Cells[1].Value.ToString();
            secilenKisi.Adres = dgvKisiler.SelectedRows[0].Cells[2].Value.ToString();

            for (int i = 0; i < kisiler.Count; i++) //Bu döngüde kiþiyi listeden sildik.
            {
                Kisi kisi = kisiler[i];
                //Kullanýcýnýn seçtiði kiþinin bilgileriyle, listede bilgileri uyuþan kiþiyi listeden sildik.
                if (kisi.Ad == secilenKisi.Ad && kisi.Soyad == secilenKisi.Soyad && kisi.Adres == secilenKisi.Adres)
                {
                    kisiler.RemoveAt(i);
                }
            }
            TextDosyasiniVeDataGridViewiGuncelle();
            MessageBox.Show("Kiþi baþarýyla silindi!");
            TextBoxlariTemizle();
        }
        public void TextBoxlariTemizle()
        {
            txtAd.Text = txtSoyad.Text = txtAdres.Text = string.Empty;
        }
        public bool BuKisiMevcutMu(string isim, string soyisim)
        {

            bool mevcutMu = false;

            foreach (Kisi kisi in kisiler)  //Kiþiler listesinde ayný isim ve soyisimde bir var mý kontrol edildi.
            {
                if (kisi.Ad.ToLower() == isim.ToLower() && kisi.Soyad.ToLower() == soyisim.ToLower())
                {
                    MessageBox.Show("Bu isim ve soyisimde biri zaten mevcut!");
                    mevcutMu = true;
                    TextBoxlariTemizle();
                    break;
                }
            }
            return mevcutMu;


        }
        public void DosyadanGetir()  //kisiler.txt dosyasýndan aldýðý satýrlarý deserialize edip listeye ekliyor.
        {

            kisiler.Clear();
            using (StreamReader okuyucu = new StreamReader("Kisiler.txt", true))
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
        public void Kaydet()  //Serializer edip kisiler.txt dosyasýna yazýyor.
        {
            Kisi kisi = new Kisi();
            kisi.Ad = txtAd.Text;
            kisi.Soyad = txtSoyad.Text;
            kisi.Adres = txtAdres.Text;

            using (StreamWriter yazici = new StreamWriter("Kisiler.txt", true))
            {
                yazici.WriteLine(JsonSerializer.Serialize(kisi));
            }

            MessageBox.Show("Baþarýyla eklenmiþtir.");

            TextBoxlariTemizle();
            DosyadanGetir();
        }
        public Form1()
        {
            InitializeComponent();
            DosyadanGetir();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            //eðer kiþi mevcutsa metot kýrýlýr, kaydetme iþlemi yapýlmaz.
            if (!string.IsNullOrEmpty(txtAd.Text) && !string.IsNullOrEmpty(txtSoyad.Text) && BuKisiMevcutMu(txtAd.Text, txtSoyad.Text))
                return;
            if(string.IsNullOrEmpty(txtAd.Text)|| string.IsNullOrEmpty(txtSoyad.Text)||string.IsNullOrEmpty(txtAdres.Text) )
            {
                MessageBox.Show("Lütfen tüm alanlarý doldurduðunuzdan emin olun!");
                return;
            }
            Kaydet();
            TextBoxlariTemizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvKisiler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir satýr seçiniz.");
                return;
            }

            KisiSil();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvKisiler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir satýr seçiniz.");
                return;
            }
            KisiGuncelle();
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
