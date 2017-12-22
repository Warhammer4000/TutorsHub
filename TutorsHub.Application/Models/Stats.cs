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


        public readonly IDictionary<DateTime, int> Trafficad = new Dictionary<DateTime, int>();

        public readonly IDictionary<DateTime, int> Traffictut = new Dictionary<DateTime, int>();

        public readonly IDictionary<DateTime, int> Trafficstu = new Dictionary<DateTime, int>();

        public Stats()
        {
            
                Trafficad.Add(new DateTime(2017,1,1), new UserLogService().GetUserCount(Role.Admin, new DateTime(2017, 1, 1)));
        }

    }
}