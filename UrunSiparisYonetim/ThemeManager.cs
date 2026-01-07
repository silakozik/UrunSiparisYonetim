using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    /// <summary>
    /// Uygulama genelinde ortak renk paletini uygular.
    /// Arka plan: #1F3A5F
    /// Ana renk (başlıklar, metinler): #F4F6F8
    /// Vurgu (buton hover): #2ECC71 / #1ABC9C
    /// </summary>
    public static class ThemeManager
    {
        // Form arka plan rengi (koyu lacivert)
        private static readonly Color BackgroundColor = ColorTranslator.FromHtml("#1F3A5F");
        // Metin ve başlık rengi (açık gri / kırık beyaz)
        private static readonly Color PrimaryColor = ColorTranslator.FromHtml("#F4F6F8");
        // Buton arka plan rengi (açık gri / kırık beyaz)
        private static readonly Color AccentColor = ColorTranslator.FromHtml("#F4F6F8");
        // Hover rengi: beyaz
        private static readonly Color AccentHoverColor = Color.White;

        // Arka plan görseli
        private static Image backgroundImage = null;
        private static string backgroundImagePath = null;

        /// <summary>
        /// Arka plan görselini dosya yolundan yükler
        /// </summary>
        public static void SetBackgroundImage(string imagePath)
        {
            // Önceki görseli temizle
            if (backgroundImage != null)
            {
                backgroundImage.Dispose();
            }

            if (File.Exists(imagePath))
            {
                try
                {
                    backgroundImage = Image.FromFile(imagePath);
                    backgroundImagePath = imagePath;
                    System.Diagnostics.Debug.WriteLine($"ThemeManager: Arka plan görseli başarıyla yüklendi: {imagePath}");
                }
                catch (Exception ex)
                {
                    backgroundImage = null;
                    backgroundImagePath = null;
                    System.Diagnostics.Debug.WriteLine($"ThemeManager: Görsel yüklenirken hata: {ex.Message}");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"ThemeManager: Görsel dosyası bulunamadı: {imagePath}");
            }
        }

        /// <summary>
        /// Arka plan görselini Image nesnesinden ayarlar
        /// </summary>
        public static void SetBackgroundImage(Image image)
        {
            // Önceki görseli temizle
            if (backgroundImage != null && backgroundImagePath != null)
            {
                backgroundImage.Dispose();
            }

            backgroundImage = image;
            backgroundImagePath = null; // Doğrudan Image nesnesi kullanıldığı için path yok
        }

        /// <summary>
        /// Arka plan görselini temizler
        /// </summary>
        public static void ClearBackgroundImage()
        {
            if (backgroundImage != null)
            {
                backgroundImage.Dispose();
            }
            backgroundImage = null;
            backgroundImagePath = null;
        }

        public static void ApplyBaseTheme(Form form)
        {
            if (form == null) return;

            // Arka plan görseli varsa onu kullan, yoksa renk kullan
            if (backgroundImage != null)
            {
                form.BackgroundImage = backgroundImage;
                form.BackgroundImageLayout = ImageLayout.Stretch;
                // Görselin arka plan rengi olarak eski rengi kullan (görsel yüklenirken gösterilir)
                form.BackColor = BackgroundColor;
                System.Diagnostics.Debug.WriteLine($"ThemeManager: Form'a arka plan görseli uygulandı: {form.Name}");
            }
            else
            {
                form.BackColor = BackgroundColor;
                form.BackgroundImage = null;
                System.Diagnostics.Debug.WriteLine($"ThemeManager: Form'a arka plan rengi uygulandı (görsel yok): {form.Name}");
            }

            foreach (Control control in form.Controls)
            {
                ApplyControlTheme(control);
            }
        }

        private static void ApplyControlTheme(Control control)
        {
            // Arka plan görseli varsa yazıları siyah, yoksa beyaz yap
            Color textColor = backgroundImage != null ? Color.Black : PrimaryColor;

            if (control is Button button)
            {
                button.BackColor = AccentColor;
                // Buton yazısı siyah
                button.ForeColor = Color.Black;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;

                // Hover rengi (WinForms'ta tam kontrol için olay eklemek gerekir;
                // şimdilik sadece border rengini ayarlıyoruz)
                button.FlatAppearance.MouseOverBackColor = AccentHoverColor;
            }
            else if (control is GroupBox groupBox)
            {
                groupBox.ForeColor = textColor;
                groupBox.BackColor = Color.Transparent;
            }
            else if (control is Label label)
            {
                label.ForeColor = textColor;
                label.BackColor = Color.Transparent;
            }
            else if (control is TextBox textBox)
            {
                // TextBox yazı rengi siyah (her zaman okunabilir olmalı)
                textBox.ForeColor = Color.Black;
                textBox.BackColor = Color.White;
            }

            // İç kontroller için de uygula
            foreach (Control child in control.Controls)
            {
                ApplyControlTheme(child);
            }
        }
    }
}

