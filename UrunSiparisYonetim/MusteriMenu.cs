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
            this.Resize += MusteriMenu_Resize;
            CenterControls();
        }

        private void btnAnaMenu_Click(object sender, EventArgs e)
        {
            // Müşteri menüsünden ana giriş ekranına dön
            this.Hide();
            Giris giris = new Giris();
            giris.Show();
        }

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
            int buttonHeight = 60;
            int buttonSpacing = 14;
            int totalButtonWidth = (buttonWidth * 3) + (buttonSpacing * 2);
            int startX = (this.ClientSize.Width - totalButtonWidth) / 2;
            
            // İlk satır butonları
            btnSiparisVer.Location = new System.Drawing.Point(startX, 148);
            btnSiparislerim.Location = new System.Drawing.Point(startX + buttonWidth + buttonSpacing, 148);
            btnUrunleriGoruntule.Location = new System.Drawing.Point(startX + (buttonWidth + buttonSpacing) * 2, 148);
            
            // Çıkış butonunu ortala
            btnCikis.Location = new System.Drawing.Point((this.ClientSize.Width - buttonWidth) / 2, 243);
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

