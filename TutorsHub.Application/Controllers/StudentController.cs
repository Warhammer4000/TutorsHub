using System.Web.Mvc;
using Entity.Data;
using TutorsHub.Application.Models;
using Entity.UserModels;
using BLL;
using BLL.DataRepositoryFolder;
using System;
using BLL.UserRepository;


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
            return View(new EditPass());
        }
        [HttpPost]
        public ActionResult ChangePassword(EditPass editPass)
        {
            var userservice = new UserService<Student>();

            var studentservice = new ServiceProvider().Create<Student>();
            var student = studentservice.GetByEmail(Session["KEY"] as string);

            if (editPass.NewPassword == editPass.RepPassword)
            {
                userservice.UpdatePassword(student.Email, editPass.NewPassword);
            }
            return View(editPass);
        }

        [HttpGet]
        public ActionResult SchedTutor()
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
        public ActionResult StudentProfile()
        {
            var studentservice = new ServiceProvider().Create<Student>();
            var student = studentservice.GetByEmail(Session["KEY"] as string);
            return View(student);
            
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            var studentprovider = new ServiceProvider().Create<Student>();
            return View(studentprovider.GetByEmail(Session["KEY"] as string));
        }


        [HttpPost]
        public ActionResult EditProfile(Student student)
        {
            var studentprovider = new ServiceProvider().Create<Student>();
            student.Email = Session["Key"] as string;
            if (studentprovider.Update(student))
            {
                return RedirectToAction("ViewProfile", "Student");
            }

            return View(student);
        }


        [HttpGet]
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

        [HttpGet]
        public ActionResult ViewProfile()
        {
            var studentservice = new ServiceProvider().Create<Student>();
            var student = studentservice.GetByEmail(Session["KEY"] as string);
            return View(student);
        }

        
    }
}