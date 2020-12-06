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
        public string UrunAd { get; set; }
        public int StokMiktari { get; set; }
        public string UrunResimURL { get; set; }
        public double UrunFiyat { get; set; }
        public int KategoriID { get; set; }
        [ForeignKey("Kategori")]
        public Kategori KategoriAdi { get; set; }
        [ForeignKey("Siparis")]
        ICollection<Siparis> Siparisler { get; set; }

    }
}
