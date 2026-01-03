using BL;
using Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class Giris : Form
    {
        private bool isAdmin = false; // Kullanıcı tipini belirler (true=Admin, false=Müşteri)

        public Giris()
        {
            InitializeComponent();
            // İlk açılışta giriş panelini gizle, seçim panelini göster
            groupBoxGiris.Visible = false;
            groupBoxSecim.Visible = true;
            this.Resize += Giris_Resize;
            CenterControls();
        }

        private void Giris_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            // GroupBox'ları ortala
            if (groupBoxSecim.Visible)
            {
                groupBoxSecim.Left = (this.ClientSize.Width - groupBoxSecim.Width) / 2;
                groupBoxSecim.Top = (this.ClientSize.Height - groupBoxSecim.Height) / 2;
            }
            if (groupBoxGiris.Visible)
            {
                groupBoxGiris.Left = (this.ClientSize.Width - groupBoxGiris.Width) / 2;
                groupBoxGiris.Top = (this.ClientSize.Height - groupBoxGiris.Height) / 2;
            }
        }

        public Giris(bool adminGirisi) : this()
        {
            isAdmin = adminGirisi;
            // Direkt giriş formu açılacaksa (parametreli constructor)
            if (adminGirisi || !adminGirisi)
            {
                groupBoxSecim.Visible = false;
                groupBoxGiris.Visible = true;
                this.Text = adminGirisi ? "Admin Girişi" : "Müşteri Girişi";
                groupBoxGiris.Text = adminGirisi ? "Admin Girişi" : "Müşteri Girişi";
            }
        }

        KullaniciManager manager = new KullaniciManager();
        
        private void EnsureAdminUserExists()
        {
            try
            {
                // Admin kullanıcısının var olup olmadığını kontrol et
                var adminKullanici = manager.Find(k => k.KullaniciAdi == "Admin");
                if (adminKullanici == null)
                {
                    // Admin kullanıcısı yoksa ekle
                    var yeniAdmin = new Kullanici()
                    {
                        Aktif = true,
                        KullaniciAdi = "Admin",
                        Sifre = "123456",
                        Adi = "Admin",
                        Soyadi = " ",
                        Email = "admin@urunsiparisyonetim.com",
                    };
                    manager.Add(yeniAdmin);
                }
            }
            catch
            {
                // Hata durumunda sessizce devam et - veritabanı şema hatası olabilir
            }
        }

        private void btnAdminGiris_Click(object sender, EventArgs e)
        {
            // Admin giriş formunu göster
            isAdmin = true;
            groupBoxSecim.Visible = false;
            groupBoxGiris.Visible = true;
            this.Text = "Admin Girişi";
            groupBoxGiris.Text = "Admin Girişi";
            // Kayıt Ol butonunu admin girişinde gizle
            btnKayitOl.Visible = false;
            // Admin girişinde label'ı Kullanıcı Adı olarak ayarla
            label1.Text = "Kullanıcı Adı";
            // Şifre alanını göster
            txtSifre.Visible = true;
            label3.Visible = true;
        }

        private void btnMusteriGiris_Click(object sender, EventArgs e)
        {
            // Müşteri giriş formunu göster
            isAdmin = false;
            groupBoxSecim.Visible = false;
            groupBoxGiris.Visible = true;
            this.Text = "Müşteri Girişi";
            groupBoxGiris.Text = "Müşteri Girişi";
            // Kayıt Ol butonunu sadece müşteri girişinde göster
            btnKayitOl.Visible = true;
            // Müşteri girişinde label'ı E-posta olarak değiştir
            label1.Text = "E-posta";
            // Şifre alanını gizle (müşteri girişinde şifre yok)
            txtSifre.Visible = false;
            label3.Visible = false;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                // Admin girişi - Kullanıcı adı ve şifre kontrolü
                if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
                {
                    MessageBox.Show("Kullanıcı Adı ve Şifre Boş Geçilemez!");
                }
                else
                {
                    // Önce admin kullanıcısının var olup olmadığını kontrol et, yoksa ekle
                    EnsureAdminUserExists();
                    
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
            else
            {
                // Müşteri girişi - Sadece e-posta kontrolü
                if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
                {
                    MessageBox.Show("E-posta Boş Geçilemez!");
                }
                else
                {
                    MusteriManager musteriManager = new MusteriManager();
                    var musteri = musteriManager.Find(m => m.Email == txtKullaniciAdi.Text);
                    
                    // Şimdilik müşteri için şifre kontrolü yok (Entities'de şifre alanı yok)
                    // İleride Musteri entity'sine şifre eklenebilir
                    if (musteri != null)
                    {
                        MusteriMenu musteriMenu = new MusteriMenu(musteri);
                        this.Hide();
                        musteriMenu.Show();
                    }
                    else MessageBox.Show("E-posta bulunamadı! Lütfen önce kayıt olun.");
                }
            }               
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            // Geri butonuna tıklandığında seçim ekranına dön
            groupBoxGiris.Visible = false;
            groupBoxSecim.Visible = true;
            txtKullaniciAdi.Text = string.Empty;
            txtSifre.Text = string.Empty;
            btnKayitOl.Visible = false;
            // Label ve şifre alanını varsayılan haline döndür
            label1.Text = "Kullanıcı Adı";
            txtSifre.Visible = true;
            label3.Visible = true;
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            // Kayıt Ol butonuna tıklandığında müşteri kayıt formunu aç
            MusteriKayit musteriKayit = new MusteriKayit();
            var result = musteriKayit.ShowDialog();
            
            // Kayıt başarılı olursa e-posta alanını otomatik doldur
            if (result == DialogResult.OK)
            {
                // TODO: Kayıt olunan e-postayı buraya doldurabiliriz
                // txtKullaniciAdi.Text = musteriKayit.Email;
            }
        }
    }
}
