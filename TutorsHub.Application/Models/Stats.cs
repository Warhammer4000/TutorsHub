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


        public readonly IDictionary<DateTime, int> TutorTraffic = new Dictionary<DateTime, int>();

        public readonly IDictionary<DateTime, int> StudentTraffic = new Dictionary<DateTime, int>();

        public readonly IDictionary<DateTime, int> AdminTraffic = new Dictionary<DateTime, int>();

        public Stats()
        {
            var first = DateTime.Today.AddDays(-30);
            var counter = 0;
            for (var current = first; counter<30; current = current.AddDays(1))
            {
                counter++;
                TutorTraffic.Add(current, new UserLogService().GetUserCount(Role.Tutor, current));
                StudentTraffic.Add(current, new UserLogService().GetUserCount(Role.Student, current));
                AdminTraffic.Add(current, new UserLogService().GetUserCount(Role.Admin, current));
            }
           
       
        }

    }
}