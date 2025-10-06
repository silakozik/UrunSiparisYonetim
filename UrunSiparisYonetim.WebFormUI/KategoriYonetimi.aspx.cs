using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UrunSiparisYonetim.WebFormUI
{
    public partial class KategoriYonetimi : System.Web.UI.Page
    {
        KategoriManager manager = new KategoriManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvKategoriler.DataSource = manager.GetAll();
            dgvKategoriler.DataBind();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
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
                if (sonuc > 0)
                {
                    Response.Redirect("KategoriYonetimi.aspx");
                    //Yukle();
                    //MessageBox.Show("Kayıt Eklendi!");
                }
                else lblMesaj.Text = "Kayıt Eklenemedi!";
            }
            catch (Exception hata)
            {
                lblMesaj.Text = "Hata Oluştu! Kayıt Eklenemedi!";
                //MessageBox.Show("Hata Oluştu! Kayıt Eklenemedi!n\\Boş Alan Bırakmadan Tekrar Deneyin! ");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(lblId.Text);
                if (id > 0)
                {
                    var sonuc = manager.Update(
                    new Kategori
                    {
                        Id = id,
                        KategoriAdi = txtKategoriAdi.Text,
                        Aciklamasi = txtKategoriAciklamasi.Text,
                        Aktif = cbDurum.Checked,
                        EklenmeTarihi = Convert.ToDateTime(lblEklenmeTarihi.Text),
                    }
                    );
                    if (sonuc > 0)
                    {
                        Response.Redirect("KategoriYonetimi.aspx");
                    }
                }
                else ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('Lütfen Güncellenecek Kaydı Seçiniz!')</script>");
            }
            catch (Exception hata)
            {
                lblMesaj.Text = "Hata Oluştu! Kayıt Güncellenemedi!";
                //MessageBox.Show("Hata Oluştu! Kayıt Güncellenemedi!n\\Boş Alan Bırakmadan Tekrar Deneyin! ");
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}