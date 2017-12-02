using System.Web.Mvc;
using BLL;
using BLL.UserRepository;

namespace ATP2.Profile.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult DashBoard()
        {
            return View();
        }
        [HttpGet]
        public RedirectToRouteResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Report()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ExamResult()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudyMaterial()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OnlineExam()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HireTutor()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult EditProfile()
        {
            return View();
        }
        public ActionResult Notification()
        {
            return View();
        }
    }
}