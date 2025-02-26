﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlisverisSitesi.Models
{
    public class Siparis
    {
        [Key]
        public int SiparisID { get; set; }
        [ForeignKey("Urun")]
        public int UrunID { get; set; }
        [ForeignKey("Sepet")]
        public int SepetID { get; set; }
    }
}
