using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunSiparisYonetim
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Arka plan görselini yükle
            LoadBackgroundImage();

            Application.Run(new Giris());
        }

        /// <summary>
        /// Arka plan görselini yükler. Önce Images klasöründe, sonra uygulama dizininde arar.
        /// </summary>
        private static void LoadBackgroundImage()
        {
            // Proje klasörünün yolunu bul (Application.StartupPath genellikle bin/Debug veya bin/Release)
            string startupPath = Application.StartupPath;
            string projectPath = startupPath;
            
            // Eğer bin/Debug veya bin/Release içindeysek, proje klasörüne çık
            if (startupPath.EndsWith("bin\\Debug") || startupPath.EndsWith("bin\\Release") || 
                startupPath.EndsWith("bin/Debug") || startupPath.EndsWith("bin/Release"))
            {
                projectPath = Directory.GetParent(Directory.GetParent(startupPath).FullName).FullName;
            }

            // Önce belirli isimleri ara
            string[] possiblePaths = new[]
            {
                // Proje klasöründeki Images
                Path.Combine(projectPath, "Images", "background.jpg"),
                Path.Combine(projectPath, "Images", "background.png"),
                Path.Combine(projectPath, "Images", "arkaplan.jpg"),
                Path.Combine(projectPath, "Images", "arkaplan.png"),
                // Bin klasöründeki Images
                Path.Combine(startupPath, "Images", "background.jpg"),
                Path.Combine(startupPath, "Images", "background.png"),
                Path.Combine(startupPath, "Images", "arkaplan.jpg"),
                Path.Combine(startupPath, "Images", "arkaplan.png"),
                // Doğrudan proje ve bin klasörlerinde
                Path.Combine(projectPath, "background.jpg"),
                Path.Combine(projectPath, "background.png"),
                Path.Combine(startupPath, "background.jpg"),
                Path.Combine(startupPath, "background.png")
            };

            foreach (string path in possiblePaths)
            {
                if (File.Exists(path))
                {
                    ThemeManager.SetBackgroundImage(path);
                    return;
                }
            }

            // Belirli isimler bulunamazsa, Images klasöründeki ilk görsel dosyasını kullan
            string[] imageFolders = new[]
            {
                Path.Combine(projectPath, "Images"),
                Path.Combine(startupPath, "Images")
            };

            string[] imageExtensions = new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif" };

            foreach (string folder in imageFolders)
            {
                if (Directory.Exists(folder))
                {
                    foreach (string extension in imageExtensions)
                    {
                        string[] files = Directory.GetFiles(folder, extension);
                        if (files.Length > 0)
                        {
                            ThemeManager.SetBackgroundImage(files[0]);
                            // Debug: Görsel yüklendiğini göster (geliştirme sırasında)
                            System.Diagnostics.Debug.WriteLine($"Arka plan görseli yüklendi: {files[0]}");
                            return;
                        }
                    }
                }
            }
            
            // Debug: Görsel bulunamadı
            System.Diagnostics.Debug.WriteLine("Arka plan görseli bulunamadı!");
        }
    }
}
