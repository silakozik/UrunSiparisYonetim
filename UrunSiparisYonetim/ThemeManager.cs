using System.Drawing;
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

        public static void ApplyBaseTheme(Form form)
        {
            if (form == null) return;

            form.BackColor = BackgroundColor;

            foreach (Control control in form.Controls)
            {
                ApplyControlTheme(control);
            }
        }

        private static void ApplyControlTheme(Control control)
        {
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
                groupBox.ForeColor = PrimaryColor;
                groupBox.BackColor = Color.Transparent;
            }
            else if (control is Label label)
            {
                label.ForeColor = PrimaryColor;
                label.BackColor = Color.Transparent;
            }

            // İç kontroller için de uygula
            foreach (Control child in control.Controls)
            {
                ApplyControlTheme(child);
            }
        }
    }
}

