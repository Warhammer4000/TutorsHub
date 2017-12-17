using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Logs;

namespace DLL.LogContext
{
    public class LogRepository<T>:ILogRepository<T> where T:Log
    {
        public List<T> Get()
        {
            using (var context = new Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public bool Add(T t)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Set<T>().Add(t);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }
    }
}
