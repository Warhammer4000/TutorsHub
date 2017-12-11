using System.Web.Mvc;
using Entity.Data;
using TutorsHub.Application.Models;
using Entity.UserModels;
using BLL;
using BLL.DataRepositoryFolder;
using System;

namespace TutorsHub.Application.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminDashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewProfile(Admin admin)
        {
            var adminservice = new ServiceProvider().Create<Admin>();
            admin = adminservice.GetByEmail(Session["KEY"] as string);
            return View(admin);
        }

        public ActionResult EditProfile()
        {
            var admin = new ServiceProvider().Create<Admin>();
            return View(admin.GetByEmail(Session["KEY"] as string));
        }

        public ActionResult EditPassword()
        {
            return View();
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
            switch (user.Type)
            {
                case "Admin":
                    var adminService = new ServiceProvider().Create<Admin>();
                    adminService.Add(new Admin
                    {
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,
                        UserSince = new DateTime(2008, 3, 15),
                        LastLogin = new DateTime(2008, 3, 15),
                        DateOfBirth = new DateTime(2008, 3, 15),
                        Role = Role.Admin,
                        Status = Status.Pending,
                        Address = "sfjslfjlskf",
                        Mobilenumber = "01923130",
                        Gender = "M",
                        ProfilePictureUrl = "dslkfjdslfdjslf"


                    });
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