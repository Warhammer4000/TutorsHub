using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Data;
using Entity.QuestionModels;

namespace DLL.QuestionContext
{
    public class ExamScriptContext
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
