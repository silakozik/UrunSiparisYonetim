using BL;
using Entities;
using System;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class MusteriMenu : Form
    {
        private Musteri _girisYapanMusteri;

        public MusteriMenu(Musteri musteri)
        {
            InitializeComponent();
            _girisYapanMusteri = musteri;
            lblMusteriBilgi.Text = $"Hoş Geldiniz, {musteri.Adi} {musteri.Soyadi}";
            RefreshBakiye();
            ThemeManager.ApplyBaseTheme(this);
            this.Resize += MusteriMenu_Resize;
            CenterControls();
        }

        // Ana Menü butonu kaldırıldı

        private void MusteriMenu_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            // Label'ı ortala
            lblMusteriBilgi.Left = (this.ClientSize.Width - lblMusteriBilgi.Width) / 2;
            
            // Butonları ortala
            int buttonWidth = 120;
            int buttonSpacing = 14;
            
            // Üst satır (3 buton) için genişlik hesapla
            int topRowWidth = (buttonWidth * 3) + (buttonSpacing * 2);
            int startX_Top = (this.ClientSize.Width - topRowWidth) / 2;
            
            // Üst satır butonları
            btnSiparisVer.Location = new System.Drawing.Point(startX_Top, 148);
            btnSiparislerim.Location = new System.Drawing.Point(startX_Top + buttonWidth + buttonSpacing, 148);
            btnUrunleriGoruntule.Location = new System.Drawing.Point(startX_Top + (buttonWidth + buttonSpacing) * 2, 148);

            // Alt satır (2 buton) için genişlik hesapla
            int bottomRowWidth = (buttonWidth * 2) + buttonSpacing;
            int startX_Bottom = (this.ClientSize.Width - bottomRowWidth) / 2;
            int bottomRowY = 230; // 148 + 60 + boşluk

            // Alt satır butonları: Solda Para Yükle, Sağda Çıkış
            btnParaYukle.Location = new System.Drawing.Point(startX_Bottom, bottomRowY);
            btnCikis.Location = new System.Drawing.Point(startX_Bottom + buttonWidth + buttonSpacing, bottomRowY);

            // Bakiye label'ını varsayılan yerine (Müşteri bilgisinin altına) al
            lblBakiye.Left = (this.ClientSize.Width - lblBakiye.Width) / 2;
            lblBakiye.Top = lblMusteriBilgi.Bottom + 10;
        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            // Sipariş verme formunu aç
            MusteriSiparisVer siparisVer = new MusteriSiparisVer(_girisYapanMusteri);
            siparisVer.ShowDialog();
        }

        private void btnSiparislerim_Click(object sender, EventArgs e)
        {
            // Müşterinin siparişlerini görüntüleme formunu aç
            MusteriSiparislerim siparislerim = new MusteriSiparislerim(_girisYapanMusteri);
            siparislerim.ShowDialog();
        }

        private void btnUrunleriGoruntule_Click(object sender, EventArgs e)
        {
            // Ürünleri görüntüleme formunu aç (sadece görüntüleme, sipariş verme için)
            MusteriUrunleriGoruntule urunleriGoruntule = new MusteriUrunleriGoruntule(_girisYapanMusteri);
            urunleriGoruntule.ShowDialog();
        }

        private void btnParaYukle_Click(object sender, EventArgs e)
        {
            using (MusteriParaYukle paraYukle = new MusteriParaYukle(_girisYapanMusteri))
            {
                if (paraYukle.ShowDialog() == DialogResult.OK)
                {
                    RefreshBakiye();
                }
            }
        }

        private void RefreshBakiye()
        {
            lblBakiye.Text = $"Bakiye: {_girisYapanMusteri.Bakiye:C2}";
            CenterControls(); // Label boyutu değişebileceği için tekrar ortala
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            // Çıkış yap ve giriş ekranına dön
            DialogResult result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void MusteriMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Form kapatıldığında giriş ekranına dön
            Giris giris = new Giris();
            giris.Show();
        }
    }
}

