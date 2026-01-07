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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseTheme(this);
            this.Resize += Menu_Resize;
            CenterControls();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            // Çıkış yap ve giriş ekranına dön (Müşteri panelindeki gibi)
            DialogResult result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Giris giris = new Giris();
                giris.Show();
            }
        }

        private void Menu_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            // Butonları ortala
            int buttonWidth = 90;
            int buttonHeight = 60;
            int buttonSpacingX = 44; // Yatay boşluk
            int buttonSpacingY = 35; // Dikey boşluk
            
            // Tüm buton bloğunun genişliği (3 butonluk genişlik)
            int totalButtonWidth = (buttonWidth * 3) + (buttonSpacingX * 2);
            int startX = (this.ClientSize.Width - totalButtonWidth) / 2;

            // Tüm buton bloğunun yüksekliği (3 satır: 2 satır grid + 1 satır çıkış)
            int totalButtonHeight = (buttonHeight * 3) + (buttonSpacingY * 2);
            int startY = (this.ClientSize.Height - totalButtonHeight) / 2;
            
            // İlk satır butonları
            btnKategori.Location = new System.Drawing.Point(startX, startY);
            btnKullanici.Location = new System.Drawing.Point(startX + buttonWidth + buttonSpacingX, startY);
            btnMarka.Location = new System.Drawing.Point(startX + (buttonWidth + buttonSpacingX) * 2, startY);
            
            // İkinci satır butonları
            int row2Y = startY + buttonHeight + buttonSpacingY;
            btnMusteri.Location = new System.Drawing.Point(startX, row2Y);
            btnSiparis.Location = new System.Drawing.Point(startX + buttonWidth + buttonSpacingX, row2Y);
            btnUrun.Location = new System.Drawing.Point(startX + (buttonWidth + buttonSpacingX) * 2, row2Y);

            // Çıkış butonu - En alta ortala
            int row3Y = row2Y + buttonHeight + buttonSpacingY;
            btnCikis.Location = new System.Drawing.Point((this.ClientSize.Width - buttonWidth) / 2, row3Y);
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            KategoriYonetimi kategoriYonetimi = new KategoriYonetimi();
            kategoriYonetimi.ShowDialog();
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            KullaniciYonetimi kullaniciYonetimi = new KullaniciYonetimi();
            kullaniciYonetimi.ShowDialog();
        }

        private void btnMarka_Click(object sender, EventArgs e)
        {
            MarkaYonetimi markaYonetimi = new MarkaYonetimi();
            markaYonetimi.ShowDialog();     
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            MusteriYonetimi musteriYonetimi = new MusteriYonetimi();
            musteriYonetimi.ShowDialog();
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            SiparisYonetimi siparisYonetimi = new SiparisYonetimi();
            siparisYonetimi.ShowDialog();
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            UrunYonetimi urunYonetimi = new UrunYonetimi();
            urunYonetimi.ShowDialog();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
