using BL;
using Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class MusteriSiparisVer : Form
    {
        private Musteri _musteri;
        private SiparisManager _siparisManager;
        private UrunManager _urunManager;

        public MusteriSiparisVer(Musteri musteri)
        {
            InitializeComponent();
            _musteri = musteri;
            _siparisManager = new SiparisManager();
            _urunManager = new UrunManager();
            Yukle();
        }

        void Yukle()
        {
            // Sadece aktif ve stokta olan ürünleri göster
            var aktifUrunler = _urunManager.GetAll(u => u.Aktif == true && u.StokMiktari > 0);
            cbUrunler.DisplayMember = "UrunAdi";
            cbUrunler.ValueMember = "Id";
            cbUrunler.DataSource = aktifUrunler;
            cbUrunler.SelectedIndex = -1;

            // Varsayılan değerler
            txtMiktar.Text = "1";
            txtMiktar_TextChanged(null, null);
        }

        private void cbUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUrunler.SelectedValue != null && cbUrunler.SelectedValue is int)
            {
                int urunId = (int)cbUrunler.SelectedValue;
                var urun = _urunManager.Get(urunId);
                if (urun != null)
                {
                    lblUrunFiyati.Text = $"Birim Fiyat: {urun.UrunFiyati:C}";
                    lblStokMiktari.Text = $"Stok: {urun.StokMiktari}";
                    lblKdv.Text = $"KDV: %{urun.Kdv}";
                    txtMiktar_TextChanged(null, null);
                }
            }
        }

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {
            if (cbUrunler.SelectedValue != null && !string.IsNullOrWhiteSpace(txtMiktar.Text))
            {
                try
                {
                    int miktar = int.Parse(txtMiktar.Text);

                    
                    if (!(cbUrunler.SelectedValue is int)) return;
                    int urunId = (int)cbUrunler.SelectedValue;
                    var urun = _urunManager.Get(urunId);

                    if (urun != null && miktar > 0)
                    {
                        // Stok kontrolü
                        if (miktar > urun.StokMiktari)
                        {
                            lblToplamTutar.Text = "Stok yetersiz!";
                            lblToplamTutar.ForeColor = System.Drawing.Color.Red;
                            btnSiparisVer.Enabled = false;
                            return;
                        }

                        // Toplam tutar hesaplama (KDV dahil)
                        decimal birimFiyat = urun.UrunFiyati;
                        decimal araToplam = birimFiyat * miktar;
                        decimal kdvTutari = araToplam * urun.Kdv / 100;
                        decimal toplamTutar = araToplam + kdvTutari;

                        lblToplamTutar.Text = $"Toplam: {toplamTutar:C}";
                        lblToplamTutar.ForeColor = System.Drawing.Color.Black;
                        btnSiparisVer.Enabled = true;
                    }
                    else
                    {
                        lblToplamTutar.Text = "Geçersiz miktar!";
                        lblToplamTutar.ForeColor = System.Drawing.Color.Red;
                        btnSiparisVer.Enabled = false;
                    }
                }
                catch
                {
                    lblToplamTutar.Text = "Geçersiz miktar!";
                    lblToplamTutar.ForeColor = System.Drawing.Color.Red;
                    btnSiparisVer.Enabled = false;
                }
            }
            else
            {
                lblToplamTutar.Text = "";
                btnSiparisVer.Enabled = false;
            }
        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbUrunler.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen bir ürün seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMiktar.Text))
                {
                    MessageBox.Show("Lütfen miktar giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int miktar = int.Parse(txtMiktar.Text);
                if (!(cbUrunler.SelectedValue is int))
                {
                     MessageBox.Show("Lütfen geçerli bir ürün seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                }
                int urunId = (int)cbUrunler.SelectedValue;
                var urun = _urunManager.Get(urunId);

                if (miktar <= 0)
                {
                    MessageBox.Show("Miktar 0'dan büyük olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (miktar > urun.StokMiktari)
                {
                    MessageBox.Show("Yeterli stok bulunmamaktadır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Toplam tutar hesaplama
                decimal birimFiyat = urun.UrunFiyati;
                decimal araToplam = birimFiyat * miktar;
                decimal kdvTutari = araToplam * urun.Kdv / 100;
                decimal toplamTutar = araToplam + kdvTutari;

                // Sipariş numarası oluştur
                string siparisNo = "SP-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Sipariş oluştur
                var siparis = new Siparis
                {
                    SiparisNo = siparisNo,
                    MusteriId = _musteri.Id,
                    UrunId = urunId,
                    Miktar = miktar,
                    ToplamTutar = toplamTutar,
                    Durum = "Bekliyor",
                    SiparisTarihi = DateTime.Now
                };

                var sonuc = _siparisManager.Add(siparis);

                if (sonuc > 0)
                {
                    // Stok güncelleme
                    urun.StokMiktari -= miktar;
                    _urunManager.Update(urun);

                    MessageBox.Show($"Siparişiniz başarıyla oluşturuldu!\nSipariş No: {siparisNo}\nToplam Tutar: {toplamTutar:C}", 
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sipariş oluşturulamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


