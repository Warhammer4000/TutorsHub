using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATP2.Profile.Views.Account
{
    public class ExamController : Controller
    {
      

        [HttpGet]
        public ActionResult Result()
        {
            return View();
        }

        [HttpGet]

        public ActionResult Exam()
        {
            return View();
        }


        [HttpGet]

        public ActionResult Ranking()
        {
            return View();
        }
    }
}