using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlisverisSitesi.Controllers
{
    public class IletisimController : Controller
    {
        public IActionResult Iletisim()
        {
            return View();
        }
    }
}
