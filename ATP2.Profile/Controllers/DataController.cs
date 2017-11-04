using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DataRepository;

namespace ATP2.Profile.Controllers
{
    public class DataController : Controller
    {
        [HttpGet]
        public ActionResult QuestionPaper()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Locations()
        {
            
            return View(new LocationRepostiory().GetAll());
        }

        [HttpGet]
        public ActionResult Subjects()
        {
            return View(new SubjectRepository().GetAll());
        }


    }
}