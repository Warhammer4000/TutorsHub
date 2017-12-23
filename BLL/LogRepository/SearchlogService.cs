using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.LogContext;
using Entity.Logs;

namespace BLL.LogRepository
{
    public class SearchlogService
    {
        private List<SearchLog> UserLogs => new SearchLogRepository().Get();

        public int TotalSearchCount => UserLogs.Count;

        public int GetLocationSearchCount(string location) => UserLogs.Count(r => r.Location == location);

        public int GetSubjectSearchCount(string subject) => UserLogs.Count(r => r.SubjecList.Contains(subject));

        public int GetGenderSearchCount(string gender) => UserLogs.Count(r => r.Gender == gender);

        public int GetClassSearchCount(string classs) => UserLogs.Count(r => r.Class == classs);

        public double AverageMinSial
        {
            get
            {
                try
                {
                    return UserLogs.Average(r => r.SalaryMin);
                }
                catch (Exception e)
                {
                    return 0;
                }

            }
        }

        public double AverageMaxSal
        {
            get
            {
                try
                {
                    return UserLogs.Average(r => r.SalaryMax);
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
        }
    }
}
