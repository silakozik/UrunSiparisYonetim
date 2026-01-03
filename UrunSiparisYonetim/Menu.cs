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
            this.Resize += Menu_Resize;
            CenterControls();
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
            int buttonSpacing = 44;
            int totalButtonWidth = (buttonWidth * 3) + (buttonSpacing * 2);
            int startX = (this.ClientSize.Width - totalButtonWidth) / 2;
            
            // İlk satır butonları
            btnKategori.Location = new System.Drawing.Point(startX, 148);
            btnKullanici.Location = new System.Drawing.Point(startX + buttonWidth + buttonSpacing, 148);
            btnMarka.Location = new System.Drawing.Point(startX + (buttonWidth + buttonSpacing) * 2, 148);
            
            // İkinci satır butonları
            btnMusteri.Location = new System.Drawing.Point(startX, 243);
            btnSiparis.Location = new System.Drawing.Point(startX + buttonWidth + buttonSpacing, 243);
            btnUrun.Location = new System.Drawing.Point(startX + (buttonWidth + buttonSpacing) * 2, 243);
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
