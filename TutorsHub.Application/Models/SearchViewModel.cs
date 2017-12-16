using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DataRepositoryFolder;
using Entity.Data;

namespace TutorsHub.Application.Models
{
    public class SearchViewModel
    {
        public List<Location> Locations { get; set; }
        public string Location { get; set; }
        public List<Class> Classes { get; set; }
        public string Class { get; set; }
        public List<Subject> Subjects { get; set; }
        public double MinSal { get; set; }
        public double MaxSal { get; set; }
        public  string Gender { get; set; }

        public List<string> SelectedSubjects
        {
            get
            {
                List<string> x= new List<string>();
                foreach (var subject in Subjects)
                {
                    if (subject.IsChecked)
                    {
                        x.Add(subject.Name);
                    }
                }
                return x;
            }
           
        }

        public SearchViewModel()
        {
            Locations = new LocationService().GetAll();
            Subjects=  new SubjectService().GetAll();
            Classes = new List<Class>();
            for (int i = 0; i < 12; i++)
            {
                Classes.Add(new Class(){Name = (i+1).ToString()});
            }
            
        }
    }


    
}