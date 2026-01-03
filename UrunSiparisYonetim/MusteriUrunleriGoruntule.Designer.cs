namespace UrunSiparisYonetim
{
    partial class MusteriUrunleriGoruntule
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
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltreleriTemizle = new System.Windows.Forms.Button();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMarkaFiltre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKategoriFiltre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKapat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(12, 120);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.RowHeadersWidth = 51;
            this.dgvUrunler.RowTemplate.Height = 24;
            this.dgvUrunler.Size = new System.Drawing.Size(1000, 400);
            this.dgvUrunler.TabIndex = 0;
            this.dgvUrunler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrunler_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFiltreleriTemizle);
            this.groupBox1.Controls.Add(this.txtArama);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMarkaFiltre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbKategoriFiltre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtreleme ve Arama";
            // 
            // btnFiltreleriTemizle
            // 
            this.btnFiltreleriTemizle.Location = new System.Drawing.Point(850, 60);
            this.btnFiltreleriTemizle.Name = "btnFiltreleriTemizle";
            this.btnFiltreleriTemizle.Size = new System.Drawing.Size(120, 30);
            this.btnFiltreleriTemizle.TabIndex = 6;
            this.btnFiltreleriTemizle.Text = "Filtreleri Temizle";
            this.btnFiltreleriTemizle.UseVisualStyleBackColor = true;
            this.btnFiltreleriTemizle.Click += new System.EventHandler(this.btnFiltreleriTemizle_Click);
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(600, 30);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(200, 22);
            this.txtArama.TabIndex = 5;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Arama";
            // 
            // cbMarkaFiltre
            // 
            this.cbMarkaFiltre.FormattingEnabled = true;
            this.cbMarkaFiltre.Location = new System.Drawing.Point(300, 30);
            this.cbMarkaFiltre.Name = "cbMarkaFiltre";
            this.cbMarkaFiltre.Size = new System.Drawing.Size(200, 24);
            this.cbMarkaFiltre.TabIndex = 3;
            this.cbMarkaFiltre.SelectedIndexChanged += new System.EventHandler(this.cbMarkaFiltre_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Marka";
            // 
            // cbKategoriFiltre
            // 
            this.cbKategoriFiltre.FormattingEnabled = true;
            this.cbKategoriFiltre.Location = new System.Drawing.Point(100, 30);
            this.cbKategoriFiltre.Name = "cbKategoriFiltre";
            this.cbKategoriFiltre.Size = new System.Drawing.Size(200, 24);
            this.cbKategoriFiltre.TabIndex = 1;
            this.cbKategoriFiltre.SelectedIndexChanged += new System.EventHandler(this.cbKategoriFiltre_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kategori";
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(900, 530);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(100, 40);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // MusteriUrunleriGoruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 582);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvUrunler);
            this.Name = "MusteriUrunleriGoruntule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürünleri Görüntüle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKategoriFiltre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMarkaFiltre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnFiltreleriTemizle;
        private System.Windows.Forms.Button btnKapat;
    }
}





