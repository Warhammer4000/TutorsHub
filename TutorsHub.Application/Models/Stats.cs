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

        public readonly IDictionary<String, int> Locationstats = new Dictionary<string, int>();


        public Stats()
        {
            List<Location> locations = new LocationService().GetAll();
            foreach (var location in locations)
            {
                Locationstats.Add(location.Name, new SearchlogService().GetLocationSearchCount(location.Name));
            }


        }
    }
}