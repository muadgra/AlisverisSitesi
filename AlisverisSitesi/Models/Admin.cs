using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlisverisSitesi.Models
{
    public class Admin : Kullanici
    {
        [Key]
        public int AdminID { get; set; }
        public int EklenenUrunSayisi { get; set; }
    }
}
