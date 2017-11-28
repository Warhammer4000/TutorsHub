using System.Web.Mvc;

namespace ATP2.Profile.Controllers.Student
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult DashBoard()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ViewProfile()
        {
            return View();
        }






        [HttpGet]
        public RedirectToRouteResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }





    }
}