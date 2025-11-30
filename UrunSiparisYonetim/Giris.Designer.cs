namespace UrunSiparisYonetim
{
    partial class Giris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxGiris = new System.Windows.Forms.GroupBox();
            this.btnKayitOl = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGiris = new System.Windows.Forms.Button();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSecim = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMusteriGiris = new System.Windows.Forms.Button();
            this.btnAdminGiris = new System.Windows.Forms.Button();
            this.groupBoxGiris.SuspendLayout();
            this.groupBoxSecim.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxGiris
            // 
            this.groupBoxGiris.Controls.Add(this.btnKayitOl);
            this.groupBoxGiris.Controls.Add(this.btnGeri);
            this.groupBoxGiris.Controls.Add(this.label3);
            this.groupBoxGiris.Controls.Add(this.btnGiris);
            this.groupBoxGiris.Controls.Add(this.txtKullaniciAdi);
            this.groupBoxGiris.Controls.Add(this.txtSifre);
            this.groupBoxGiris.Controls.Add(this.label2);
            this.groupBoxGiris.Controls.Add(this.label1);
            this.groupBoxGiris.Location = new System.Drawing.Point(82, 143);
            this.groupBoxGiris.Name = "groupBoxGiris";
            this.groupBoxGiris.Size = new System.Drawing.Size(286, 241);
            this.groupBoxGiris.TabIndex = 0;
            this.groupBoxGiris.TabStop = false;
            this.groupBoxGiris.Text = "Kullanıcı Girişi";
            // 
            // btnKayitOl
            // 
            this.btnKayitOl.Location = new System.Drawing.Point(149, 199);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new System.Drawing.Size(100, 26);
            this.btnKayitOl.TabIndex = 8;
            this.btnKayitOl.Text = "Kayıt Ol";
            this.btnKayitOl.UseVisualStyleBackColor = true;
            this.btnKayitOl.Visible = false;
            this.btnKayitOl.Click += new System.EventHandler(this.btnKayitOl_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.Location = new System.Drawing.Point(43, 199);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(100, 26);
            this.btnGeri.TabIndex = 7;
            this.btnGeri.Text = "Geri";
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Şifre";
            // 
            // btnGiris
            // 
            this.btnGiris.Location = new System.Drawing.Point(149, 167);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(100, 26);
            this.btnGiris.TabIndex = 1;
            this.btnGiris.Text = "Giriş Yap";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(149, 49);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(100, 22);
            this.txtKullaniciAdi.TabIndex = 4;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(149, 109);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(100, 22);
            this.txtSifre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // groupBoxSecim
            // 
            this.groupBoxSecim.Controls.Add(this.label4);
            this.groupBoxSecim.Controls.Add(this.btnMusteriGiris);
            this.groupBoxSecim.Controls.Add(this.btnAdminGiris);
            this.groupBoxSecim.Location = new System.Drawing.Point(82, 143);
            this.groupBoxSecim.Name = "groupBoxSecim";
            this.groupBoxSecim.Size = new System.Drawing.Size(286, 211);
            this.groupBoxSecim.TabIndex = 1;
            this.groupBoxSecim.TabStop = false;
            this.groupBoxSecim.Text = "Giriş Tipi Seçiniz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(71, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giriş Yapmak İçin";
            // 
            // btnMusteriGiris
            // 
            this.btnMusteriGiris.Location = new System.Drawing.Point(43, 130);
            this.btnMusteriGiris.Name = "btnMusteriGiris";
            this.btnMusteriGiris.Size = new System.Drawing.Size(200, 50);
            this.btnMusteriGiris.TabIndex = 1;
            this.btnMusteriGiris.Text = "Müşteri Girişi";
            this.btnMusteriGiris.UseVisualStyleBackColor = true;
            this.btnMusteriGiris.Click += new System.EventHandler(this.btnMusteriGiris_Click);
            // 
            // btnAdminGiris
            // 
            this.btnAdminGiris.Location = new System.Drawing.Point(43, 74);
            this.btnAdminGiris.Name = "btnAdminGiris";
            this.btnAdminGiris.Size = new System.Drawing.Size(200, 50);
            this.btnAdminGiris.TabIndex = 0;
            this.btnAdminGiris.Text = "Admin Girişi";
            this.btnAdminGiris.UseVisualStyleBackColor = true;
            this.btnAdminGiris.Click += new System.EventHandler(this.btnAdminGiris_Click);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 498);
            this.Controls.Add(this.groupBoxSecim);
            this.Controls.Add(this.groupBoxGiris);
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Ekranı";
            this.groupBoxGiris.ResumeLayout(false);
            this.groupBoxGiris.PerformLayout();
            this.groupBoxSecim.ResumeLayout(false);
            this.groupBoxSecim.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxGiris;
        private System.Windows.Forms.GroupBox groupBoxSecim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdminGiris;
        private System.Windows.Forms.Button btnMusteriGiris;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKayitOl;
    }
}