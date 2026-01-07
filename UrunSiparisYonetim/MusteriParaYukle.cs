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
            this.Resize += MusteriParaYukle_Resize;
            CenterControls();
        }

        private void MusteriParaYukle_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            int spacing = 20;
            // İçerik genişliği: Label + NUD
            int row1Width = lblMiktar.Width + 10 + nudMiktar.Width;
            // Button genişliği
            int row2Width = btnIptal.Width + 10 + btnYukle.Width;

            // Dikeyde ortalama için blok yüksekliği
            int totalHeight = nudMiktar.Height + spacing + btnYukle.Height;
            int startY = (this.ClientSize.Height - totalHeight) / 2;

            // Row 1 (Label + NUD) X ortalama
            int row1StartX = (this.ClientSize.Width - row1Width) / 2;
            lblMiktar.Location = new System.Drawing.Point(row1StartX, startY);
            nudMiktar.Location = new System.Drawing.Point(lblMiktar.Right + 10, startY);

            // Row 2 (Buttons) X ortalama
            int row2StartX = (this.ClientSize.Width - row2Width) / 2;
            int row2Y = lblMiktar.Bottom + spacing;
            btnIptal.Location = new System.Drawing.Point(row2StartX, row2Y);
            btnYukle.Location = new System.Drawing.Point(btnIptal.Right + 10, row2Y);
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
