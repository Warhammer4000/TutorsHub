using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using BLL.Exam;
using BLL.UserRepository;
using Entity.Others;
using Entity.QuestionModels;
using Entity.UserModels;
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
            TempData["Difficulty"] = difficulty;
            List<ExamQuestion> questions =
                new ExamService().GetQuestionsBySubjectWithDifficulty(subject,difficulty);
            return View(questions);
        }

        [HttpPost]
        public RedirectToRouteResult QuestionPaper(List<ExamQuestion> questions,string subject)
        {
            //Kinda dirty should update later 
            int score= new ExamService().ValidateExamScript(questions,subject);
            var examResult= new ResultService().Get(Session["Key"] as string);
            if (examResult == null)
            {
                examResult = new ExamResult {Key = Session["Key"] as string};
                examResult.TutorName=new UserService<Tutor>().GetByEmail(examResult.Key).Email;
            }
            try
            {
                if (examResult.Results
                    .Find(r => r.SubjectName == subject && r.Difficulty == (int) TempData["Difficulty"]).Score <=score)
                {
                    examResult.Results
                            .Find(r => r.SubjectName == subject && r.Difficulty == (int) TempData["Difficulty"]).Score =
                        score;
                }
            }
            catch (Exception)
            {
                examResult.Results.Add(new ResultData()
                {
                    Score = score,
                    SubjectName = subject,
                    Difficulty = (int)TempData["Difficulty"]
                });
            }
         

            if (!new ResultService().UpdateResult(examResult))
            {
                //show error
            }

            return RedirectToAction("Result","Exam");
        }

        [HttpGet]
        public ActionResult Result()
        {
            var examResult = new ResultService().Get(Session["Key"] as string) ?? new ExamResult();
            return View(examResult);
        }

        [HttpGet]
        public ActionResult Ranking()
        {
            return View();
        }
    }
}