using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATP2.Profile.Controllers
{
    public class TutorController : Controller
    {
        // GET: Tutor
        [HttpGet]
        public ActionResult DashBoard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StudentList()
        {
            return View();
        }

        [HttpGet]
        public RedirectToRouteResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index","Home");
        }





    }
}