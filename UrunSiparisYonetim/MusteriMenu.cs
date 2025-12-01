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

