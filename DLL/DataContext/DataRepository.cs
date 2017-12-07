using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Data;

namespace DLL.DataContext
{
    public class DataRepository<T> where T : DataModel 
    {
        public List<T> GetAll()
        {
            using (var context = new Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetWithTutors(string subjectName)
        {
            
            using (var context = new Context())
            {
                return context.Set<T>().Include(x => x.Tutors).FirstOrDefault(r => r.Name == subjectName);
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

        public bool Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
