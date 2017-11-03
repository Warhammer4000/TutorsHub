using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.UserContext;
using Entity.UserModels;

namespace BLL.UserRepository
{
    class TutorRepository:IUserRepository<Tutor>
    {
        public Tutor GetByName(string userName)
        {
           return new TutorContext().GetByName(userName);
        }

        public List<Tutor> GetAll()
        {
            return new TutorContext().GetAll();
        }

        public bool Add(Tutor t)
        {
            return new TutorContext().Add(t);
        }

        public bool Update(Tutor t)
        {
            return new TutorContext().Update(t);
        }

        public bool Remove(string userName)
        {
            return new TutorContext().Remove(userName);
        }
    }
}
