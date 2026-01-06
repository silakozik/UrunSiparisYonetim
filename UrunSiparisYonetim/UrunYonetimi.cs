using BL;
using Entities;
using System;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class UrunYonetimi : Form
    {
        public UrunYonetimi()
        {
            InitializeComponent();
        }
        UrunManager manager =new UrunManager();
        KategoriManager kategoriManager = new KategoriManager();    
        MarkaManager markaManager = new MarkaManager(); 
        void Yukle()
        {
            dgvUrunler.AutoGenerateColumns = true; // Otomatik kolon oluşturmayı aktif et
            dgvUrunler.DataSource = manager.GetAll();
            cbUrunKategorisi.DataSource = kategoriManager.GetAll();
            cbUrunKategorisi.DisplayMember = "KategoriAdi";
            cbUrunKategorisi.ValueMember = "Id";
            cbUrunMarkasi.DataSource = markaManager.GetAll();
            cbUrunMarkasi.DisplayMember = "MarkaAdi";
            cbUrunMarkasi.ValueMember = "Id";
        }

        void Temizle()
        {
            txtIskonto.Text = string.Empty;
            txtKdv.Text = string.Empty;
            txtStokMiktari.Text = string.Empty;
            txtUrunAdi.Text = string.Empty;
            txtUrunFiyati.Text = string.Empty;  
            cbDurum.Checked = false;
            rtbUrunAciklamasi.Text = string.Empty;
            lblId.Text = "0";
            lblEklenmeTarihi.Text = string.Empty;
        }
        private void UrunYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // Temel doğrulamalar
            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text))
            {
                MessageBox.Show("Ürün adı boş geçilemez!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUrunFiyati.Text))
            {
                MessageBox.Show("Ürün fiyatı boş geçilemez!");
                return;
            }

            if (cbUrunKategorisi.SelectedValue == null || cbUrunMarkasi.SelectedValue == null)
            {
                MessageBox.Show("Lütfen kategori ve marka seçiniz!");
                return;
            }

            // Sayısal alanları güvenli parse et
            if (!decimal.TryParse(txtUrunFiyati.Text, out decimal urunFiyati))
            {
                MessageBox.Show("Ürün fiyatı sayısal olmalıdır!");
                return;
            }

            int.TryParse(txtIskonto.Text, out int iskonto);          // Boş ise 0
            int.TryParse(txtKdv.Text, out int kdv);                   // Boş ise 0
            int.TryParse(txtStokMiktari.Text, out int stokMiktari);   // Boş ise 0

            try
            {
                var sonuc = manager.Add(
                    new Urun
                    {
                        UrunAdi = txtUrunAdi.Text.Trim(),
                        UrunFiyati = urunFiyati,
                        Aciklama = rtbUrunAciklamasi.Text,
                        Aktif = cbDurum.Checked,
                        EklenmeTarihi = DateTime.Now,
                        Iskonto = iskonto,
                        Kdv = kdv,
                        StokMiktari = stokMiktari,
                        ToptanFiyat = urunFiyati, // Toptan fiyatı şimdilik ürün fiyatı ile aynı
                        KategoriId = Convert.ToInt32(cbUrunKategorisi.SelectedValue),
                        MarkaId = Convert.ToInt32(cbUrunMarkasi.SelectedValue),
                    }
                    );

                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Eklendi!");
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını da göster ki sebebi görülebilsin
                MessageBox.Show("Hata Oluştu! Kayıt Eklenemedi!\nDetay: " + ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrunFiyati.Text))
            {
                MessageBox.Show("Ürün fiyatı boş geçilemez!");
                return;
            }

            if (!decimal.TryParse(txtUrunFiyati.Text, out decimal urunFiyati))
            {
                MessageBox.Show("Ürün fiyatı sayısal olmalıdır!");
                return;
            }

            int.TryParse(txtIskonto.Text, out int iskonto);
            int.TryParse(txtKdv.Text, out int kdv);
            int.TryParse(txtStokMiktari.Text, out int stokMiktari);

            try
            {
                int urunId = Convert.ToInt32(lblId.Text);
                if (urunId > 0)
                {
                    var sonuc = manager.Update(
                    new Urun
                    {
                        Id = urunId,
                        UrunAdi = txtUrunAdi.Text.Trim(),
                        UrunFiyati = urunFiyati,
                        Aciklama = rtbUrunAciklamasi.Text,
                        Aktif = cbDurum.Checked,
                        EklenmeTarihi = DateTime.Now,
                        Iskonto = iskonto,
                        Kdv = kdv,
                        StokMiktari = stokMiktari,
                        ToptanFiyat = urunFiyati,
                        KategoriId = Convert.ToInt32(cbUrunKategorisi.SelectedValue),
                        MarkaId = Convert.ToInt32(cbUrunMarkasi.SelectedValue),
                    }
                    );
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Güncellendi!");
                    }
                }
                else MessageBox.Show("Listeden Bir Ürün Seçiniz!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Güncellenemedi!\nDetay: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listeden Silinecek Kaydı Seçiniz!");
                }
                else
                {
                    var sonuc = manager.Delete(int.Parse(lblId.Text));
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Güncellendi!");
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu! Kayıt Silinemedi! ");
            }
        }
        
        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblId.Text = dgvUrunler.CurrentRow.Cells[0].Value.ToString();
                int urunId = Convert.ToInt32(lblId.Text);
                if (urunId > 0) 
                {
                    var urun = manager.Get(urunId);
                    if (urun != null)
                    {
                        txtIskonto.Text = urun.Iskonto.ToString();
                        txtKdv.Text = urun.Kdv.ToString();
                        txtStokMiktari.Text = urun.StokMiktari.ToString();
                        txtUrunAdi.Text = urun.UrunAdi.ToString();
                        txtUrunFiyati.Text = urun.UrunFiyati.ToString();
                        rtbUrunAciklamasi.Text = urun.Aciklama;
                        cbDurum.Checked = urun.Aktif;
                        lblEklenmeTarihi.Text = urun.EklenmeTarihi.ToString();
                        cbUrunKategorisi.SelectedValue = urun.KategoriId;
                        cbUrunMarkasi.SelectedValue = urun.MarkaId;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Atanırken Hata Oluştu!");
            }
        }

        private void cbDurum_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUrunFiyati_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void markaYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkaYonetimi markaYonetimi = new MarkaYonetimi();
            this.Close();
            markaYonetimi.ShowDialog();
        }

        private void kategoriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KategoriYonetimi kategoriYonetimi = new KategoriYonetimi();
            this.Close();
            kategoriYonetimi.ShowDialog();
        }

        private void kullanıcıYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciYonetimi kullaniciYonetimi = new KullaniciYonetimi();
            this.Close();
            kullaniciYonetimi.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
