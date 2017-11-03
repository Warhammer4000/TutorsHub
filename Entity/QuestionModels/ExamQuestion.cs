using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.QuestionModels
{
    //This will be used as a viewModel
    public class ExamQuestion
    {
        
        public int Id { get; set; }
        public string Q { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Answer { get; set; }

        public ExamQuestion(Question question)
        {
            Id = question.Id;
            Q = question.Q;
            A = question.A;
            B = question.B;
            C = question.C;
            D = question.D;
        }
    }
}
