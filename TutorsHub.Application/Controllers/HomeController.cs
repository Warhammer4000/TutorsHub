using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorsHub.Application.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return  View();
        }

        public ActionResult ForgotPassword()
        {
            throw new NotImplementedException();
        }
    }
}