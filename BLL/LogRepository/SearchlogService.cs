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

    }
}
