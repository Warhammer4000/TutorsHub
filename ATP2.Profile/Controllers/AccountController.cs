
using System;
using System.Web.Mvc;
using ATP2.Profile.Models;
using ATP2.Profile.Models.AccountModels;
using DLL.Service;
using Entity;

namespace ATP2.Profile.Controllers
{
    public class AccountController : Controller
    {


        [HttpGet]
        public ActionResult Dashboard()
        {
            User user = (User)Session["User"];
            
            Session["UserName"] = user.UserName;
            return View(new DashboardModel(){Usersince = user.UserSince,LastLogin = DateTime.Now});
        }

        [HttpGet]
        public ActionResult UserProfile()
        {
            User user = (User)Session["User"];
            ProfileModel profileModel = new ProfileModel()
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Gender = user.Gender,
                Name = user.Name
            };

            return View("Profile", profileModel);
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

            if (ModelState.IsValid)
            {
                var user = (User) Session["User"];
                user.Name = editProfile.Name;
                user.Email = editProfile.Email;
                user.Gender = editProfile.Gender;
                user.DateOfBirth = editProfile.DateOfBirth;
                string x;
                new UserService().Update(user,out x);
            }

            return View(editProfile);
        }


        [HttpGet]
        public ActionResult EditPassword()
        {
           
            return View(new EditPasswordModel());
        }


        [HttpPost]
        public ActionResult EditPassword(EditPasswordModel editPasswordModel)
        {
            if (ModelState.IsValid)
            {
                var user = (User)Session["User"];
                user.Password = editPasswordModel.RNewPassword;
                string x;
                new UserService().Update(user, out x);
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

       


        


        


    }
}