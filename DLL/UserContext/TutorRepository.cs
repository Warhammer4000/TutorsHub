using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.UserModels;

namespace DLL.UserContext
{
    public class TutorRepository:UserRepository<Tutor>,IUserRepository<Tutor>
    {

        public  Tutor GetByEmailWithLists(string email)
        {
            using (var context = new Context())
            {
                return context.Set<Tutor>().Where(r=>r.Email==email)
                    .Include(x=>x.PreferredLocations)
                    .Include(x=>x.PreferredSubjects)
                    .FirstOrDefault();
            }
        }


    }
}
