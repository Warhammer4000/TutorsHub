using System;
using System.Web.Mvc;
using BLL;
using Entity.UserModels;
using TutorsHub.Application.Models;

namespace TutorsHub.Application.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View(new RegistrationViewModel());
        }


        [HttpPost]
        public ActionResult Registration(RegistrationViewModel registrationViewModel)
        {
            if (registrationViewModel.Password != registrationViewModel.ConfirmPassword)
                ModelState.AddModelError("ConfirmPassword", "Password Mismatch");

            if (!ModelState.IsValid) return View(registrationViewModel);

            switch (registrationViewModel.Type)
            {
                case "Tutor":
                    var tutorService = new ServiceProvider().Create<Tutor>();
                    tutorService.Add(new Tutor
                    {
                        Name = registrationViewModel.Name,
                        Email = registrationViewModel.Email,
                        Password = registrationViewModel.Password,
                        UserSince = DateTime.Now,
                        LastLogin = DateTime.Now,
                        DateOfBirth = DateTime.Now,
                        Role = Role.Tutor,
                        Rank = 0,
                        Experience = 0
                    });
                    break;
                case "Student":
                    var studentService = new ServiceProvider().Create<Student>();
                    studentService.Add(new Student
                    {
                        Name = registrationViewModel.Name,
                        Email = registrationViewModel.Email,
                        Password = registrationViewModel.Password,
                        UserSince = DateTime.Now,
                        LastLogin = DateTime.Now,
                        DateOfBirth = DateTime.Now,
                        Role = Role.Student
                    });
                    break;
            }

            RedirectToAction("Index", "Home");

            return View(registrationViewModel);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var tutorService = new ServiceProvider().Create<Tutor>();
            if (tutorService.ValidUser(email, password))
            {
                Session["Key"] = email;

                return RedirectToAction("Dashboard", "Tutor");
            }

            var studentService = new ServiceProvider().Create<Student>();
            if (studentService.ValidUser(email, password))
            {
                Session["Key"] = email;
                return RedirectToAction("Dashboard", "Student");
            }

            var adminService = new ServiceProvider().Create<Admin>();
            if (adminService.ValidUser(email, password))
            {
                Session["Key"] = email;
                return RedirectToAction("AdminDashboard", "Admin");
            }

            ViewBag.email = email;
            return View();
        }


        public ActionResult SearchResult()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewProfile(string id)
        {
            return View();
        }


        public RedirectToRouteResult ToDashBoard(string email, string password)
        {
            var tutorService = new ServiceProvider().Create<Tutor>();
            if (tutorService.ValidUser(email, password))
            {
                Session["Key"] = email;

                return RedirectToAction("Dashboard", "Tutor");
            }

            var studentService = new ServiceProvider().Create<Student>();
            if (studentService.ValidUser(email, password))
            {
                Session["Key"] = email;
                return RedirectToAction("Dashboard", "Student");
            }

            var adminService = new ServiceProvider().Create<Admin>();
            if (adminService.ValidUser(email, password))
            {
                Session["Key"] = email;
                return RedirectToAction("AdminDashboard", "Admin");
            }

            return RedirectToAction("Login", "Home");
        }
    }
}