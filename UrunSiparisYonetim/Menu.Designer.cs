namespace UrunSiparisYonetim
{
    partial class Menu
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
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnKullanici = new System.Windows.Forms.Button();
            this.btnMarka = new System.Windows.Forms.Button();
            this.btnUrun = new System.Windows.Forms.Button();
            this.btnSiparis = new System.Windows.Forms.Button();
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKategori
            // 
            this.btnKategori.Location = new System.Drawing.Point(144, 148);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(90, 60);
            this.btnKategori.TabIndex = 6;
            this.btnKategori.Text = "Kategori Yönetimi";
            this.btnKategori.Click += new System.EventHandler(this.btnKategori_Click);
            // 
            // btnKullanici
            // 
            this.btnKullanici.Location = new System.Drawing.Point(278, 148);
            this.btnKullanici.Name = "btnKullanici";
            this.btnKullanici.Size = new System.Drawing.Size(90, 60);
            this.btnKullanici.TabIndex = 1;
            this.btnKullanici.Text = "Kullanıcı Yönetimi";
            this.btnKullanici.UseVisualStyleBackColor = true;
            this.btnKullanici.Click += new System.EventHandler(this.btnKullanici_Click);
            // 
            // btnMarka
            // 
            this.btnMarka.Location = new System.Drawing.Point(411, 148);
            this.btnMarka.Name = "btnMarka";
            this.btnMarka.Size = new System.Drawing.Size(90, 60);
            this.btnMarka.TabIndex = 2;
            this.btnMarka.Text = "Marka Yönetimi";
            this.btnMarka.UseVisualStyleBackColor = true;
            this.btnMarka.Click += new System.EventHandler(this.btnMarka_Click);
            // 
            // btnUrun
            // 
            this.btnUrun.Location = new System.Drawing.Point(411, 243);
            this.btnUrun.Name = "btnUrun";
            this.btnUrun.Size = new System.Drawing.Size(90, 60);
            this.btnUrun.TabIndex = 5;
            this.btnUrun.Text = "Ürün Yönetimi";
            this.btnUrun.UseVisualStyleBackColor = true;
            this.btnUrun.Click += new System.EventHandler(this.btnUrun_Click);
            // 
            // btnSiparis
            // 
            this.btnSiparis.Location = new System.Drawing.Point(278, 243);
            this.btnSiparis.Name = "btnSiparis";
            this.btnSiparis.Size = new System.Drawing.Size(90, 60);
            this.btnSiparis.TabIndex = 4;
            this.btnSiparis.Text = "Siparis Yönetimi";
            this.btnSiparis.UseVisualStyleBackColor = true;
            this.btnSiparis.Click += new System.EventHandler(this.btnSiparis_Click);
            // 
            // btnMusteri
            // 
            this.btnMusteri.Location = new System.Drawing.Point(144, 243);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(90, 60);
            this.btnMusteri.TabIndex = 3;
            this.btnMusteri.Text = "Müşteri Yönetimi";
            this.btnMusteri.UseVisualStyleBackColor = true;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(278, 338);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(90, 60);
            this.btnCikis.TabIndex = 7;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 450);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnUrun);
            this.Controls.Add(this.btnSiparis);
            this.Controls.Add(this.btnMusteri);
            this.Controls.Add(this.btnMarka);
            this.Controls.Add(this.btnKullanici);
            this.Controls.Add(this.btnKategori);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKategori;
        private System.Windows.Forms.Button btnKullanici;
        private System.Windows.Forms.Button btnMarka;
        private System.Windows.Forms.Button btnUrun;
        private System.Windows.Forms.Button btnSiparis;
        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.Button btnCikis;
    }
}