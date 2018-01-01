using BLL;
using Entity.UserModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL.BlogRepository;
using BLL.UserRepository;
using Entity.BlogModel;
using Entity.Data;
using TutorsHub.Application.Models;
using Entity.Others;

namespace TutorsHub.Application.Controllers
{
    public class TutorController : Controller
    {

        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditPassword()
        {
            return View(new EditPass());
        }

        [HttpPost]
        public ActionResult EditPassword(EditPass editPass)
        {
            var userservice = new UserService<Tutor>();

            var tutorservice = new ServiceProvider().Create<Tutor>();
            var tutor = tutorservice.GetByEmail(Session["KEY"] as string);

            if (editPass.NewPassword == editPass.RepPassword)
            {
                userservice.UpdatePassword(tutor.Email, editPass.NewPassword);
            }
            return View(editPass);
        }

        [HttpGet]
        public ActionResult SearchUser(int? id)
        {

            return View();
        }


        [HttpGet]
        public ActionResult EditProfile()
        {
            var tutorEditProfileModel = new TutorEditProfileModel();
            tutorEditProfileModel.GetTutor(Session["Key"] as string);

            return View(tutorEditProfileModel);
        }

        [HttpPost]
        public ActionResult EditProfile(TutorEditProfileModel tutorEditProfileModel)
        {
            var updatedTutor = tutorEditProfileModel.Tutor;
            updatedTutor.Email = Session["Key"] as string;
            updatedTutor.PreferredClasses = new List<string>();
            updatedTutor.PreferredLocations= new List<string>();
            updatedTutor.PreferredMedium= new List<string>();

            try
            {
                foreach (var location in tutorEditProfileModel.AvailableLocations)
                {
                    if (location.IsChecked)
                    {
                        updatedTutor.PreferredLocations.Add(location.Name);
                    }
                }

                foreach (var Class in tutorEditProfileModel.Classes)
                {
                    
                    if (Class.IsChecked)
                    {
                        updatedTutor.PreferredClasses.Add(Class.Name);
                    }
                }



                foreach (var medium in tutorEditProfileModel.Mediums)
                {
                    if (medium.IsChecked)
                    {
                        updatedTutor.PreferredMedium.Add(medium.Name);
                    }
                }

                IUserService<Tutor> tutorUserService= new TutorService();
                if (tutorUserService.Update(updatedTutor))
                {
                    return RedirectToAction("Dashboard");
                }
                throw  new Exception("Failed to update");
            }
            catch
            {
                return View(tutorEditProfileModel);
            }
        }

        [HttpGet]
        public ActionResult StudentList(int? id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewProfile()
        {
            var tutorservice =(TutorService) new ServiceProvider().Create<Tutor>();
            var tutor = tutorservice.GetByEmailWithLists(Session["KEY"] as String);
            
            return View(tutor);
        }

       
        [HttpGet]
        public ActionResult Notification()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Chat()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Blog()
        {
            List<Blog> blogs= new BlogService().GetAll(Session["Key"] as string);
            return View(blogs);
        }


        [HttpGet]
        public ActionResult ViewPost(int id)
        {
            Blog blog=new BlogService().GetById(id);
            return View(blog);
        }



        [HttpGet]
        public ActionResult NewPost()
        {
            return View(new Blog());

        }

        [HttpPost]
        public ActionResult NewPost(Blog blog)
        {

        
            var tutor = new ServiceProvider().Create<Tutor>().GetByEmail(Session["Key"] as string);
            blog.Author = tutor.Name;
            blog.Date = DateTime.Now;
            blog.Private = false;
            blog.Key = Session["Key"] as string;

            if (new BlogService().Add(blog))
            {
               return  RedirectToAction("Blog");
            }

            return View(blog);

        }

        public RedirectToRouteResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }

        public ActionResult UploadMaterial()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ScheduleProp()
        {
            return View(new ProposedSchedule());

        }


        [HttpPost]
        public ActionResult ScheduleProp(ProposedSchedule schedule)
        {

            return View();
        }

    }
}
