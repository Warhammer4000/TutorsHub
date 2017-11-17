using System;

using System.Web.Mvc;
using ATP2.Profile.Models;
using ATP2.Profile.Models.HomeModels;
using BLL.UserRepository;
using Entity;
using Entity.UserModels;

namespace ATP2.Profile.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Search()
        {
            return View(new SearchModel());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
          
            if (ModelState.IsValid)
            {
                

                var admin = new AdminRepository().GetByEmail(loginModel.Email);

                if (admin != null)
                {
                    admin.LastLogin = DateTime.Now;

                    new AdminRepository().Update(admin);
                    Session["Admin"] = admin;
                    Session["Role"] = Role.Admin;
                    return RedirectToAction("AdminDashboard", "Account");
                }

                var tutor = new TutorRepository().GetByEmail(loginModel.Email);

                if (tutor != null)
                {
                    tutor.LastLogin = DateTime.Now;

                    new TutorRepository().Update(tutor);
                    Session["Tutor"] = tutor;
                    Session["Role"] = Role.Tutor;
                    return RedirectToAction("Dashboard", "Account");
                }

                ModelState.AddModelError("Invalid","Invalid User");
                return View(loginModel);
            }
            
            return View(loginModel);
        }


        

       

        [HttpGet]
        public ActionResult Registration()
        {
            return View(new RegistrationModel());
        }


        [HttpPost]
        public ActionResult Registration(RegistrationModel registrationModel)
        {
            if (!ModelState.IsValid) return View(registrationModel);
            var tutor= new Tutor()
            {
               
                Email = registrationModel.Email,
                Password = registrationModel.Password,
                Role = Role.Tutor,
                Status = Status.Pending,
                UserSince = DateTime.Now
                 
                
            };



            if (new TutorRepository().Add(tutor))
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("Database error","Database Error");
            return View(registrationModel);

        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View(new ForgotPasswordModel());
        }


        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            return View(forgotPasswordModel);
        }



    }
}