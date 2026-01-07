namespace UrunSiparisYonetim
{
    partial class MusteriMenu
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
            this.btnSiparisVer = new System.Windows.Forms.Button();
            this.btnSiparislerim = new System.Windows.Forms.Button();
            this.btnUrunleriGoruntule = new System.Windows.Forms.Button();
            this.btnParaYukle = new System.Windows.Forms.Button(); // NEW
            this.btnCikis = new System.Windows.Forms.Button();
            this.lblMusteriBilgi = new System.Windows.Forms.Label();
            this.lblBakiye = new System.Windows.Forms.Label(); // NEW
            // this.btnAnaMenu = new System.Windows.Forms.Button(); // REMOVED
            this.SuspendLayout();
            // 
            // btnSiparisVer
            // 
            this.btnSiparisVer.Location = new System.Drawing.Point(144, 148);
            this.btnSiparisVer.Name = "btnSiparisVer";
            this.btnSiparisVer.Size = new System.Drawing.Size(120, 60);
            this.btnSiparisVer.TabIndex = 0;
            this.btnSiparisVer.Text = "Sipariş Ver";
            this.btnSiparisVer.UseVisualStyleBackColor = true;
            this.btnSiparisVer.Click += new System.EventHandler(this.btnSiparisVer_Click);
            // 
            // btnSiparislerim
            // 
            this.btnSiparislerim.Location = new System.Drawing.Point(278, 148);
            this.btnSiparislerim.Name = "btnSiparislerim";
            this.btnSiparislerim.Size = new System.Drawing.Size(120, 60);
            this.btnSiparislerim.TabIndex = 1;
            this.btnSiparislerim.Text = "Siparişlerim";
            this.btnSiparislerim.UseVisualStyleBackColor = true;
            this.btnSiparislerim.Click += new System.EventHandler(this.btnSiparislerim_Click);
            // 
            // btnUrunleriGoruntule
            // 
            this.btnUrunleriGoruntule.Location = new System.Drawing.Point(411, 148);
            this.btnUrunleriGoruntule.Name = "btnUrunleriGoruntule";
            this.btnUrunleriGoruntule.Size = new System.Drawing.Size(120, 60);
            this.btnUrunleriGoruntule.TabIndex = 2;
            this.btnUrunleriGoruntule.Text = "Ürünleri Görüntüle";
            this.btnUrunleriGoruntule.UseVisualStyleBackColor = true;
            this.btnUrunleriGoruntule.UseVisualStyleBackColor = true;
            this.btnUrunleriGoruntule.Click += new System.EventHandler(this.btnUrunleriGoruntule_Click);
            // 
            // btnParaYukle
            // 
            this.btnParaYukle.Location = new System.Drawing.Point(544, 148);
            this.btnParaYukle.Name = "btnParaYukle";
            this.btnParaYukle.Size = new System.Drawing.Size(120, 60);
            this.btnParaYukle.TabIndex = 3;
            this.btnParaYukle.Text = "Para Yükle";
            this.btnParaYukle.UseVisualStyleBackColor = true;
            this.btnParaYukle.Click += new System.EventHandler(this.btnParaYukle_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(278, 243);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(120, 60);
            this.btnCikis.TabIndex = 3;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // lblMusteriBilgi
            // 
            this.lblMusteriBilgi.AutoSize = true;
            this.lblMusteriBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMusteriBilgi.Location = new System.Drawing.Point(200, 50);
            this.lblMusteriBilgi.Name = "lblMusteriBilgi";
            this.lblMusteriBilgi.Size = new System.Drawing.Size(200, 25);
            this.lblMusteriBilgi.TabIndex = 4;
            this.lblMusteriBilgi.Text = "Hoş Geldiniz, Müşteri";
            this.lblMusteriBilgi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMusteriBilgi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBakiye
            // 
            this.lblBakiye.AutoSize = true;
            this.lblBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBakiye.Location = new System.Drawing.Point(200, 85);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(110, 20);
            this.lblBakiye.TabIndex = 6;
            this.lblBakiye.Text = "Bakiye: 0.00 TL";
            this.lblBakiye.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 
            // btnAnaMenu - REMOVED
            //
            // 
            // MusteriMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 450);
            // this.Controls.Add(this.btnAnaMenu); // REMOVED
            this.Controls.Add(this.lblMusteriBilgi);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnParaYukle); // NEW
            this.Controls.Add(this.btnUrunleriGoruntule);
            this.Controls.Add(this.btnSiparislerim);
            this.Controls.Add(this.btnSiparisVer);
            this.Controls.Add(this.lblBakiye); // NEW
            this.Name = "MusteriMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Menüsü";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MusteriMenu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSiparisVer;
        private System.Windows.Forms.Button btnSiparislerim;
        private System.Windows.Forms.Button btnUrunleriGoruntule;
        private System.Windows.Forms.Button btnParaYukle; // NEW
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Label lblMusteriBilgi;
        private System.Windows.Forms.Label lblBakiye; // NEW
        // private System.Windows.Forms.Button btnAnaMenu; // REMOVED
    }
}


