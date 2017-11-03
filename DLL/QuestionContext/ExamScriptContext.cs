using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.QuestionModels;

namespace DLL.QuestionContext
{
    public class ExamScriptContext
    {
        public List<Question> GetQuestionsBySubject(Subject subject)
        {
            using (var context = new Context())
            {
                return context.QuestionPapers.Where(r => r.Subject == subject).ToList();
                
            }
        }

        public bool UpdateExamScript(List<Question> questions,Subject subject)
        {
            using (var context = new Context())
            {
                try
                {
                    List<Question> oldQuestionses= context.QuestionPapers.Where(r => r.Subject == subject).ToList();
                    context.QuestionPapers.RemoveRange(oldQuestionses);
                    context.QuestionPapers.AddRange(questions);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    
                }

            }
        }


    }
}
