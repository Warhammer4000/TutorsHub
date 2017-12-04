using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BLL.UserRepository;
using TutorsHub.Application.Models;
using Entity.UserModels;

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
            return  View(new RegistrationViewModel());
        }


        [HttpPost]
        public ActionResult Registration( RegistrationViewModel registrationViewModel)
        {
            if (registrationViewModel.Password != registrationViewModel.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword","Password Mismatch");
              
            }

            if (ModelState.IsValid)
            {

                switch (registrationViewModel.Type)
                {
                    case "Tutor":
                        IUserService<Tutor> tutorService = new ServiceProvider().Create<Tutor>();
                        tutorService.Add(new Tutor()
                        {
                            Name = registrationViewModel.Name,
                            Email = registrationViewModel.Email,
                            Password = registrationViewModel.Password,
                            UserSince = DateTime.Now,
                            LastLogin = DateTime.Now,
                            DateOfBirth = DateTime.Now,
                            Role = Role.Tutor,
                            Rank = 0,
                            Experience = 0,
                        });
                        break;
                    case "Student":
                        IUserService<Student> studentService= new ServiceProvider().Create<Student>();
                        studentService.Add(new Student()
                        {
                            Name =registrationViewModel.Name,
                            Email = registrationViewModel.Email,
                            Password = registrationViewModel.Password,
                            UserSince = DateTime.Now,
                            LastLogin = DateTime.Now,
                            DateOfBirth = DateTime.Now,
                            Role = Role.Student
                        });

                        break;
                }

                RedirectToAction("Index","Home");
            }

            return View(registrationViewModel);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            IUserService<Tutor> tutorService= new ServiceProvider().Create<Tutor>();
            if (tutorService.ValidUser(email, password))
            {
               return RedirectToAction("Dashboard", "Tutor");
               
            }

            IUserService<Student> studentService = new ServiceProvider().Create<Student>();
            if (studentService.ValidUser(email, password))
            {
                return RedirectToAction("Dashboard", "Student");
            }

            IUserService<Admin> adminService = new ServiceProvider().Create<Admin>();
            if (adminService.ValidUser(email, password))
            {
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

    
        public RedirectToRouteResult ToDashBoard(string email,string password)
        {
            //TODO Copy Login Code Here After FEST

            switch (email)
            {
                case "tutor":
                    return RedirectToAction("Dashboard", "Tutor");
                case "admin":
                    return RedirectToAction("AdminDashboard", "Admin");
                case "student":
                    return RedirectToAction("Dashboard", "Student");
                default:
                        return RedirectToAction("Login", "Home");
            }
        }


    }
}