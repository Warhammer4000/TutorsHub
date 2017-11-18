
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ATP2.Profile.Models;
using ATP2.Profile.Models.AccountModels;
using ATP2.Profile.Models.HomeModels;
using BLL.UserRepository;
using Entity;
using Entity.Data;
using Entity.UserModels;

namespace ATP2.Profile.Controllers
{
    public class AccountController : Controller
    {


        [HttpGet]
        public ActionResult Dashboard()
        {
            var user = (Tutor)Session["Tutor"];
            
            Session["UserName"] = user.Name;
            return View(new DashboardModel(){Usersince = user.UserSince,LastLogin = DateTime.Now});
        }



        [HttpGet]
        public ActionResult AdminDashboard()
        {
            var user = (Admin)Session["Admin"];

            Session["UserName"] = user.Name;
            return View();
        }


        [HttpGet]
        public ActionResult UserProfile()
        {
            var tutor = (Tutor)Session["Tutor"];
            return View("Profile", tutor);
        }


        [HttpGet]
        public ActionResult AdminProfile()
        {
            var admin = (Admin)Session["Admin"];
            return View(admin);
        }



        [HttpGet]
        public ActionResult EditProfile()
        {
          

            var tutor = (Tutor)Session["Tutor"];
            var editProfileModel = new EditProfileModel(tutor);

            switch (tutor.Gender)
            {
                case "Male":
                    tutor.MaleChecked = true;
                    break;

                case "Female":
                    tutor.FemaleChecked = true;
                    break;


            }


            foreach (var location in editProfileModel.Tutor.PreferredLocations)
            {
                foreach (var x in editProfileModel.Locations)
                {
                    if (x.Name == location.Name)
                    {
                        x.IsChecked = true;
                    }
                }

            }



            return View(editProfileModel);
        }

        [HttpPost]
        public ActionResult EditProfile(EditProfileModel editProfileModel)
        {
            switch (editProfileModel.Tutor.Gender)
            {
                case "Male":
                    editProfileModel.Tutor.MaleChecked = true;
                    break;

                case "Female":
                    editProfileModel.Tutor.FemaleChecked = true;
                    break;


            }
            editProfileModel.Tutor.PreferredLocations=new List<Location>();

            foreach (var location in editProfileModel.Locations)
            {
                editProfileModel.Tutor.PreferredLocations.Add(location);
            }



            if (ModelState.IsValid)
            {
                new TutorRepository().Update(editProfileModel.Tutor);
            }

            return View(new EditProfileModel(editProfileModel.Tutor));
        }


        [HttpGet]
        public ActionResult EditProfileAdmin()
        {
            var admin = (Admin)Session["Admin"];
            return View(admin);
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
                var role = (Role)Session["Role"];
                switch (role)
                {
                    case Role.Admin:
                        var admin = (Admin)Session["Admin"];
                        admin.Password = editPasswordModel.RNewPassword;
                        new AdminRepository().Update(admin);
                        break;
                    case Role.Executive:
                        break;
                    case Role.Tutor:
                        var tutor = (Tutor)Session["Tutor"];
                        tutor.Password = editPasswordModel.RNewPassword;

                        new TutorRepository().Update(tutor);
                        break;
                    case Role.Guest:
                        break;
                }

            }

            return View(editPasswordModel);
        }



        [HttpGet]
        public ActionResult TutorRequest()
        {
            return View();
        }











    }
}