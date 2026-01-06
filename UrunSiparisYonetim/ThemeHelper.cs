using System.Drawing;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    public static class ThemeHelper
    {
        // Tema renkleri
        public static readonly Color BackgroundColor = ColorTranslator.FromHtml("#F4F6F8");   // Açık gri / kırık beyaz
        public static readonly Color PrimaryColor    = ColorTranslator.FromHtml("#1F3A5F");   // Koyu mavi / lacivert
        public static readonly Color AccentColor     = ColorTranslator.FromHtml("#2ECC71");   // Yeşil (vurgu)

        public static void ApplyTheme(Form form)
        {
            if (form == null) return;

            // Form arka planı
            form.BackColor = BackgroundColor;

            // Tüm kontrolleri dolaş
            ApplyThemeToControlCollection(form.Controls);
        }

        private static void ApplyThemeToControlCollection(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                ApplyThemeToControl(control);

                // İç içe kontrolleri de gez
                if (control.HasChildren)
                {
                    ApplyThemeToControlCollection(control.Controls);
                }
            }
        }

        private static void ApplyThemeToControl(Control control)
        {
            switch (control)
            {
                case Button btn:
                    btn.BackColor = AccentColor;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = PrimaryColor;
                    btn.FlatAppearance.BorderSize = 1;
                    break;

                case Label lbl:
                    lbl.ForeColor = PrimaryColor;
                    break;

                case GroupBox gb:
                    gb.ForeColor = PrimaryColor;
                    gb.BackColor = BackgroundColor;
                    break;

                case TextBox txt:
                    txt.BackColor = Color.White;
                    txt.ForeColor = PrimaryColor;
                    break;

                default:
                    // Genel varsayılan
                    control.BackColor = control.BackColor == SystemColors.Control
                        ? BackgroundColor
                        : control.BackColor;
                    break;
            }
        }
    }
}


