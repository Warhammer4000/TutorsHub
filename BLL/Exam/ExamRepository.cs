using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using DLL.QuestionContext;
using Entity.Data;
using Entity.QuestionModels;

namespace BLL.Exam
{
    public class ExamRepository
    {
        public int ValidateExamScript(List<ExamQuestion> examScript, Subject subject)
        {
            int score = 0;
           
                //Brings Questions Then matches it to ExamScript and counts score
                List<Question> questions = new ExamScriptContext().GetQuestionsBySubject(subject);

                score += (from examQuestion
                        in examScript
                        let q = questions.First(r => r.Id == examQuestion.Id)
                        where q.Answer == examQuestion.Answer
                        select examQuestion)
                    .Count();

                return score;
            
        }


        public List<ExamQuestion> GetQuestionsBySubjectWithDifficulty(Subject subject,int difficulty)
        {
            
                //Brings Questions Then converts it to ExamScript which is a list of questions without answer
                List<Question> questions = new ExamScriptContext().GetQuestionsBySubjectWithDifficulty(subject,difficulty);
                List<ExamQuestion> examScript = new List<ExamQuestion>();
                foreach (var question in questions)
                {
                    var examQuestion = new ExamQuestion(question);
                    examScript.Add(examQuestion);
                }
                return examScript;
            
        }


        public bool UpdateExamQuestions(List<Question> newQuestions,Subject subject)
        {
            return  new ExamScriptContext().UpdateExamScript(newQuestions,subject);
        }


    }
}
