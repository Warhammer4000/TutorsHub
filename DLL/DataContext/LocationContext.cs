using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Data;

namespace DLL.DataContext
{
    public class LocationContext:IDataContext<Location>
    {
        public List<Location> GetAll()
        {
            using (var context = new Context())
            {
                return context.Locations.ToList();
            }
        }

        public Location GetWithTutors(string subjectName)
        {
            using (var context = new Context())
            {
                return context.Locations.Include(x=>x.Tutors).FirstOrDefault(r => r.Name == subjectName);
            }
        }

        public bool Add(Location t)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Locations.Add(t);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool Update(Location t)
        {
            throw new NotImplementedException();
        }
    }
}
