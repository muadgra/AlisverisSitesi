using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace AlisverisSitesi2.Controllers
{
    public class Language : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Change(String LanguageAbbrevation)
        {
            if (LanguageAbbrevation != null) {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);

            }
            HttpContext.Response.Cookies.Append("dil1", "tr");
            return View("Index");
        }
    }
}
