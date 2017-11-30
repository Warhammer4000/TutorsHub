using System.Web.Mvc;
using BLL;
using BLL.UserRepository;

namespace ATP2.Profile.Controllers
{
    public class TutorController : Controller
    {
        

        

        // GET: Tutor
        [HttpGet]
        public ActionResult DashBoard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Payment()
        {
            return View();
        }


        [HttpGet]
        public ActionResult StudentList()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ViewStudent()
        {
            IUserService<Entity.UserModels.Student> studenService = new ServiceProvider().Create<Entity.UserModels.Student>();
            return View(studenService.GetByEmail("jahid@gmail.com"));
        }

        [HttpGet]
        public ActionResult ViewProfile()
        {
            IUserService<Entity.UserModels.Tutor> irepository= new ServiceProvider().Create<Entity.UserModels.Tutor>();
            return View(irepository.GetByEmail(Session["UserName"].ToString()));
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            IUserService<Entity.UserModels.Tutor> irepository = new ServiceProvider().Create<Entity.UserModels.Tutor>();
            return View(irepository.GetByEmail(Session["UserName"].ToString()));
        }



        [HttpPost]
        public ActionResult EditProfile(Entity.UserModels.Tutor tutor)
        {
            //TODO Update Database 
            return View(tutor);
        }


        #region Blog

        [HttpGet]
        public ActionResult Blog()
        {

            return View();
        }

        [HttpGet]
        public ActionResult NewBlogPost()
        {

            return View();
        }



        [HttpGet]
        public ActionResult BlogContent()
        {

            return View();
        }

        #endregion

        [HttpGet]
        public ActionResult Timer()
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