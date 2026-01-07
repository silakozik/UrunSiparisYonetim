namespace UrunSiparisYonetim
{
    partial class MusteriSiparisVer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.lblBakiye = new System.Windows.Forms.Label();
            this.lblKdv = new System.Windows.Forms.Label();
            this.lblStokMiktari = new System.Windows.Forms.Label();
            this.lblUrunFiyati = new System.Windows.Forms.Label();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUrunler = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSiparisVer = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblToplamTutar);
            this.groupBox1.Controls.Add(this.lblBakiye);
            this.groupBox1.Controls.Add(this.lblKdv);
            this.groupBox1.Controls.Add(this.lblStokMiktari);
            this.groupBox1.Controls.Add(this.lblUrunFiyati);
            this.groupBox1.Controls.Add(this.txtMiktar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbUrunler);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(32, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sipariş Bilgileri";
            // 
            // lblBakiye
            // 
            this.lblBakiye.AutoSize = true;
            this.lblBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBakiye.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblBakiye.Location = new System.Drawing.Point(200, 250);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(0, 25);
            this.lblBakiye.TabIndex = 9;
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamTutar.Location = new System.Drawing.Point(200, 220);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(0, 25);
            this.lblToplamTutar.TabIndex = 8;
            // 
            // lblKdv
            // 
            this.lblKdv.AutoSize = true;
            this.lblKdv.Location = new System.Drawing.Point(200, 180);
            this.lblKdv.Name = "lblKdv";
            this.lblKdv.Size = new System.Drawing.Size(0, 16);
            this.lblKdv.TabIndex = 7;
            // 
            // lblStokMiktari
            // 
            this.lblStokMiktari.AutoSize = true;
            this.lblStokMiktari.Location = new System.Drawing.Point(200, 150);
            this.lblStokMiktari.Name = "lblStokMiktari";
            this.lblStokMiktari.Size = new System.Drawing.Size(0, 16);
            this.lblStokMiktari.TabIndex = 6;
            // 
            // lblUrunFiyati
            // 
            this.lblUrunFiyati.AutoSize = true;
            this.lblUrunFiyati.Location = new System.Drawing.Point(200, 120);
            this.lblUrunFiyati.Name = "lblUrunFiyati";
            this.lblUrunFiyati.Size = new System.Drawing.Size(0, 16);
            this.lblUrunFiyati.TabIndex = 5;
            // 
            // txtMiktar
            // 
            this.txtMiktar.Location = new System.Drawing.Point(200, 80);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(200, 22);
            this.txtMiktar.TabIndex = 4;
            this.txtMiktar.TextChanged += new System.EventHandler(this.txtMiktar_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Miktar";
            // 
            // cbUrunler
            // 
            this.cbUrunler.FormattingEnabled = true;
            this.cbUrunler.Location = new System.Drawing.Point(200, 40);
            this.cbUrunler.Name = "cbUrunler";
            this.cbUrunler.Size = new System.Drawing.Size(200, 24);
            this.cbUrunler.TabIndex = 2;
            this.cbUrunler.SelectedIndexChanged += new System.EventHandler(this.cbUrunler_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ürün";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // btnSiparisVer
            // 
            this.btnSiparisVer.Location = new System.Drawing.Point(350, 330);
            this.btnSiparisVer.Name = "btnSiparisVer";
            this.btnSiparisVer.Size = new System.Drawing.Size(100, 40);
            this.btnSiparisVer.TabIndex = 1;
            this.btnSiparisVer.Text = "Sipariş Ver";
            this.btnSiparisVer.UseVisualStyleBackColor = true;
            this.btnSiparisVer.Click += new System.EventHandler(this.btnSiparisVer_Click);
            this.btnSiparisVer.Enabled = false;
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(230, 330);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(100, 40);
            this.btnIptal.TabIndex = 2;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // MusteriSiparisVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 400);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnSiparisVer);
            this.Controls.Add(this.groupBox1);
            this.Name = "MusteriSiparisVer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sipariş Ver";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbUrunler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label lblUrunFiyati;
        private System.Windows.Forms.Label lblStokMiktari;
        private System.Windows.Forms.Label lblKdv;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.Label lblBakiye;
        private System.Windows.Forms.Button btnSiparisVer;
        private System.Windows.Forms.Button btnIptal;
    }
}


