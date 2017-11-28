using System.Web.Mvc;
using BLL.UserRepository;

namespace ATP2.Profile.Controllers.Tutor
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
        public ActionResult StudentList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewProfile()
        {
            IUserRepository<Entity.UserModels.Tutor> irepository= new TutorRepository();
            return View(irepository.GetByEmail(Session["UserName"].ToString()));
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            IUserRepository<Entity.UserModels.Tutor> irepository = new TutorRepository();
            return View(irepository.GetByEmail(Session["UserName"].ToString()));
        }



        [HttpPost]
        public ActionResult EditProfile(Entity.UserModels.Tutor tutor)
        {
            //TODO Update Database 
            return View(tutor);
        }


        [HttpGet]
        public ActionResult Blog()
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