﻿using System.Web.Mvc;

namespace TutorsHub.Application.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult ViewProfile()
        {
            return View();
        }

        public ActionResult EditProfile()
        {
            return View();
        }

        public ActionResult EditPassword()
        {
            return View();
        }

        public ActionResult UserSearch()
        {
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }

        public ActionResult QuestionPaper()
        {
            return View();
        }

        public ActionResult Locations()
        {
            return View();
        }

        public ActionResult Subjects()
        {
            return View();
        }

        public ActionResult StatisticReport()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult ActivityReport()
        {
            throw new System.NotImplementedException();
        }
    }
}