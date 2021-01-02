using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlisverisSitesi.Models
{
    public class Urun
    {
        [Key]
        
        public int UrunID { get; set; }
        [Display(Name = "Urun Adi:")]
        public string UrunAd { get; set; }
        [Display(Name = "Stok Miktari:")]
        public int StokMiktari { get; set; }
        [Display(Name = "Urun Resim:")]
        public string UrunResimURL { get; set; }
        [Display(Name = "Urun Fiyati:")]
        public double UrunFiyat { get; set; }
        [Display(Name = "Kategori ID:")]
        public int KategoriID { get; set; }
        [Display(Name = "Kategori Adi:")]
        [ForeignKey("Kategori")]
        public Kategori KategoriAdi { get; set; }
        [ForeignKey("Siparis")]
        ICollection<Siparis> Siparisler { get; set; }

    }
}
