using BL;
using Entities;
using System;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class MusteriYonetimi : Form
    {
        public MusteriYonetimi()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseTheme(this);
            this.Resize += MusteriYonetimi_Resize;
            CenterControls();
        }

        private void MusteriYonetimi_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            int spacing = 20;
            // DataGridView ve GroupBox'ın toplam genişliği
            int totalWidth = dgvMusteriler.Width + spacing + groupBox1.Width;
            
            // Başlangıç X noktası
            int startX = (this.ClientSize.Width - totalWidth) / 2;
            
            // Sola yaslama kontrolü
            if (startX < 10) startX = 10;

            // DataGridView Konumu
            dgvMusteriler.Left = startX;
            int dgvY = (this.ClientSize.Height - dgvMusteriler.Height) / 2;
            if (dgvY < 40) dgvY = 40; 
            dgvMusteriler.Top = dgvY;

            // GroupBox Konumu
            groupBox1.Left = dgvMusteriler.Right + spacing;
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
        }

        MusteriManager manager = new MusteriManager();

        void Yukle()
        {
            dgvMusteriler.DataSource = manager.GetAll();
        }

        void Temizle()
        {
            txtAdi.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtAdres.Text = string.Empty;
            txtSoyadi.Text = string.Empty;
            lblId.Text = "0";
        }

        private void MusteriYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAdi.Text) || string.IsNullOrWhiteSpace(txtSoyadi.Text))
                {
                    MessageBox.Show("Lütfen * İşaretli Alanları Doldurunuz!");
                }
                else
                {
                    var sonuc = manager.Add(
                    new Musteri
                    {
                        Adi = txtAdi.Text,
                        Soyadi = txtSoyadi.Text,
                        Email = txtEmail.Text,
                        Telefon = txtTelefon.Text,
                        Adres = txtAdres.Text,
                    }
                    );
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Eklendi!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Eklenemedi!");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAdi.Text) || string.IsNullOrWhiteSpace(txtSoyadi.Text))
                {
                    MessageBox.Show("Lütfen * İşaretli Alanları Doldurunuz!");
                }
                else
                {
                    if (lblId.Text == "0")
                    {
                        MessageBox.Show("Listeden Güncellenecek Kaydı Seçiniz!");
                    }
                    else
                    {
                        var sonuc = manager.Update(
                        new Musteri
                        {
                            Id = Convert.ToInt32(lblId.Text),
                            Adi = txtAdi.Text,
                            Soyadi = txtSoyadi.Text,
                            Email = txtEmail.Text,
                            Telefon = txtTelefon.Text,
                            Adres = txtAdres.Text,
                        }
                        );
                        if (sonuc > 0)
                        {
                            Temizle();
                            Yukle();
                            MessageBox.Show("Kayıt Güncellendi!");
                        }
                    }                       
                }                  
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Güncellenemedi!");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblId.Text = dgvMusteriler.CurrentRow.Cells[0].Value.ToString();
                txtAdi.Text = dgvMusteriler.CurrentRow.Cells[1].Value.ToString();
                txtSoyadi.Text = dgvMusteriler.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = dgvMusteriler.CurrentRow.Cells[3].Value.ToString();
                txtTelefon.Text = dgvMusteriler.CurrentRow.Cells[4].Value.ToString();
                txtAdres.Text = dgvMusteriler.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listeden Silinecek Kaydı Seçiniz!");
                }
                else
                {
                    var sonuc = manager.Delete(Convert.ToInt32(lblId.Text));
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Silindi!");
                    }
                    else MessageBox.Show("Kayıt Silinemedi!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void markaYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkaYonetimi markaYonetimi = new MarkaYonetimi();
            this.Close();
            markaYonetimi.ShowDialog();
        }

        private void kategoriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KategoriYonetimi kategoriYonetimi = new KategoriYonetimi();
            this.Close();
            kategoriYonetimi.ShowDialog();
        }
    }
}