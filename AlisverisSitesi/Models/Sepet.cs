using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlisverisSitesi.Models
{
    public class Sepet
    {
        public int SepetID { get; set; }
        public int KullaniciID { get; set; }
        [ForeignKey("Kullanici")]
        public Kullanici Kullanicisi { get; set; }
        public ICollection<Siparis> Siparisler { get; set; }
    }
}
