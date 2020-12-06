using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlisverisSitesi.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        private string KategoriAd { get; set; }
        public ICollection<Urun> Urunler { get; set; }
    }
}
