using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL;
using BLL.SearchRepository;
using BLL.UserRepository;
using Entity.UserModels;
using TutorsHub.Application.Models;

namespace TutorsHub.Application.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SearchViewModel());
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

        [HttpPost]
        public ActionResult SearchResult(SearchViewModel searchViewModel)
        {
            List<Tutor> tutors= new PublicSearch().SearchTutors(searchViewModel.Location,searchViewModel.Gender
                ,searchViewModel.Class,(int)searchViewModel.MinSal,(int)searchViewModel.MaxSal,searchViewModel.SelectedSubjects);
            return View(tutors);
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewProfile(string key)
        {
            Tutor tutor = new TutorService().GetByEmail(key);
            return View(tutor);
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