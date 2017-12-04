using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.Data;

namespace TutorsHub.Application.Models
{
    public class SubjectsViewModel
    {
        public List<Subject> Subjects { get; set; }
        public Subject NewSubject { get; set; }

        public SubjectsViewModel()
        {
            NewSubject = new Subject();
            Subjects = new List<Subject>();
        }
    }
}