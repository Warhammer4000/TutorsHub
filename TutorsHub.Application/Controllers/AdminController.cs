using System.Web.Mvc;
using Entity.Data;
using TutorsHub.Application.Models;
using Entity.UserModels;
using BLL;
using BLL.DataRepositoryFolder;
using System;
using BLL.UserRepository;

namespace TutorsHub.Application.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminDashboard()
        {
            return View();
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
        public ActionResult Locations(LocationsViewModel locationsViewModel)
        {
            IDataService<Location> locationDataService = new LocationService();
            if (locationsViewModel.NewLocation != null)
            {
                locationDataService.Add(locationsViewModel.NewLocation);
            }

            locationsViewModel = new LocationsViewModel
            {
                Locations = locationDataService.GetAll()
            };

            return View(locationsViewModel);
        }

        [HttpDelete]
        public ActionResult Locations(int id)
        {
            IDataService<Location> locationDataService = new LocationService();

            var locationsViewModel = new LocationsViewModel
            {
                Locations = locationDataService.GetAll()
            };

            Location loc = locationsViewModel.Locations.Find(x => x.Id.Equals(id));

            locationDataService.Delete(loc);

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
        public ActionResult Subjects(SubjectsViewModel subjectsViewModel)
        {
            IDataService<Subject> subjectDataService = new SubjectService();
            if (subjectsViewModel.NewSubject!= null)
            {
                subjectDataService.Add(subjectsViewModel.NewSubject);
            }

            subjectsViewModel = new SubjectsViewModel
            {
                Subjects = subjectDataService.GetAll()
            };
            return View(subjectsViewModel);
        }

        public ActionResult Notification()
        {
            return View();
        }

        public ActionResult Statistics()
        {
            return View();
        }

        public RedirectToRouteResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}