using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public bool Delete(int id)
        {
            using (var context = new Context())
            {
                try
                {
                    var a=context.Set<T>().FirstOrDefault(r=>r.Id==id);
                    context.Set<T>().Remove(a);
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
