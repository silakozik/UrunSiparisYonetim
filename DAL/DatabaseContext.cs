using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public virtual DbSet<Kategori> Kategoriler { get; set; } 
        public virtual DbSet<Kullanici> Kullanicilar { get; set; } 
        public virtual DbSet<Marka> Markalar { get; set; } 
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Siparis> Siparisler { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
            //yukarýdaki kod veritabanýnda oluþacak olan tablolara s takýsý gelmemesi için
            base.OnModelCreating(modelBuilder);
        }

        //migration : veritabaný güncelleme 
        public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
        //DropCreateDatabaseIfModelChanges<DatabaseContext>
        //CreateDatabaseIfNotExists eðer veritabaný yoksa oluþturur. DatabaseContext içindeki dbset lere göre
        {
            protected override void Seed(DatabaseContext context)
                //seed metodu veritabaný oluþturulduktan sonra devreye girip iþlem yapmamýzý saðlar
            {
                if (!context.Kullanicilar.Any())
                {
                    context.Kullanicilar.Add(
                        new Kullanici()
                        {
                            Aktif = true,
                            KullaniciAdi = "Admin",
                            Sifre = "123456"
                        }
                        );              
                    context.SaveChanges();
                }
                base.Seed(context);
            }
        }
    }
}

/* 
 * Migration iþlemleri ile veritabanýný silmeden tablolarý güncelleyebilir veya tabloda class'larda 
   yaptýðýmýz deðiþiklikleri kullanarak güncelleme yapabiliyoruz. 
 
Migration’u aktif etmek için yapýlacaklar:
 1- Öncelikle PMC (Package Manager Console) kapalý ise onu VS'nin üst menüsünde 
    View > Other Windows > Package Manager Console yolunu kullanarak aktif ediyoruz. 
    PMC ile komutlar kullanarak paket yükleme (Entity Framework vb), migration iþlemleri yapýlabilir.
 2- PMC ekranýnda komut çalýþtýracaðýmýz projeyi (DAL katmaný) Default Project alanýndan seçiyoruz. 
    EF’nin bu katmanda yüklü olmasý gerekir!
 3- Komut satýrýna enable-migrations komutunu yazýp Enter ile çalýþtýrýrýz. 
    DAL katmanýnda Migrations klasörü ve içindeki class’lar oluþmalý. 
    Ýþlem baþarýlý ise tamam. Baþarýsýz olursa EF sürümünü son sürüme almayý dene. 
    Yine olmazsa sürüm düþürmeyi dene. Katmanlardaki EF sürümlerinin ayný sürüm olduðundan emin ol.
 4- Oluþan Migrations’ý veritabanýna uygulamak için PMC’ye update-database yazýp Enter’a basmamýz gerek.
 5- Daha sonra model class’larýmýzda yapacaðýmýz deðiþiklik sonrasý veritabanýný güncellemek için 
    Add-Migration MigrationIsmi þeklinde migration’a bir isim vererek Enter’a basýyoruz.
 6- Eklediðimiz Migration’ý iþlemek için yine update-database komutunu çalýþtýrýyoruz.
 */