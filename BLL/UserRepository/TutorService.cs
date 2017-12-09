using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.UserContext;
using Entity.UserModels;

namespace BLL.UserRepository
{
    public class TutorService:UserService<Tutor>,IUserService<Tutor>
    {
        public Tutor GetByEmailWithLists(string email)
        {
            return  new TutorRepository().GetByEmailWithLists(email);
        }
    }
}
