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
            
            ThemeManager.ApplyBaseTheme(this);
            this.Resize += MusteriSiparisVer_Resize;
            CenterControls();
            
            Yukle();
        }

        private void MusteriSiparisVer_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            // GroupBox'ı ortala
            int contentHeight = groupBox1.Height + btnSiparisVer.Height + 20;
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = (this.ClientSize.Height - contentHeight) / 2;

            // Butonları GroupBox'ın altına ortala
            int totalButtonWidth = btnIptal.Width + 10 + btnSiparisVer.Width;
            int startX = (this.ClientSize.Width - totalButtonWidth) / 2;

            // Buton sıralaması: İptal - Sipariş Ver (Tasarımda bu sıra ile eklenmiş button click eventlerine göre)
            // Ancak button locations: btnSiparisVer (350, 330), btnIptal (230, 330). Iptal solda.
            
            btnIptal.Location = new System.Drawing.Point(startX, groupBox1.Bottom + 10);
            btnSiparisVer.Location = new System.Drawing.Point(btnIptal.Right + 10, groupBox1.Bottom + 10);
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
            lblBakiye.Text = $"Bakiye: {_musteri.Bakiye:C}";
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

                // Bakiye kontrolü
                if (_musteri.Bakiye < toplamTutar)
                {
                    MessageBox.Show($"Yetersiz bakiye!\nMevcut Bakiyeniz: {_musteri.Bakiye:C}\nSipariş Tutarı: {toplamTutar:C}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                    // Bakiye güncelleme
                    _musteri.Bakiye -= toplamTutar;
                    MusteriManager musteriManager = new MusteriManager();
                    musteriManager.Update(_musteri);
                    
                    lblBakiye.Text = $"Bakiye: {_musteri.Bakiye:C}";

                    MessageBox.Show($"Siparişiniz başarıyla oluşturuldu!\nSipariş No: {siparisNo}\nToplam Tutar: {toplamTutar:C}\nKalan Bakiye: {_musteri.Bakiye:C}", 
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


