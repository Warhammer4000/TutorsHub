using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using BLL.Exam;
using Entity.QuestionModels;
using TutorsHub.Application.Models;

namespace TutorsHub.Application.Controllers
{
    public class ExamController : Controller
    {
        [HttpGet]
        public ActionResult TakeExam()
        {
            return View(new TakeExamViewModel());
        }

        [HttpPost]
        public RedirectToRouteResult TakeExam(TakeExamViewModel takeExamViewModel)
        {
            ViewBag.Exam = takeExamViewModel.SelectedSubject;
            return RedirectToAction("QuestionPaper", "Exam", new { subject = takeExamViewModel.SelectedSubject, difficulty = takeExamViewModel.Difficulty });
        }

        [HttpGet]
        public ActionResult QuestionPaper(string subject,int difficulty)
        {
            ViewBag.Exam = subject;
            List<ExamQuestion> questions =
                new ExamService().GetQuestionsBySubjectWithDifficulty(subject,difficulty);
            return View(questions);
        }

        [HttpPost]
        public ActionResult QuestionPaper(List<ExamQuestion> questions,string subject)
        {
            int Score= new ExamService().ValidateExamScript(questions,subject);
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