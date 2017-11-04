
using System;
using System.Web.Mvc;
using ATP2.Profile.Models;
using ATP2.Profile.Models.AccountModels;
using BLL.UserRepository;
using Entity;
using Entity.UserModels;

namespace ATP2.Profile.Controllers
{
    public class AccountController : Controller
    {


        [HttpGet]
        public ActionResult Dashboard()
        {
            var user = (Tutor)Session["Tutor"];
            
            Session["UserName"] = user.UserName;
            return View(new DashboardModel(){Usersince = user.UserSince,LastLogin = DateTime.Now});
        }



        [HttpGet]
        public ActionResult AdminDashboard()
        {
            var user = (Admin)Session["Admin"];

            Session["UserName"] = user.UserName;
            return View();
        }


        [HttpGet]
        public ActionResult UserProfile()
        {
            var tutor = (Tutor)Session["Tutor"];
            return View("Profile", tutor);
        }


        [HttpGet]
        public ActionResult EditProfile()
        {
            var user = (Tutor)Session["Tutor"];
           

            switch (user.Gender)
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

            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(Tutor tutor)
        {
            switch (tutor.Gender)
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
                new TutorRepository().Update(tutor);
            }

            return View(tutor);
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
                var user = (Tutor)Session["Tutor"];
                user.Password = editPasswordModel.RNewPassword;
            
                new TutorRepository().Update(user);
            }

            return View(editPasswordModel);
        }




     

       


        


        


    }
}