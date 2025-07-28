using BL;
using Entities;
using System;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public partial class UrunYonetimi : Form
    {
        public UrunYonetimi()
        {
            InitializeComponent();
        }
        UrunManager manager =new UrunManager();
        void Yukle()
        {
            dgvUrunler.DataSource = manager.GetAll();
        }

        private void UrunYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                    new Urun
                    {
                        UrunAdi = txtUrunAdi.Text,
                        UrunFiyati = decimal.Parse(txtUrunFiyati.Text),   
                        Aciklama = rtbUrunAciklamasi.Text,  
                        Aktif = cbDurum.Checked,
                        EklenmeTarihi = DateTime.Now,
                        Iskonto = int.Parse(txtIskonto.Text),
                        Kdv = int.Parse(txtKdv.Text),
                        StokMiktari = int.Parse(txtStokMiktari.Text),   
                        ToptanFiyat = int.Parse(txtUrunFiyati.Text),
                    }
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void cbDurum_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUrunFiyati_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
