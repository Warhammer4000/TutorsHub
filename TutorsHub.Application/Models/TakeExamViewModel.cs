using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DataRepositoryFolder;
using Entity.Data;

namespace TutorsHub.Application.Models
{
    public class TakeExamViewModel
    {
        public List<string> ExamSubject { get; set; }
        public string SelectedSubject { get; set; }
        public int Difficulty { get; set; }
        public List<int> DifficultyLevels { get; set; }

        public TakeExamViewModel()
        {
            ExamSubject = new SubjectService().GetAll().Select(r=>r.Name).ToList();
            DifficultyLevels=new List<int>(){1,2,3};
        }

    }
}