using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.UserModels;

namespace DLL.UserContext
{
    public class AdminContext:IUserContext<Admin>
    {
        public Admin GetByName(string userName)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Add(Admin t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Admin t)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
