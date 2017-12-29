using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.QuestionModels;

namespace DLL.QuestionContext
{
    public class QuestionsRepository
    {

        public List<Question> GetQuestions()
        {
            using (var context = new Context())
            {
                return context.QuestionPapers.ToList();

            }
        }


        public bool UpdateQuestionsScript(List<Question> questions)
        {
            using (var context = new Context())
            {
                try
                {
                    List<Question> oldQuestionses = context.QuestionPapers.ToList();
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
