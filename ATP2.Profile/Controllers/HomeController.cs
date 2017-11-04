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
                loginModel.Role = Role.Admin;
                switch (loginModel.Role)
                {
                    case Role.Admin:
                        var admin = new AdminRepository().GetByName(loginModel.UserName);

                        if (admin != null)
                        {
                            admin.LastLogin = DateTime.Now;

                            new AdminRepository().Update(admin);
                            Session["Admin"] = admin;
                            return RedirectToAction("AdminDashboard", "Account");
                        }
                        break;
                    case Role.Executive:
                        break;
                    case Role.Tutor:
                        var tutor = new TutorRepository().GetByName(loginModel.UserName);

                        if (tutor != null)
                        {
                            tutor.LastLogin = DateTime.Now;

                            new TutorRepository().Update(tutor);
                            Session["Tutor"] = tutor;
                            return RedirectToAction("Dashboard", "Account");
                        }
                        break;
                    case Role.Guest:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
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
            var user= new Tutor()
            {
                DateOfBirth = registrationModel.DateOfBirth,
                Email = registrationModel.Email,
                Name = registrationModel.Name,
                UserName = registrationModel.UserName,
                Password = registrationModel.Password,
                Gender = registrationModel.Gender
            };

           
            new TutorRepository().Add(user);
            return RedirectToAction("Login");
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