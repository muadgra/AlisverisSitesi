using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlisverisSitesi.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSifresi { get; set; }
        public string Email { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Adres { get; set; }
        [ForeignKey("Sepet")]
        public Sepet Sepeti { get; set; }
    }
}
