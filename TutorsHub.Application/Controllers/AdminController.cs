using System.Web.Mvc;
using Entity.Data;
using TutorsHub.Application.Models;
using Entity.UserModels;

using BLL;

using BLL.DataRepositoryFolder;

using System;
using BLL.LogRepository;
using BLL.UserRepository;

namespace TutorsHub.Application.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult AdminDashboard()
        {

            Stats all = new Stats();
           

            return View(all);
        }

        [HttpGet]
        public ActionResult ViewProfile()
        {
            var adminservice = new ServiceProvider().Create<Admin>();
            var admin = adminservice.GetByEmail(Session["KEY"] as string);
            return View(admin);
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            var adminService = new ServiceProvider().Create<Admin>();
            return View(adminService.GetByEmail(Session["Key"] as string));
        }

        [HttpPost]
        public ActionResult EditProfile(Admin model)
        {
            var adminUpdate = new ServiceProvider().Create<Admin>();
            model.Email = Session["Key"] as string;
            if (adminUpdate.Update(model))
            {
                return RedirectToAction("ViewProfile", "Admin");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditPassword()
        {
            return View(new EditPass());
        }
        [HttpPost]
        public ActionResult EditPassword(EditPass editPass)
        {
            var userservice = new UserService<Admin>();

            var adminservice = new ServiceProvider().Create<Admin>();
            var admin = adminservice.GetByEmail(Session["KEY"] as string);

            if(editPass.NewPassword== editPass.RepPassword)
            {
                userservice.UpdatePassword(admin.Email, editPass.NewPassword);
            }

            return View(editPass);
        }

        public ActionResult UserSearch()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewUser()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult NewUser(User user)
        {   

            user.UserSince= DateTime.Now;
            user.LastLogin=DateTime.Now;
            user.DateOfBirth=DateTime.Now;
            user.Status = Status.Active;
         
            switch (user.Type)
            {
                case "Admin":
                    var userservice = new UserService<Admin>();
                    var admin = (Admin) user;
                    userservice.Add(admin);
                    break;
                case "Tutor":
                    var tutorservice = new UserService<Tutor>();
                    Tutor tutor = (Tutor) user;
                    tutorservice.Add(tutor);
                    break;
                case "Student":
                    var studentservice = new UserService<Student>();
                    var student = (Student) user;
                    studentservice.Add(student);
                    break;
            }


            RedirectToAction("AdminDashboard", "Admin");

            return View(user);
        }

        public ActionResult QuestionPaper()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Locations()
        {
             IDataService<Location> locationDataService= new LocationService();

            var locationsViewModel = new LocationsViewModel
            {
                Locations = locationDataService.GetAll()
            };
            return View(locationsViewModel);
        }

      

        [HttpPost]
        public ActionResult Locations(int id)
        {   
             var locationsViewModel=new LocationsViewModel();
            IDataService<Location> locationDataService = new LocationService();
            if (locationDataService.Delete(id))
            {
                 locationsViewModel.Locations = locationDataService.GetAll();

            }

            return View(locationsViewModel);
        }


        [HttpGet]
        public ActionResult Subjects()
        {
            IDataService<Subject> subjectDataService = new SubjectService();

            var subjectsViewModel = new SubjectsViewModel
            {
                Subjects = subjectDataService.GetAll()
            };
            return View(subjectsViewModel);
        }

        [HttpPost]
        public ActionResult Subjects(int id)
        {
            var subjectsViewModel = new SubjectsViewModel();
            IDataService<Subject> subjectDataService = new SubjectService();
            if (subjectDataService.Delete(id))
            {
                subjectsViewModel.Subjects = subjectDataService.GetAll();

            }

            return View(subjectsViewModel);
        }

        public ActionResult Notification()
        {
            return View();
        }

        public ActionResult Statistics()
        {

            var loc = new SearchlogService();
            var locationViewModel = new LocationsViewModel();
            var stt = new Stats();

            //foreach (int i = 0; i < locationViewModel.Locations.Count; i++)
            //{
            //    stt.Locationstats.Add(locationViewModel.Locations ,loc.GetLocationSearchCount((locationViewModel.Locations[i]).ToString()));
            //}
            return View();
        }

        public RedirectToRouteResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}