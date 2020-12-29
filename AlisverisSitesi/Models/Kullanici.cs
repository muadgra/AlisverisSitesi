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
        [Display(Name ="Kullanıcı Adınız:")]
        public string KullaniciAdi { get; set; }
        [Display(Name = "Şifreniz:")]
        public string KullaniciSifresi { get; set; }
        [Display(Name = "Emailiniz:")]
        public string Email { get; set; }
        [Display(Name = "Doğum Tarihiniz:")]
        public DateTime DogumTarihi { get; set; }
        [Display(Name = "Adresiniz:")]
        public string Adres { get; set; }
        [ForeignKey("Sepet")]
        public Sepet Sepeti { get; set; }
    }
}
