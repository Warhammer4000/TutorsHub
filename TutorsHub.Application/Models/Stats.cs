using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DataRepositoryFolder;
using BLL.LogRepository;
using BLL.StatisticRepository;
using Entity.Data;
using Entity.UserModels;

namespace TutorsHub.Application.Models
{
    public class Stats
    {
        public int AdminStats => new UserStatisticService<Admin>().GetCount();
        public int TutorStats => new UserStatisticService<Tutor>().GetCount();
        public int StudentStats => new UserStatisticService<Student>().GetCount();
        
        

        public readonly IDictionary<string, int> Locationstats = new Dictionary<string, int>();
        public readonly IDictionary<string, int> Subjectstats = new Dictionary<string, int>();
        public readonly IDictionary<int, int> Classstats = new Dictionary<int, int>();
        public readonly IDictionary<string, int> Genderstats = new Dictionary<string, int>();
        public readonly IDictionary<string, double> Salarystats = new Dictionary<string, double>();



        public Stats()
        {
            List<Location> locations = new LocationService().GetAll();
            foreach (var location in locations)
            {
                
                Locationstats.Add(location.Name, 
                    new SearchlogService().GetLocationSearchCount(location.Name));
            }

            List<Subject> subjects = new SubjectService().GetAll();
            foreach(var subject in subjects)
            {
                Subjectstats.Add(subject.Name, new SearchlogService().GetSubjectSearchCount(subject.Name));
            }

            for(int i=0;i<12; i++)
            {
                Classstats.Add(i, new SearchlogService().GetClassSearchCount(i.ToString()));
            }

            Genderstats.Add("Male", new SearchlogService().GetGenderSearchCount("Male"));
            Genderstats.Add("Female", new SearchlogService().GetGenderSearchCount("Female"));

            Salarystats.Add("Minimum Salary", new SearchlogService().GetAverageMinSial());
            Salarystats.Add("Maximum Salary", new SearchlogService().GetAverageMaxSial());
        }


    
    }
}