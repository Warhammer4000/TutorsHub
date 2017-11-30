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
        public ActionResult Notification()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ViewProfile()
        {
            IUserService<Entity.UserModels.Student> studenService=new ServiceProvider().Create<Entity.UserModels.Student>();
            return View(studenService.GetByEmail("jahid@gmail.com"));//TODO change this to dynamic
        }

        [HttpGet]
        public ActionResult SearchTutor()
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