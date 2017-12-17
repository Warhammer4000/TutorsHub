using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Logs;

namespace DLL.LogContext
{
    interface ILogRepository<T> where T :Log
    {
        List<T> Get();
        bool Add(T t);

    }
}
