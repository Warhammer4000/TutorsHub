using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DataRepository;
using Entity.Data;
using Entity.UserModels;

namespace ATP2.Profile.Models.HomeModels
{
    public class SearchModel
    {
        public List<Subject> Subjects { get; set; }
        public List<Location> Locations { get; set; }
        public List<Tutor> TutorList { get; set; }
        public string SearchButton { get; set; }
        public SearchModel()
        {
            Subjects=new SubjectRepository().GetAll();
            Locations= new LocationRepostiory().GetAll();
            TutorList= new List<Tutor>();
            Location=new Location();
      
        }

        

        public Location Location { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public List<Subject> SelectedSubjects { get; set; }

    }
}