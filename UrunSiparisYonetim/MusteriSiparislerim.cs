using BL;
using Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class MusteriSiparislerim : Form
    {
        private Musteri _musteri;
        private SiparisManager _siparisManager;
        private UrunManager _urunManager;

        public MusteriSiparislerim(Musteri musteri)
        {
            InitializeComponent();
            _musteri = musteri;
            _siparisManager = new SiparisManager();
            _urunManager = new UrunManager();
            
            ThemeManager.ApplyBaseTheme(this);
            this.Resize += MusteriSiparislerim_Resize;
            CenterControls();
            
            Yukle();
        }

        private void MusteriSiparislerim_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            int spacing = 15;
            // Toplam yükseklik
            int totalHeight = dgvSiparisler.Height + spacing + lblToplamSiparis.Height + 5; 
            // Label'lar ve button aynı hizada yaklaşık olarak
            int startY = (this.ClientSize.Height - totalHeight) / 2;
            if (startY < 10) startY = 10;

            // X ortalama
            int startX_Grid = (this.ClientSize.Width - dgvSiparisler.Width) / 2;
            
            // Konumlandırma
            dgvSiparisler.Location = new System.Drawing.Point(startX_Grid, startY);
            
            // Altbilgiler
            int bottomY = dgvSiparisler.Bottom + spacing;
            lblToplamSiparis.Location = new System.Drawing.Point(startX_Grid, bottomY + 10);
            lblToplamTutar.Location = new System.Drawing.Point(lblToplamSiparis.Right + 20, bottomY + 10);
            
            btnKapat.Location = new System.Drawing.Point(dgvSiparisler.Right - btnKapat.Width, bottomY);
        }

        void Yukle()
        {
            // Müşterinin siparişlerini getir
            var siparisler = _siparisManager.GetAll(s => s.MusteriId == _musteri.Id)
                .OrderByDescending(s => s.SiparisTarihi)
                .ToList();

            // DataGridView için özel bir liste oluştur
            var siparisListesi = siparisler.Select(s => new
            {
                s.Id,
                s.SiparisNo,
                UrunAdi = s.Urun?.UrunAdi ?? "Bilinmiyor",
                s.Miktar,
                s.ToplamTutar,
                s.Durum,
                s.SiparisTarihi
            }).ToList();

            dgvSiparisler.DataSource = siparisListesi;

            // Kolon başlıklarını Türkçeleştir
            if (dgvSiparisler.Columns.Count > 0)
            {
                dgvSiparisler.Columns["Id"].HeaderText = "ID";
                dgvSiparisler.Columns["SiparisNo"].HeaderText = "Sipariş No";
                dgvSiparisler.Columns["UrunAdi"].HeaderText = "Ürün";
                dgvSiparisler.Columns["Miktar"].HeaderText = "Miktar";
                dgvSiparisler.Columns["ToplamTutar"].HeaderText = "Toplam Tutar";
                dgvSiparisler.Columns["Durum"].HeaderText = "Durum";
                dgvSiparisler.Columns["SiparisTarihi"].HeaderText = "Sipariş Tarihi";

                // Toplam tutar formatı
                if (dgvSiparisler.Columns["ToplamTutar"] != null)
                {
                    dgvSiparisler.Columns["ToplamTutar"].DefaultCellStyle.Format = "C2";
                }

                // Tarih formatı
                if (dgvSiparisler.Columns["SiparisTarihi"] != null)
                {
                    dgvSiparisler.Columns["SiparisTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
            }

            // Toplam sipariş sayısı ve toplam tutar
            int toplamSiparis = siparisler.Count;
            decimal toplamTutar = siparisler.Sum(s => s.ToplamTutar);
            lblToplamSiparis.Text = $"Toplam Sipariş: {toplamSiparis}";
            lblToplamTutar.Text = $"Toplam Tutar: {toplamTutar:C}";
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSiparisler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSiparisler.CurrentRow != null)
            {
                try
                {
                    int siparisId = Convert.ToInt32(dgvSiparisler.CurrentRow.Cells["Id"].Value);
                    var siparis = _siparisManager.Get(siparisId);
                    
                    if (siparis != null)
                    {
                        var urun = _urunManager.Get(siparis.UrunId);
                        
                        // Detay bilgilerini göster
                        string detay = $"Sipariş No: {siparis.SiparisNo}\n" +
                                      $"Ürün: {urun?.UrunAdi ?? "Bilinmiyor"}\n" +
                                      $"Miktar: {siparis.Miktar}\n" +
                                      $"Birim Fiyat: {urun?.UrunFiyati:C ?? 0:C}\n" +
                                      $"KDV: %{urun?.Kdv ?? 0}\n" +
                                      $"Toplam Tutar: {siparis.ToplamTutar:C}\n" +
                                      $"Durum: {siparis.Durum}\n" +
                                      $"Sipariş Tarihi: {siparis.SiparisTarihi:dd.MM.yyyy HH:mm}";

                        MessageBox.Show(detay, "Sipariş Detayı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}


