using System.Collections.Generic;
using System.Linq;
using Entity.QuestionModels;

namespace DLL.ExamContext
{
    public class ExamScripRepository
    {
        public List<Question> GetQuestionsBySubject(string subject)
        {
            using (var context = new Context())
            {
                return context.QuestionPapers.Where(r => r.Subject == subject).ToList();
                
            }
        }


        public List<Question> GetQuestionsBySubjectWithDifficulty(string subject,int difficulty)
        {
            using (var context = new Context())
            {
                return context.QuestionPapers
                    .Where(r => r.Subject == subject && r.Difficulty==difficulty)
                    .ToList();

            }
        }


       


    }
}
