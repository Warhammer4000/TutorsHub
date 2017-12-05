using BLL;
using Entity.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorsHub.Application.Controllers
{
    public class TutorController : Controller
    {

        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditPassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchUser(int? id)
        {

            return View();
        }
        [HttpGet]
        public ActionResult EditProfile(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Dashboard");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult StudentList(int? id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewProfile(Tutor val)
        {
            var tutorservice = new ServiceProvider().Create<Tutor>();
            var tutor = tutorservice.GetByEmail(Session["KEY"] as String);
            val = tutor;
            return View(val);
        }

        [HttpGet]
        public ActionResult Timer()
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        public ActionResult Notification()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Blog()
        {

            return View();
        }


        [HttpGet]
        public ActionResult ViewPost(string id)
        {

            return View();
        }



        [HttpGet]
        public ActionResult NewPost()
        {
            return View();

        }

        public RedirectToRouteResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }

        public ActionResult UploadMaterial()
        {
            return View();
        }


    }
}
