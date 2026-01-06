using BL;
using Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class MusteriUrunleriGoruntule : Form
    {
        private Musteri _musteri;
        private UrunManager _urunManager;
        private KategoriManager _kategoriManager;
        private MarkaManager _markaManager;

        public MusteriUrunleriGoruntule(Musteri musteri)
        {
            InitializeComponent();
            _musteri = musteri;
            _urunManager = new UrunManager();
            _kategoriManager = new KategoriManager();
            _markaManager = new MarkaManager();
            Yukle();
        }

        void Yukle()
        {
            // Sadece aktif ürünleri göster
            var aktifUrunler = _urunManager.GetAll(u => u.Aktif == true)
                .OrderBy(u => u.UrunAdi)
                .ToList();

            // DataGridView için özel bir liste oluştur
            var urunListesi = aktifUrunler.Select(u => new
            {
                u.Id,
                u.UrunAdi,
                Kategori = u.Kategori?.KategoriAdi ?? "Bilinmiyor",
                Marka = u.Marka?.MarkaAdi ?? "Bilinmiyor",
                u.UrunFiyati,
                u.Kdv,
                u.StokMiktari,
                u.Aciklama
            }).ToList();

            dgvUrunler.DataSource = urunListesi;

            // Kolon başlıklarını Türkçeleştir
            if (dgvUrunler.Columns.Count > 0)
            {
                dgvUrunler.Columns["Id"].HeaderText = "ID";
                dgvUrunler.Columns["UrunAdi"].HeaderText = "Ürün Adı";
                dgvUrunler.Columns["Kategori"].HeaderText = "Kategori";
                dgvUrunler.Columns["Marka"].HeaderText = "Marka";
                dgvUrunler.Columns["UrunFiyati"].HeaderText = "Fiyat";
                dgvUrunler.Columns["Kdv"].HeaderText = "KDV (%)";
                dgvUrunler.Columns["StokMiktari"].HeaderText = "Stok";
                dgvUrunler.Columns["Aciklama"].HeaderText = "Açıklama";

                // Fiyat formatı
                if (dgvUrunler.Columns["UrunFiyati"] != null)
                {
                    dgvUrunler.Columns["UrunFiyati"].DefaultCellStyle.Format = "C2";
                }

                // Stok durumu renklendirme için
                if (dgvUrunler.Columns["StokMiktari"] != null)
                {
                    dgvUrunler.Columns["StokMiktari"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }
            }

            // Filtreleme için kategori ve marka combobox'larını doldur
            var kategoriler = _kategoriManager.GetAll(k => k.Aktif == true);
            cbKategoriFiltre.DataSource = kategoriler;
            cbKategoriFiltre.DisplayMember = "KategoriAdi";
            cbKategoriFiltre.ValueMember = "Id";
            cbKategoriFiltre.SelectedIndex = -1;

            // MarkaManager Repository'den türemediği için GetAll() kullanıp LINQ ile filtreleme yapıyoruz
            var tumMarkalar = _markaManager.GetAll();
            var aktifMarkalar = tumMarkalar.Where(m => m.Aktif == true).ToList();
            cbMarkaFiltre.DataSource = aktifMarkalar;
            cbMarkaFiltre.DisplayMember = "MarkaAdi";
            cbMarkaFiltre.ValueMember = "Id";
            cbMarkaFiltre.SelectedIndex = -1;
        }

        private void cbKategoriFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrele();
        }

        private void cbMarkaFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrele();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            Filtrele();
        }

        void Filtrele()
        {
            var tumUrunler = _urunManager.GetAll(u => u.Aktif == true);

            // Kategori filtresi
            if (cbKategoriFiltre.SelectedItem is Kategori seciliKategori)
            {
                int kategoriId = seciliKategori.Id;
                tumUrunler = tumUrunler.Where(u => u.KategoriId == kategoriId).ToList();
            }

            // Marka filtresi
            if (cbMarkaFiltre.SelectedItem is Marka seciliMarka)
            {
                int markaId = seciliMarka.Id;
                tumUrunler = tumUrunler.Where(u => u.MarkaId == markaId).ToList();
            }

            // Arama filtresi
            if (!string.IsNullOrWhiteSpace(txtArama.Text))
            {
                string arama = txtArama.Text.ToLower();
                tumUrunler = tumUrunler.Where(u => 
                    u.UrunAdi.ToLower().Contains(arama) ||
                    (u.Aciklama != null && u.Aciklama.ToLower().Contains(arama))
                ).ToList();
            }

            // DataGridView'i güncelle
            var urunListesi = tumUrunler.Select(u => new
            {
                u.Id,
                u.UrunAdi,
                Kategori = u.Kategori?.KategoriAdi ?? "Bilinmiyor",
                Marka = u.Marka?.MarkaAdi ?? "Bilinmiyor",
                u.UrunFiyati,
                u.Kdv,
                u.StokMiktari,
                u.Aciklama
            }).ToList();

            dgvUrunler.DataSource = urunListesi;
        }

        private void btnFiltreleriTemizle_Click(object sender, EventArgs e)
        {
            cbKategoriFiltre.SelectedIndex = -1;
            cbMarkaFiltre.SelectedIndex = -1;
            txtArama.Text = string.Empty;
            Filtrele();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUrunler.CurrentRow != null)
            {
                try
                {
                    int urunId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells["Id"].Value);
                    var urun = _urunManager.Get(urunId);
                    
                    if (urun != null)
                    {
                        // Detay bilgilerini göster
                        string detay = $"Ürün Adı: {urun.UrunAdi}\n" +
                                      $"Kategori: {urun.Kategori?.KategoriAdi ?? "Bilinmiyor"}\n" +
                                      $"Marka: {urun.Marka?.MarkaAdi ?? "Bilinmiyor"}\n" +
                                      $"Fiyat: {urun.UrunFiyati:C}\n" +
                                      $"KDV: %{urun.Kdv}\n" +
                                      $"Stok: {urun.StokMiktari}\n" +
                                      $"Açıklama: {urun.Aciklama ?? "Açıklama yok"}";

                        MessageBox.Show(detay, "Ürün Detayı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

