using BLL;
using Entity.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorsHub.Application.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult DashBoard()
        {
            return View();
        }
        [HttpGet]
        public RedirectToRouteResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Report()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ExamResult()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudyMaterial()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OnlineExam()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HireTutor()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult EditProfile()
        {
            var student = new ServiceProvider().Create<Student>();
            return View(student.GetByEmail(Session["KEY"] as string));
        }
        public ActionResult Notification()
        {
            return View();
        }
        public ActionResult TutorSearch()
        {
            return View();
        }
        public ActionResult ViewSearch()
        {
            return View();
        }

        public ActionResult ViewProfile(Student student)
        {
            var studentservice = new ServiceProvider().Create<Student>();
            student = studentservice.GetByEmail(Session["KEY"] as string);
            return View(student);
        }

        public ActionResult Blog()
        {
            return View();
        }
    }
}