using System;
using System.Collections.Generic;
using System.Linq;
using DLL.ExamContext;
using Entity.Data;
using Entity.QuestionModels;

namespace BLL.Exam
{
    public class ExamService
    {
        public int ValidateExamScript(List<ExamQuestion> examScript, string subject)
        {
            int score = 0;
           
                //Brings Questions Then matches it to ExamScript and counts score
                List<Question> questions = new ExamScripRepository().GetQuestionsBySubject(subject);

                score += (from examQuestion
                        in examScript
                        let q = questions.First(r => r.Id == examQuestion.Id)
                        where q.Answer == examQuestion.Answer
                        select examQuestion)
                    .Count();
              //TODO Post score to DB
                return score;
            
        }


        public List<ExamQuestion> GetQuestionsBySubjectWithDifficulty(string subject,int difficulty)
        {
            
                //Brings Questions Then converts it to ExamScript which is a list of questions without answer
                List<Question> questions = new ExamScripRepository().GetQuestionsBySubjectWithDifficulty(subject,difficulty);
                List<ExamQuestion> examScript = new List<ExamQuestion>();
                foreach (var question in questions)
                {
                    var examQuestion = new ExamQuestion(question);
                    examScript.Add(examQuestion);
                }
                return examScript;
            
        }


      


    }
}
