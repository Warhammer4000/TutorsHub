using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Exam;
using Entity.QuestionModels;

namespace TutorsHub.Application.Models
{
    public class QuestionsViewModel
    {
        public List<Question> Questions { get; set; }

        public QuestionsViewModel()
        {
           
            Questions = new QuestionService().GetQuestions();
        }

    }
}