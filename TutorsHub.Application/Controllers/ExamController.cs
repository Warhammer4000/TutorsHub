using System.Web.Mvc;

namespace TutorsHub.Application.Controllers
{
    public class ExamController : Controller
    {
        public ActionResult QuestionDifficulty()
        {
            return View();
        }

        public ActionResult QuestionPaper(int? id)
        {
            return View();
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