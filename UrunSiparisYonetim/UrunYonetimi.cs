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
            dgvUrunler.AutoGenerateColumns = false;
            dgvUrunler.DataSource = manager.GetAll();
            cbUrunKategorisi.DataSource = kategoriManager.GetAll();
            cbUrunMarkasi.DataSource = markaManager.GetAll();   
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
            if (!string.IsNullOrWhiteSpace(txtUrunFiyati.Text))
            {
                try
                {
                    var sonuc = manager.Add(
                        new Urun
                        {
                            UrunAdi = txtUrunAdi.Text,
                            UrunFiyati = decimal.Parse(txtUrunFiyati.Text),
                            Aciklama = rtbUrunAciklamasi.Text,
                            Aktif = cbDurum.Checked,
                            EklenmeTarihi = DateTime.Now,
                            Iskonto = int.Parse(txtIskonto.Text),
                            Kdv = int.Parse(txtKdv.Text),
                            StokMiktari = int.Parse(txtStokMiktari.Text),
                            ToptanFiyat = int.Parse(txtUrunFiyati.Text),
                            KategoriId = int.Parse(cbUrunKategorisi.SelectedValue.ToString()),
                            MarkaId = int.Parse(cbUrunMarkasi.SelectedValue.ToString()),
                        }
                        );
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Eklendi!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hata Oluştu! Kayıt Eklenemedi!");
                }
            }
            else MessageBox.Show("Ürün Fiyatı Boş Geçilemez!");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUrunFiyati.Text))
            {
                try
                {
                    int urunId = Convert.ToInt32(lblId.Text);
                    if (urunId > 0)
                    {
                        var sonuc = manager.Update(
                        new Urun
                        {
                            Id = urunId,
                            UrunAdi = txtUrunAdi.Text,
                            UrunFiyati = decimal.Parse(txtUrunFiyati.Text),
                            Aciklama = rtbUrunAciklamasi.Text,
                            Aktif = cbDurum.Checked,
                            EklenmeTarihi = DateTime.Now,
                            Iskonto = int.Parse(txtIskonto.Text),
                            Kdv = int.Parse(txtKdv.Text),
                            StokMiktari = int.Parse(txtStokMiktari.Text),
                            ToptanFiyat = int.Parse(txtUrunFiyati.Text),
                            KategoriId = int.Parse(cbUrunKategorisi.SelectedValue.ToString()),
                            MarkaId = int.Parse(cbUrunMarkasi.SelectedValue.ToString()),
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
                catch (Exception)
                {
                    MessageBox.Show("Hata Oluştu! Kayıt Güncellenemedi! Lütfen Tüm Alanları Doldurup Tekrar Deneyiniz!");
                }
            }
            else MessageBox.Show("Ürün Fiyatı Boş Geçilemez!");
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
