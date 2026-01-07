using BL;
using Entities;
using System;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseTheme(this);
            this.Resize += KategoriYonetimi_Resize;
            CenterControls();
        }

        private void KategoriYonetimi_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            int spacing = 20;
            // DataGridView ve GroupBox'ın toplam genişliği
            int totalWidth = dgvKategoriler.Width + spacing + groupBox1.Width;
            
            // Başlangıç X noktası
            int startX = (this.ClientSize.Width - totalWidth) / 2;
            
            // Eğer pencere çok daralırsa (örn: mobilden daha küçük), sola yasla
            if (startX < 10) startX = 10;

            // DataGridView Konumu
            dgvKategoriler.Left = startX;
            // Dikeyde ortala ama MenuStrip'e (30px) pay bırak
            int dgvY = (this.ClientSize.Height - dgvKategoriler.Height) / 2;
            if (dgvY < 40) dgvY = 40; 
            dgvKategoriler.Top = dgvY;

            // GroupBox Konumu (DataGridView'in sağına)
            groupBox1.Left = dgvKategoriler.Right + spacing;
            // GroupBox'ı dikeyde ortala
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
        }

        KategoriManager manager = new KategoriManager();

        void Yukle()
        {
            dgvKategoriler.DataSource = manager.GetAll();
        }

        void Temizle()
        {
            txtKategoriAdi.Text = string.Empty;
            txtKategoriAciklamasi.Text = string.Empty;  
            lblEklenmeTarihi.Text = string.Empty;   
            lblId.Text = "0";
            cbDurum.Checked = false;
        }

        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                    new Kategori 
                    {
                        KategoriAdi = txtKategoriAdi.Text,
                        Aciklamasi = txtKategoriAciklamasi.Text,
                        Aktif = cbDurum.Checked,
                        EklenmeTarihi = DateTime.Now,
                    }
                    );
                if(sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Eklendi!");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata Oluştu! Kayıt Eklenemedi!n\\Boş Alan Bırakmadan Tekrar Deneyin! ");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Update(
                    new Kategori
                    {
                        Id = int.Parse(lblId.Text),
                        KategoriAdi = txtKategoriAdi.Text,
                        Aciklamasi = txtKategoriAciklamasi.Text,
                        Aktif = cbDurum.Checked,
                        EklenmeTarihi = Convert.ToDateTime(lblEklenmeTarihi.Text),  
                    }
                    );
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Güncellendi!");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata Oluştu! Kayıt Güncellenemedi!n\\Boş Alan Bırakmadan Tekrar Deneyin! ");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if(lblId.Text == "0")
                {
                    MessageBox.Show("Listeden Silinecek Kaydı Seçiniz!");
                }
                else
                {
                    var sonuc = manager.Delete(int.Parse(lblId.Text));
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Güncellendi!");
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu! Kayıt Silinemedi! ");
            }
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblId.Text = dgvKategoriler.CurrentRow.Cells[0].Value.ToString();
                txtKategoriAdi.Text = dgvKategoriler.CurrentRow.Cells[1].Value.ToString();
                if(dgvKategoriler.CurrentRow.Cells[2].Value != null) txtKategoriAciklamasi.Text = dgvKategoriler.CurrentRow.Cells[2].Value.ToString();
                lblEklenmeTarihi.Text = dgvKategoriler.CurrentRow.Cells[3].Value.ToString();
                cbDurum.Checked = Convert.ToBoolean(dgvKategoriler.CurrentRow.Cells[4].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Atanırken Hata Oluştu!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void markaYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkaYonetimi markaYonetimi = new MarkaYonetimi();  
            this.Close();   
            markaYonetimi.ShowDialog(); 
        }

        private void kullanıcıYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciYonetimi kullaniciYonetimi = new KullaniciYonetimi();
            this.Close();
            kullaniciYonetimi.ShowDialog();
        }
    }
}

