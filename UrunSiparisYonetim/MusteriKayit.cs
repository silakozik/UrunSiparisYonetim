using BL;
using Entities;
using System;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class MusteriKayit : Form
    {
        public MusteriKayit()
        {
            InitializeComponent();
        }

        MusteriManager manager = new MusteriManager();

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasyon kontrolü
                if (string.IsNullOrWhiteSpace(txtAdi.Text) || string.IsNullOrWhiteSpace(txtSoyadi.Text))
                {
                    MessageBox.Show("Lütfen Ad ve Soyad alanlarını doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Email kontrolü - Email zorunlu ve unique olmalı
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("E-posta adresi zorunludur!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Email format kontrolü (basit)
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("Geçerli bir e-posta adresi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Email unique kontrolü
                var existingMusteri = manager.Find(m => m.Email == txtEmail.Text.Trim());
                if (existingMusteri != null)
                {
                    MessageBox.Show("Bu e-posta adresi ile daha önce kayıt oluşturulmuştur!\nLütfen farklı bir e-posta adresi kullanın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kayıt işlemi
                var sonuc = manager.Add(
                    new Musteri
                    {
                        Adi = txtAdi.Text.Trim(),
                        Soyadi = txtSoyadi.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Telefon = txtTelefon.Text.Trim(),
                        Adres = txtAdres.Text.Trim(),
                    }
                );

                if (sonuc > 0)
                {
                    MessageBox.Show($"Kayıt başarıyla oluşturuldu!\nHoş geldiniz {txtAdi.Text} {txtSoyadi.Text}!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kayıt oluşturulurken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Temizle()
        {
            txtAdi.Text = string.Empty;
            txtSoyadi.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtAdres.Text = string.Empty;
        }
    }
}
