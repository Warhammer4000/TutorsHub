using System;

using System.Web.Mvc;
using ATP2.Profile.Models;
using ATP2.Profile.Models.HomeModels;
using DLL.Service;
using Entity;

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
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
          
            if (ModelState.IsValid)
            {

                User user = new UserService().GetUserByUserName(loginModel.UserName);
               
                if (user!=null)
                {
                    user.LastLogin = DateTime.Now;
                    string x;
                    new UserService().Update(user, out  x);
                    Session["User"] = user;
                    
                   
                    
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
            User user= new User()
            {
                DateOfBirth = registrationModel.DateOfBirth,
                Email = registrationModel.Email,
                Name = registrationModel.Name,
                UserName = registrationModel.UserName,
                Password = registrationModel.Password,
                Gender = registrationModel.Gender
            };

            string x;
            new UserService().AddUser(user,out x);
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