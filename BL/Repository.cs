using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace BL
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class, IEntity, new()
        //Repository<T> sınıfımız T tipinde yani (Urun.cs, Kategori.cs gibi) parametre alacak : IRepository<T>
        //kısmı interface'imizdeki metot imzalarını burada kullanmamızı sağlıyor, where T kısmı repository e
        //gönderilecek olan sınıf için bazı şartlar belirlememizi sağlıyor bunlar : class (gönderilecek T bir class olmalı
        //yani referans tipli olmalı), IEntity (bu sınıf IEntity interface i ile implemente edilmiş olmalı),
        //new() (T olarak gönderilecek sınıf new lenebilir bir sınıf olmalı string gibi bir yapı gönderilememeli)
        //IDisposable: DatabaseContext'i düzgün dispose etmek için implement edildi
    {
        private DatabaseContext context; //private olarak DatabaseContext sınıfımızdan context adında boş bir nesne oluşturduk
        private DbSet<T> _objectSet; //private olarak DatabaseContext sınıfımız içerisinde kullandığımız Dbset lere karşılık
                                     //gelen fakat parametre olarak Urun, marka vb classları yerine T alan bir nesne oluşturduk
        private bool disposed = false; //Dispose işleminin yapılıp yapılmadığını takip eder

        public Repository()
        {
            context = new DatabaseContext(); //Her Repository instance'ı için yeni bir DatabaseContext oluştur
            _objectSet = context.Set<T>(); // _objectSet nesnemizi DatabaseContext örneği olan context içindeki classlara
                                           // ayarladık,T yerine gelen class buraya yerleşecek
        }
        public int Add(T entity)
        {
            _objectSet.Add(entity); //T olarak gelecek olan class'ı
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            _objectSet.Remove(Get(id));
            return context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> expression) //Metodumuzun ismi T Find geriye T kısmına gönderilecek
          //tipte bir kayıt dönecek(Expression<Func<T, bool>> expression) bu kısım bu metoda parametre olarak where
          //şartı yollamamızı sağlar, bu sayede herhangi bir class için ilgili veritabanı kayıtlarında linq ile sorgulama
          //yaparak istediğimiz kaydı sorgulayabiliriz.
        {
            return _objectSet.FirstOrDefault(expression); //FirstOrDefault entity framework te linq ile sorgulanarak
          //veritabanındaki ilk kaydı döndüren, kayıt bulamazsa null döndüren metottur, biz de bu metoda parametre ile
          //expression daki sorgumuzu gönderip bu sorguya uyan kaydı arayacağız.
        }

        public T Get(int id) //Bu metot parametre olarak kendisine gelen id ye uyan
                             //T(Urun.cs, Marka.cs vb) yi EF in Find metoduyla bulup geri döndürür.
        {
            return _objectSet.Find(id); //Find metodu id ye uyan kaydı bize getirecek.
        }

        public List<T> GetAll() //T kısmına gelecek olan class’a ait verilerin tümünü bize getirecek metot.
        {
            return _objectSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression) //Bu metotta parametre olarak expression’a
          //gönderilecek linq sorgusu sayesinde tüm kayıtlar yerine sadece istediğimiz kayıtları çekerek verileri
          //daha performanslı ve istediğimiz şekilde elde edebilmemizi sağlar.
        {
            return _objectSet.Where(expression).ToList(); //Metodun parametresinde gönderilen expression içindeki
          //linq sorgusu ToList’ten önceki where koşuluna yerleştiriliyor bu sayede önce filtre uygulanıp sonra
          //kayıtlar listelenerek geri gönderiliyor.
        }

        public int Update(T entity)
        {
            _objectSet.AddOrUpdate(entity);
            return context.SaveChanges(); 
        }

        // IDisposable Pattern Implementation - DatabaseContext'i düzgün dispose etmek için
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //Finalizer'ın çağrılmasını engeller çünkü kaynakları zaten temizledik
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Yönetilen kaynakları temizle (DatabaseContext)
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                    _objectSet = null;
                }
                disposed = true;
            }
        }

        // Finalizer - Eğer Dispose çağrılmazsa garbage collector tarafından çağrılır
        ~Repository()
        {
            Dispose(false);
        }
    }
}
