using System;
using System.Windows.Forms;
using Entities;
using BL; // DAL yerine BL kullanıyoruz
using System.Linq;

namespace UrunSiparisYonetim
{
    public partial class MusteriParaYukle : Form
    {
        private Musteri _musteri;

        public MusteriParaYukle(Musteri musteri)
        {
            InitializeComponent();
            _musteri = musteri;
            ThemeManager.ApplyBaseTheme(this);
        }

        private void btnYukle_Click(object sender, EventArgs e)
        {
            decimal miktar = nudMiktar.Value;

            if (miktar <= 0)
            {
                MessageBox.Show("Lütfen 0'dan büyük bir miktar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Business Layer üzerinden işlem yapıyoruz
                using (MusteriManager manager = new MusteriManager())
                {
                    // Müşteriyi veritabanından bul ve güncelle
                    var dbMusteri = manager.Get(_musteri.Id);
                    if (dbMusteri != null)
                    {
                        dbMusteri.Bakiye += miktar;
                        manager.Update(dbMusteri); // Update metodu SaveChanges'i de çağırır
                        
                        // Bellekteki nesneyi de güncelle
                        _musteri.Bakiye = dbMusteri.Bakiye;
                        
                        MessageBox.Show($"{miktar:C2} başarıyla yüklendi. Güncel Bakiyeniz: {_musteri.Bakiye:C2}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Müşteri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
