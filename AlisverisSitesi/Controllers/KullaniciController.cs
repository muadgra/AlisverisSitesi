using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlisverisSitesi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Localization;
namespace AlisverisSitesi.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly AlisverisDb _context = new AlisverisDb();

        public IActionResult SepetGetir()
        {
            string isim = HttpContext.Session.GetString("ad");
            var db = new AlisverisDb();
            var kullanici = db.Kullanicilar.Where(s => s.KullaniciAdi.Equals(isim)).Select(s => s.KullaniciID);
            var id = Convert.ToInt32(kullanici.FirstOrDefault());


            var siparisler = from a in db.Siparisler
                             where a.SepetID == id
                             select a;
            return View(siparisler);
            
        }
        public IActionResult GirisZatenYapildi()
        {
            return View();
        }
        public IActionResult Giris()
        {
            if (HttpContext.Session.GetInt32("kullaniciVar").HasValue)
            {        
                return RedirectToAction(nameof(GirisZatenYapildi));
            }
            else
               return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Giris([Bind("KullaniciAdi,KullaniciSifresi")] Kullanici kullanici)
        {
            var db = new AlisverisDb();
            var kullaniciKontrol = (from p in db.Kullanicilar
             where p.KullaniciAdi == kullanici.KullaniciAdi && p.KullaniciSifresi == kullanici.KullaniciSifresi
             select p).Any();
            if(kullaniciKontrol == true)
            {
                HttpContext.Session.SetInt32("kullaniciID", kullanici.KullaniciID);
                HttpContext.Session.SetInt32("kullaniciVar", 1);
                HttpContext.Session.SetString("ad", kullanici.KullaniciAdi);
                return RedirectToAction(nameof(BasariliGiris));
            }
            else
                return RedirectToAction(nameof(BasarisizGiris));
        }
        public IActionResult UyeOl()
        {
            return View();
        }
        // GET: Kullanici
        public async Task<IActionResult> Index()
        {
            return View(/*await _context.Kullanicilar.ToListAsync()*/);
        }

        public IActionResult BasariliGiris()
        {
            return View();
        }
        public IActionResult BasarisizGiris()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.KullaniciID == id);
            if (kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        // GET: Kullanici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UyeOl([Bind("KullaniciID,KullaniciAdi,KullaniciSifresi,Email,DogumTarihi,Adres")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullanici);
        }

        // GET: Kullanici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KullaniciID,KullaniciAdi,KullaniciSifresi,Email,DogumTarihi,Adres,AdminMi")] Kullanici kullanici)
        {
            if (id != kullanici.KullaniciID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullanici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullaniciExists(kullanici.KullaniciID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kullanici);
        }

        // GET: Kullanici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.KullaniciID == id);
            if (kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        // POST: Kullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kullanici = await _context.Kullanicilar.FindAsync(id);
            _context.Kullanicilar.Remove(kullanici);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullaniciExists(int id)
        {
            return _context.Kullanicilar.Any(e => e.KullaniciID == id);
        }
    }
}
