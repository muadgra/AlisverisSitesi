using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlisverisSitesi.Models;

namespace AlisverisSitesi.Controllers
{
    public class KategoriController : Controller
    {
        private readonly AlisverisDb _context = new AlisverisDb();
        /*
        public KategoriController(AlisverisDb context)
        {
            _context = context;
        }*/

        // GET: Kategori
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kategoriler.ToListAsync());
        }

        // GET: Kategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategori = await _context.Kategoriler
                .FirstOrDefaultAsync(m => m.KategoriId == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // GET: Kategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriId,KategoriAd")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SepeteEkle([Bind("UrunID,KategoriID,Kategori,StokMiktari,UrunAd,UrunResimURL,UrunFiyat")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(urun);
        }
        // GET: Kategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategori = await _context.Kategoriler.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        // POST: Kategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KategoriId,KategoriAd")] Kategori kategori)
        {
            if (id != kategori.KategoriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriExists(kategori.KategoriId))
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
            return View(kategori);
        }

        // GET: Kategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategori = await _context.Kategoriler
                .FirstOrDefaultAsync(m => m.KategoriId == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // POST: Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategori = await _context.Kategoriler.FindAsync(id);
            _context.Kategoriler.Remove(kategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriExists(int id)
        {
            return _context.Kategoriler.Any(e => e.KategoriId == id);
        }
        public IActionResult Kategoriler()
        {
            var db = new AlisverisDb();
            var KategorilerListesi = db.Kategoriler.ToList();
            return View(KategorilerListesi);
        }
        public IActionResult Ayakkabi()
        {
            var db = new AlisverisDb();
            //var KategorilerListesi = db.Kategoriler.ToList();
            var Ayakkabilar = from a in db.Urunler
                              where a.KategoriID == 1
                              select a;
            return View(Ayakkabilar);
        }
        public IActionResult Teknoloji()
        {
            var db = new AlisverisDb();
            //var KategorilerListesi = db.Kategoriler.ToList();
            var Teknolojik = from a in db.Urunler
                              where a.KategoriID == 2
                              select a;
            return View(Teknolojik);
        }
        public IActionResult Spor()
        {
            var db = new AlisverisDb();
            //var KategorilerListesi = db.Kategoriler.ToList();
            var Spor = from a in db.Urunler
                              where a.KategoriID == 3
                              select a;
            return View(Spor);
        }
    }
}
