using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlisverisSitesi.Models;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace AlisverisSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AlisverisDb _context = new AlisverisDb();

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }
        public async Task<IActionResult> AdminPaneli()
        {
            return View(await _context.Kategoriler.ToListAsync());
        }
        public IActionResult Index()
        {
            
            HttpContext.Response.Cookies.Append("dil1", "tr");
            HttpContext.Response.Cookies.Append("dil3", "0");
            HttpContext.Response.Cookies.Append("dil2", "en");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Onerilenler()
        {
            var db = new AlisverisDb();
            var Urunler = db.Urunler.ToList();
            return View(Urunler);
        }

        public IActionResult Authenticate()
        {
            return RedirectToAction("Index");
        }
    }
}
