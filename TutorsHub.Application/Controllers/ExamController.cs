using System.Web.Mvc;

namespace TutorsHub.Application.Controllers
{
    public class ExamController : Controller
    {
        public ActionResult QuestionPaper()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public ActionResult Result()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Ranking()
        {
            return View();
        }
    }
}