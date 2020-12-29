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

        public void SepeteEkle(Kullanici kullanici, Urun urun)
        {
            var db = new AlisverisDb();
            var item = db.Urunler.SingleOrDefault(s => s.UrunID == urun.UrunID);
            var siparis = new Siparis();
            Random random = new Random();
            siparis.SiparisID = random.Next(1000);
            siparis.SepetID = kullanici.Sepeti.SepetID;
            siparis.UrunID = item.UrunID;
            db.Siparisler.Add(siparis);
            var sepet = new Sepet();
            sepet.KullaniciID = kullanici.KullaniciID;
            sepet.SepetID = kullanici.Sepeti.SepetID;
            sepet.Siparisler.Add(siparis);
            db.SaveChanges();
        }
    }
}
