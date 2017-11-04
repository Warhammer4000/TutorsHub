using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.UserContext;
using Entity.UserModels;

namespace BLL.UserRepository
{
    public class AdminRepository:IUserRepository<Admin>
    {
        public Admin GetByName(string userName)
        {
            return new AdminContext().GetByName(userName);
        }

        public List<Admin> GetAll()
        {
            return new AdminContext().GetAll();
        }

        public bool Add(Admin t)
        {
            return new AdminContext().Add(t);
        }

        public bool Update(Admin t)
        {
            return new AdminContext().Update(t);
        }

        public bool Remove(string userName)
        {
            return new AdminContext().Remove(userName);
        }
    }
}
