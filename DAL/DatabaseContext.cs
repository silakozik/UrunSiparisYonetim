using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            // Migration'ları geçici olarak devre dışı bırak - veritabanı şema hatası nedeniyle
            // Admin kullanıcısı Giris.cs dosyasında kontrol edilip eklenecek
            Database.SetInitializer<DatabaseContext>(null);
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
            //yukar�daki kod veritaban�nda olu�acak olan tablolara s tak�s� gelmemesi i�in
            base.OnModelCreating(modelBuilder);
        }

        //migration : veritaban� g�ncelleme 
        public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
        //DropCreateDatabaseIfModelChanges<DatabaseContext>
        //CreateDatabaseIfNotExists e�er veritaban� yoksa olu�turur. DatabaseContext i�indeki dbset lere g�re
        {
            protected override void Seed(DatabaseContext context)
                //seed metodu veritaban� olu�turulduktan sonra devreye girip i�lem yapmam�z� sa�lar
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
 * Migration i�lemleri ile veritaban�n� silmeden tablolar� g�ncelleyebilir veya tabloda class'larda 
   yapt���m�z de�i�iklikleri kullanarak g�ncelleme yapabiliyoruz. 
 
Migration�u aktif etmek i�in yap�lacaklar:
 1- �ncelikle PMC (Package Manager Console) kapal� ise onu VS'nin �st men�s�nde 
    View > Other Windows > Package Manager Console yolunu kullanarak aktif ediyoruz. 
    PMC ile komutlar kullanarak paket y�kleme (Entity Framework vb), migration i�lemleri yap�labilir.
 2- PMC ekran�nda komut �al��t�raca��m�z projeyi (DAL katman�) Default Project alan�ndan se�iyoruz. 
    EF�nin bu katmanda y�kl� olmas� gerekir!
 3- Komut sat�r�na enable-migrations komutunu yaz�p Enter ile �al��t�r�r�z. 
    DAL katman�nda Migrations klas�r� ve i�indeki class�lar olu�mal�. 
    ��lem ba�ar�l� ise tamam. Ba�ar�s�z olursa EF s�r�m�n� son s�r�me almay� dene. 
    Yine olmazsa s�r�m d���rmeyi dene. Katmanlardaki EF s�r�mlerinin ayn� s�r�m oldu�undan emin ol.
 4- Olu�an Migrations�� veritaban�na uygulamak i�in PMC�ye update-database yaz�p Enter�a basmam�z gerek.
 5- Daha sonra model class�lar�m�zda yapaca��m�z de�i�iklik sonras� veritaban�n� g�ncellemek i�in 
    Add-Migration MigrationIsmi �eklinde migration�a bir isim vererek Enter�a bas�yoruz.
 6- Ekledi�imiz Migration�� i�lemek i�in yine update-database komutunu �al��t�r�yoruz.
 */