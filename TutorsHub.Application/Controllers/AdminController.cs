using System.Web.Mvc;
using BLL.DataRepository;
using Entity.Data;
using TutorsHub.Application.Models;

namespace TutorsHub.Application.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult ViewProfile()
        {
            return View();
        }

        public ActionResult EditProfile()
        {
            return View();
        }

        public ActionResult EditPassword()
        {
            return View();
        }

        public ActionResult UserSearch()
        {
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }

        public ActionResult QuestionPaper()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Locations()
        {
             IDataService<Location> locationDataService= new LocationService();

             LocationsViewModel locationsViewModel= new LocationsViewModel();
            locationsViewModel.Locations = locationDataService.GetAll();
             return View(locationsViewModel);
        }

        [HttpPost]
        public ActionResult Locations(LocationsViewModel locationsViewModel)
        {
            return View(locationsViewModel);
        }
        [HttpGet]
        public ActionResult Subjects()
        {
            IDataService<Subject> subjectDataService = new SubjectService();

            SubjectsViewModel subjectsViewModel = new SubjectsViewModel();
            subjectsViewModel.Subjects = subjectDataService.GetAll();
            return View(subjectsViewModel);
        }
        [HttpPost]
        public ActionResult Subjects(SubjectsViewModel subjectsViewModel)
        {
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