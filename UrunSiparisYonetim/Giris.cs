using BL;
using System;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        KullaniciManager manager = new KullaniciManager();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Boş Geçilemez!");
            }
            else
            {
                var kullanici = manager.Find(k => k.KullaniciAdi == txtKullaniciAdi.Text && k.Sifre == txtSifre.Text && k.Aktif == true);
                if (kullanici != null)
                {
                    Menu menu = new Menu();
                    this.Hide();
                    menu.Show();
                }
                else MessageBox.Show("Giriş Başarısız!");
            }               
        }
    }
}
