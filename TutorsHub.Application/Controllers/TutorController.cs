using BLL;
using Entity.UserModels;
using System;
using System.Web.Mvc;
using BLL.UserRepository;
using TutorsHub.Application.Models;

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
        public ActionResult EditProfile()
        {
            TutorEditProfileModel tutorEditProfileModel = new TutorEditProfileModel();
            tutorEditProfileModel.GetTutor(Session["Key"] as string);

            return View(tutorEditProfileModel);
        }

        [HttpPost]
        public ActionResult EditProfile(TutorEditProfileModel tutorEditProfileModel)
        {
            try
            {

                return RedirectToAction("Dashboard");
            }
            catch
            {
                return View(tutorEditProfileModel);
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
            var tutorservice =(TutorService) new ServiceProvider().Create<Tutor>();
            var tutor = tutorservice.GetByEmailWithLists(Session["KEY"] as String);
            tutor.TimeSpanUpdate();
            val = tutor;
            return View(val);
        }

       
        [HttpGet]
        public ActionResult Notification()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Chat()
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
