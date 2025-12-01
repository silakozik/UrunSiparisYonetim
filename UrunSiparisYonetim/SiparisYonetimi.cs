using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class SiparisYonetimi : Form
    {
        public SiparisYonetimi()
        {
            InitializeComponent();
        }

        SiparisManager manager = new SiparisManager();  
        MusteriManager musteri = new MusteriManager();  
        UrunManager urun = new UrunManager();  

        void Yukle()
        {
            var siparisler = manager.GetAll().OrderByDescending(s => s.SiparisTarihi).ToList();
            dgvSiparisler.DataSource = siparisler;

            cbMusteriler.DataSource = musteri.GetAll();
            cbMusteriler.DisplayMember = "Adi";
            cbMusteriler.ValueMember = "Id";

            cbUrunler.DataSource = urun.GetAll(u => u.Aktif == true);
            cbUrunler.DisplayMember = "UrunAdi";
            cbUrunler.ValueMember = "Id";

            // Navigation property kolonlarını kaldır
            if (dgvSiparisler.Columns["Urun"] != null)
                dgvSiparisler.Columns.Remove("Urun");
            if (dgvSiparisler.Columns["Musteri"] != null)
                dgvSiparisler.Columns.Remove("Musteri");

            // Kolon başlıklarını Türkçeleştir
            if (dgvSiparisler.Columns["Id"] != null)
                dgvSiparisler.Columns["Id"].HeaderText = "ID";
            if (dgvSiparisler.Columns["SiparisNo"] != null)
                dgvSiparisler.Columns["SiparisNo"].HeaderText = "Sipariş No";
            if (dgvSiparisler.Columns["MusteriId"] != null)
                dgvSiparisler.Columns["MusteriId"].HeaderText = "Müşteri ID";
            if (dgvSiparisler.Columns["UrunId"] != null)
                dgvSiparisler.Columns["UrunId"].HeaderText = "Ürün ID";
            if (dgvSiparisler.Columns["Miktar"] != null)
                dgvSiparisler.Columns["Miktar"].HeaderText = "Miktar";
            if (dgvSiparisler.Columns["ToplamTutar"] != null)
            {
                dgvSiparisler.Columns["ToplamTutar"].HeaderText = "Toplam Tutar";
                dgvSiparisler.Columns["ToplamTutar"].DefaultCellStyle.Format = "C2";
            }
            if (dgvSiparisler.Columns["Durum"] != null)
                dgvSiparisler.Columns["Durum"].HeaderText = "Durum";
            if (dgvSiparisler.Columns["SiparisTarihi"] != null)
            {
                dgvSiparisler.Columns["SiparisTarihi"].HeaderText = "Sipariş Tarihi";
                dgvSiparisler.Columns["SiparisTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }

        void Temizle()
        {
            txtSiparisNo.Text = string.Empty;
            txtMiktar.Text = string.Empty;
            txtToplamTutar.Text = string.Empty;
            cbDurum.SelectedIndex = -1;
            cbUrunler.SelectedIndex = -1;
            cbMusteriler.SelectedIndex = -1;
            lblId.Text = "0";
        }

        private void SiparisYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSiparisNo.Text))
                {
                    MessageBox.Show("Sipariş No boş geçilemez!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbMusteriler.SelectedValue == null || cbUrunler.SelectedValue == null)
                {
                    MessageBox.Show("Müşteri ve Ürün seçilmelidir!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int miktar = string.IsNullOrWhiteSpace(txtMiktar.Text) ? 1 : int.Parse(txtMiktar.Text);
                if (miktar <= 0)
                {
                    MessageBox.Show("Miktar 0'dan büyük olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int urunId = Convert.ToInt32(cbUrunler.SelectedValue);
                var secilenUrun = urun.Get(urunId);
                
                if (miktar > secilenUrun.StokMiktari)
                {
                    MessageBox.Show("Yeterli stok bulunmamaktadır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Toplam tutar hesaplama
                decimal toplamTutar = 0;
                if (!string.IsNullOrWhiteSpace(txtToplamTutar.Text))
                {
                    toplamTutar = decimal.Parse(txtToplamTutar.Text);
                }
                else
                {
                    // Otomatik hesapla
                    decimal birimFiyat = secilenUrun.UrunFiyati;
                    decimal araToplam = birimFiyat * miktar;
                    decimal kdvTutari = araToplam * secilenUrun.Kdv / 100;
                    toplamTutar = araToplam + kdvTutari;
                }

                string durum = cbDurum.SelectedItem != null ? cbDurum.SelectedItem.ToString() : "Bekliyor";

                var sonuc = manager.Add(
                    new Siparis
                    {
                        MusteriId = Convert.ToInt32(cbMusteriler.SelectedValue),
                        SiparisNo = txtSiparisNo.Text,
                        SiparisTarihi = dtpSiparisTarihi.Value,
                        UrunId = urunId,
                        Miktar = miktar,
                        ToplamTutar = toplamTutar,
                        Durum = durum
                    }
                    );
                if (sonuc > 0)
                {
                    // Stok güncelleme
                    secilenUrun.StokMiktari -= miktar;
                    urun.Update(secilenUrun);

                    Yukle();       
                    Temizle();
                    MessageBox.Show("Kayıt Eklendi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Oluştu! Kayıt Eklenemedi!\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listeden Güncellenecek Kaydı Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSiparisNo.Text))
                {
                    MessageBox.Show("Sipariş No boş geçilemez!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbMusteriler.SelectedValue == null || cbUrunler.SelectedValue == null)
                {
                    MessageBox.Show("Müşteri ve Ürün seçilmelidir!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int siparisId = Convert.ToInt32(lblId.Text);
                var eskiSiparis = manager.Get(siparisId);
                
                int miktar = string.IsNullOrWhiteSpace(txtMiktar.Text) ? 1 : int.Parse(txtMiktar.Text);
                if (miktar <= 0)
                {
                    MessageBox.Show("Miktar 0'dan büyük olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int urunId = Convert.ToInt32(cbUrunler.SelectedValue);
                var secilenUrun = urun.Get(urunId);

                // Stok kontrolü (eski siparişin miktarını geri ekle, yeni miktarı çıkar)
                int miktarFarki = miktar - eskiSiparis.Miktar;
                if (miktarFarki > secilenUrun.StokMiktari)
                {
                    MessageBox.Show("Yeterli stok bulunmamaktadır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Toplam tutar hesaplama
                decimal toplamTutar = 0;
                if (!string.IsNullOrWhiteSpace(txtToplamTutar.Text))
                {
                    toplamTutar = decimal.Parse(txtToplamTutar.Text);
                }
                else
                {
                    // Otomatik hesapla
                    decimal birimFiyat = secilenUrun.UrunFiyati;
                    decimal araToplam = birimFiyat * miktar;
                    decimal kdvTutari = araToplam * secilenUrun.Kdv / 100;
                    toplamTutar = araToplam + kdvTutari;
                }

                string durum = cbDurum.SelectedItem != null ? cbDurum.SelectedItem.ToString() : eskiSiparis.Durum;

                var sonuc = manager.Update(
                   new Siparis
                   {
                       Id = siparisId,
                       MusteriId = Convert.ToInt32(cbMusteriler.SelectedValue),
                       SiparisNo = txtSiparisNo.Text,
                       SiparisTarihi = dtpSiparisTarihi.Value,
                       UrunId = urunId,
                       Miktar = miktar,
                       ToplamTutar = toplamTutar,
                       Durum = durum
                   }
                   );
                if (sonuc > 0)
                {
                    // Stok güncelleme
                    secilenUrun.StokMiktari -= miktarFarki;
                    urun.Update(secilenUrun);

                    Yukle();
                    Temizle();
                    MessageBox.Show("Kayıt Güncellendi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Oluştu! Kayıt Güncellenemedi!\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listden Silinecek Kaydı Seçiniz!");
                }
                else
                {
                    var sonuc = manager.Delete(Convert.ToInt32(lblId.Text));
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Kayıt Silindi!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Silinemedi!");
            }
        }

        private void dgvSiparisler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var siparis = manager.Get(Convert.ToInt32(dgvSiparisler.CurrentRow.Cells[0].Value));
                txtSiparisNo.Text = siparis.SiparisNo;
                cbMusteriler.SelectedValue = siparis.MusteriId;
                cbUrunler.SelectedValue = siparis.UrunId;
                dtpSiparisTarihi.Value = siparis.SiparisTarihi;
                txtMiktar.Text = siparis.Miktar.ToString();
                txtToplamTutar.Text = siparis.ToplamTutar.ToString();
                
                // Durum combobox'ını doldur
                if (cbDurum.Items.Count == 0)
                {
                    cbDurum.Items.AddRange(new string[] { "Bekliyor", "Onaylandı", "İptal", "TeslimEdildi" });
                }
                
                if (!string.IsNullOrEmpty(siparis.Durum))
                {
                    int index = cbDurum.Items.IndexOf(siparis.Durum);
                    if (index >= 0)
                        cbDurum.SelectedIndex = index;
                }
                
                lblId.Text = dgvSiparisler.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Oluştu! Kayıt Getirilemedi!\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ürün seçildiğinde otomatik fiyat hesaplama
            if (cbUrunler.SelectedValue != null && !string.IsNullOrWhiteSpace(txtMiktar.Text))
            {
                try
                {
                    int urunId = Convert.ToInt32(cbUrunler.SelectedValue);
                    var secilenUrun = urun.Get(urunId);
                    int miktar = int.Parse(txtMiktar.Text);
                    
                    if (miktar > 0 && secilenUrun != null)
                    {
                        decimal birimFiyat = secilenUrun.UrunFiyati;
                        decimal araToplam = birimFiyat * miktar;
                        decimal kdvTutari = araToplam * secilenUrun.Kdv / 100;
                        decimal toplamTutar = araToplam + kdvTutari;
                        
                        txtToplamTutar.Text = toplamTutar.ToString("F2");
                    }
                }
                catch { }
            }
        }

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {
            // Miktar değiştiğinde otomatik fiyat hesaplama
            if (cbUrunler.SelectedValue != null && !string.IsNullOrWhiteSpace(txtMiktar.Text))
            {
                try
                {
                    int urunId = Convert.ToInt32(cbUrunler.SelectedValue);
                    var secilenUrun = urun.Get(urunId);
                    int miktar = int.Parse(txtMiktar.Text);
                    
                    if (miktar > 0 && secilenUrun != null)
                    {
                        decimal birimFiyat = secilenUrun.UrunFiyati;
                        decimal araToplam = birimFiyat * miktar;
                        decimal kdvTutari = araToplam * secilenUrun.Kdv / 100;
                        decimal toplamTutar = araToplam + kdvTutari;
                        
                        txtToplamTutar.Text = toplamTutar.ToString("F2");
                    }
                }
                catch { }
            }
        }
    }
}
