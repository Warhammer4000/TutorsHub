using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;
using ATP2.Profile.Models;

namespace ATP2.Profile.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            string errormessage;
            if (loginModel.Validation(out errormessage))
            {
                //Should be some action to go to next page 
            }

            ViewData["ErrorMessage"] = errormessage;
            return View(loginModel);
        }


        public ActionResult EditPassword()
        {
            return View(new EditPasswordModel());
        }

        [HttpPost]
        public ActionResult EditPassword(EditPasswordModel editPasswordModel)
        {
            string errorMessage;
            if (editPasswordModel.Validate(out errorMessage))
            {
                //Should be some action to go to next page 
            }


            ViewData["ErrorMessage"] = errorMessage;
            return View(editPasswordModel);
        }


        public ActionResult ProfilePicture()
        {
            return View(new ProfilePictureModel());
        }

        [HttpPost]
        public ActionResult ProfilePicture(ProfilePictureModel profilePictureModel)
        {
            string errorMessage;
            if (profilePictureModel.Validation(out errorMessage))
            {
                //Should be some action to go to next page 
            }
            ViewData["ErrorMessage"] = errorMessage;
            return View(profilePictureModel);

        }

        public ActionResult Registration()
        {
            return View(new RegistrationModel());
        }


        [HttpPost]
        public ActionResult Registration(RegistrationModel registrationModel)
        {

            string errorMessage;
            if (registrationModel.Validation(out errorMessage))
            {
                //Should be some action to go to next page 
            }
            ViewData["ErrorMessage"] = errorMessage;
            return View(registrationModel);

            
        }


    }
}