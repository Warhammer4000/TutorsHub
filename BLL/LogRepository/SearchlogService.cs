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
        private List<SearchLog> GetUserLogs()
        {
            return new SearchLogRepository().Get();
        }

        public int GetTotalSearchCount()
        {
            return GetUserLogs().Count;
        }

        public int GetLocationSearchCount(string location)
        {
            return GetUserLogs().Count(r => r.Location == location);
        }

        public int GetSubjectSearchCount(string subject)
        {
            return GetUserLogs().Count(r => r.SubjecList.Contains(subject));
        }

        public int GetGenderSearchCount(string gender)
        {
            return GetUserLogs().Count(r => r.Gender == gender);
        }

        public int GetClassSearchCount(string classs)
        {
            return GetUserLogs().Count(r => r.Class == classs);
        }

        public double GetAverageMinSial()
        {
            return GetUserLogs().Average(r => r.SalaryMin);
        }

        public double GetAverageMaxSial()
        {
            return GetUserLogs().Average(r => r.SalaryMax);
        }


    }
}
