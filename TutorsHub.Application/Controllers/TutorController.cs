using BLL;
using Entity.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.BlogRepository;
using BLL.NotificationRepository;
using BLL.UserRepository;
using Entity.BlogModel;
using Entity.Data;
using TutorsHub.Application.Models;
using Entity.Others;
using Newtonsoft.Json;

namespace TutorsHub.Application.Controllers
{
    public class TutorController : Controller
    {

        [HttpGet]
        public ActionResult Dashboard()
        {
            
            return View(new Tutor());
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
        public ActionResult StudentList()
        {
            List<Student> studentList= new ServiceProvider().Create<Tutor>().GetByEmail(Session["Key"] as string).Students;
            return View(studentList);
        }
        [HttpGet]
        public ActionResult ViewProfile()
        {
            var tutorservice =(TutorService) new ServiceProvider().Create<Tutor>();
            var tutor = tutorservice.GetByEmailWithLists(Session["KEY"] as String);
            
            return View(tutor);
        }

       
      

        [HttpGet]
        public ActionResult Chat()
        {
            IUserService<Tutor> userService= new ServiceProvider().Create<Tutor>();
            ChatViewModel chatViewModel = new ChatViewModel();
            chatViewModel.Users = userService.GetByEmail(Session["Key"] as string).Students.ToList<User>();
            return View(chatViewModel);
        }


        [HttpPost]
        public ActionResult Chat(ChatViewModel chatViewModel)
        {
            var notification = new Notification
            {
                Message = chatViewModel.Message,
                Key = chatViewModel.UserKey,
                Notificationtype = Notificationtype.Message
                ,ActionLink = new ServiceProvider().Create<Tutor>().GetByEmail(Session["Key"] as string).Name
            };

            if (new NotificationService().Add(notification))
            {
                
            }

            return RedirectToAction("Dashboard", "Tutor");
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
        public ActionResult ScheduleProp(string scheduleString)
        {
            ProposedSchedule proposedSchedule = JsonConvert.DeserializeObject<ProposedSchedule>(scheduleString);
            return View(proposedSchedule);

        }


        [HttpPost]
        public ActionResult ScheduleProp(ProposedSchedule schedule)
        {

            return View();
        }

    }
}
