using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATP2.Profile.Controllers
{
    public class ExamControlController : Controller
    {
        [HttpGet]
        public ActionResult QuestionPaper()
        {
            return View();
        }



    }
}