﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlisverisSitesi.Models;

namespace AlisverisSitesi.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly AlisverisDb _context = new AlisverisDb();
        /*
        public KullaniciController(AlisverisDb context)
        {
            _context = context;
        }*/
        public IActionResult UyeOl()
        {
            return View();
        }
        // GET: Kullanici
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kullanicilar.ToListAsync());
        }

        // GET: Kullanici/Details/5
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
        public async Task<IActionResult> Create([Bind("KullaniciID,KullaniciAdi,KullaniciSifresi,Email,DogumTarihi,Adres,AdminMi")] Kullanici kullanici)
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
