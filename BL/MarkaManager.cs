using DAL;
using Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BL
{
    public class MarkaManager
    {
        DatabaseContext context = new DatabaseContext();

        public List<Marka> GetAll() //veritabanındaki tüm markaları döndüren metod
        {
            return context.Markalar.ToList();
        }

        public Marka Get(int id) //sadece id'si gönderilen markayı geri döndüren metod
        {
            return context.Markalar.Find(id);
        }

        public int Add(Marka marka) //marka ekleme metodu
        {
            context.Markalar.Add(marka);    
            return context.SaveChanges();
        }

        public int Update(Marka marka) //marka güncelleme metodu
        {
            context.Markalar.AddOrUpdate(marka);
            return context.SaveChanges();
        }

        public int Delete(int id) //marka silme metodu
        {
            context.Markalar.Remove(Get(id));
            return context.SaveChanges();
        }
    }
}