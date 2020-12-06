using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlisverisSitesi.Models
{
    public class Siparis
    {
        public int SiparisID { get; set; }
        [ForeignKey("Urun")]
        public int UrunID { get; set; }
        [ForeignKey("Kullanici")]
        public int KullaniciID { get; set; }
    }
}
