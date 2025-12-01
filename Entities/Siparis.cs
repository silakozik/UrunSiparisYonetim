using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Siparis  : IEntity
    {
        public int Id { get; set; }
        public string SiparisNo { get; set; }
        public int MusteriId { get; set; }
        public int UrunId { get; set; }
        public int Miktar { get; set; } // Sipariş edilen ürün miktarı
        public decimal ToplamTutar { get; set; } // Toplam sipariş tutarı (KDV dahil)
        public string Durum { get; set; } // Sipariş durumu: Bekliyor, Onaylandı, İptal, TeslimEdildi
        public DateTime SiparisTarihi { get; set; } 
        public virtual Musteri Musteri { get; set; }    
        public virtual Urun Urun { get; set; }    
    }
}
