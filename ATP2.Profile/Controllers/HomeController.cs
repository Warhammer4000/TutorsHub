using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;
using ATP2.Profile.Models;
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


        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
          
            if (ModelState.IsValid)
            {

                List<User> users = (List<User>) Session["Users"];

                var User = (from user in users
                    where user.UserName == loginModel.UserName && user.Password == loginModel.Password
                    select user).FirstOrDefault();
                Session["User"] = User;

                if (User!=null)
                {
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

            if (ModelState.IsValid)
            {
                //Temporary Session to hold data
                User user= new User()
                {
                    DateOfBirth = registrationModel.DateOfBirth,
                    Email = registrationModel.Email,
                    Name = registrationModel.Name,
                    UserName = registrationModel.UserName,
                    Password = registrationModel.Password,
                    Gender = registrationModel.Gender
                };

                Session["User"] = user; 

                return RedirectToAction("Login");
            }
           
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