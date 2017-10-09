using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATP2.Profile.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Name = "Tanimul Haque Khan";
            ViewBag.Email = "tazimtaizm2012@gmail.com";
         
            ViewBag.Gender0 = true;
            ViewBag.Gender1 = false;
            ViewBag.Gender2 = false;
            ViewBag.Day = 29;
            ViewBag.Month = 4;
            ViewBag.Year = 1995;
            ViewBag.Degree0 = true;
            ViewBag.Degree1 = true;
            ViewBag.Degree2 = true;
            ViewBag.Degree3 = false;
            return View(ViewBag);
        }
    }
}