using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.ExamContext;
using Entity.QuestionModels;

namespace BLL.Exam
{
    public class QuestionService
    {
        public List<Question> GetQuestions() => new QuestionsRepository().GetQuestions();

        public bool UpdateExamQuestions(List<Question> newQuestions) => new QuestionsRepository().UpdateQuestionsScript(newQuestions);
    }
}
