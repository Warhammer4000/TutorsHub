using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            User user = new User()
            {
                DateOfBirth = DateTime.Now.ToString("DD-MM-YYYY"),
                Email = "tkhan@iquantile.com",
                Name = "tazim",
                UserName = "tazim",
                Password = "darks1d1erS!",
                Gender = "Male"
            };

            Session["User"] = user;

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
                User user = (User) Session["User"];

                if (loginModel.UserName == user?.UserName && loginModel.Password == user?.Password)
                {
                    return RedirectToAction("Dashboard");
                }
                ModelState.AddModelError("Invalid","Invalid User");
                return View(loginModel);
            }
            
            return View(loginModel);
        }


        public ActionResult EditPassword()
        {
            return View(new EditPasswordModel());
        }

        [HttpPost]
        public ActionResult EditPassword(EditPasswordModel editPasswordModel)
        {
            if (ModelState.IsValid)
            {
                
            }

            return View(editPasswordModel);
        }

        [HttpGet]
        public ActionResult ProfilePicture()
        {
            return View(new ProfilePictureModel());
        }

        [HttpPost]
        public ActionResult ProfilePicture(ProfilePictureModel profilePictureModel)
        {
            string errorMessage;
            if (profilePictureModel.Validation(out errorMessage))
            {
                errorMessage = "Success!!!";
            }
            ViewData["ErrorMessage"] = errorMessage;
            return View(profilePictureModel);

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
        public ActionResult UserProfile()
        {
            User user = (User)Session["User"];
            ProfileModel profileModel= new ProfileModel()
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Gender = user.Gender,
                Name = user.Name
            };

            return View("Profile",profileModel);
        }


        [HttpGet]
        public ActionResult EditProfile()
        {
            User user = (User)Session["User"];
            EditProfileModel editprofileModel = new EditProfileModel()
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Gender = user.Gender,
                Name = user.Name
            };

            switch (editprofileModel.Gender)
            {
                case "Male":
                    ViewBag.Male = true;
                    break;

                case "Female":
                    ViewBag.Female = true;
                    break;

                case "Other":
                    ViewBag.Other = true;
                    break;

            }

            return View(editprofileModel);
        }

        [HttpPost]
        public ActionResult EditProfile(EditProfileModel editProfile)
        {
            switch (editProfile.Gender)
            {
                case "Male":
                    ViewBag.Male = true;
                    break;

                case "Female":
                    ViewBag.Female = true;
                    break;

                case "Other":
                    ViewBag.Other = true;
                    break;

            }

            

            return View(editProfile);
        }


        [HttpGet]
        public ActionResult Dashboard()
        {
            User user = (User)Session["User"];
            Session["UserName"] = user.UserName;
            return View();
        }



    }
}