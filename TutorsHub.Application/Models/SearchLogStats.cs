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
    public class SearchLogStats
    {

        public readonly IDictionary<string, int> Locationstats = new Dictionary<string, int>();
        public readonly IDictionary<string, int> Subjectstats = new Dictionary<string, int>();
        public readonly IDictionary<int, int> Classstats = new Dictionary<int, int>();
        public readonly IDictionary<string, int> Genderstats = new Dictionary<string, int>();
        public readonly IDictionary<string, double> AvgSalary = new Dictionary<string, double>();

        public SearchLogStats()
        {
            List<Location> locations = new LocationService().GetAll();
            foreach (var location in locations)
            {

                Locationstats.Add(location.Name,
                    new SearchlogService().GetLocationSearchCount(location.Name));
            }

            List<Subject> subjects = new SubjectService().GetAll();
            foreach (var subject in subjects)
            {
                Subjectstats.Add(subject.Name, new SearchlogService().GetSubjectSearchCount(subject.Name));
            }

            AvgSalary.Add("Minimum Salary", new SearchlogService().GetAverageMinSial());
            AvgSalary.Add("Maximum Salary", new SearchlogService().GetAverageMaxSial());



            for (int i = 1; i <= 12; i++)
            {
                Classstats.Add(i, new SearchlogService().GetClassSearchCount(i.ToString()));
            }

            Genderstats.Add("Male", new SearchlogService().GetGenderSearchCount("Male"));
            Genderstats.Add("Female", new SearchlogService().GetGenderSearchCount("Female"));

           

        }

    }
}