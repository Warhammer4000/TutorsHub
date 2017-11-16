using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.UserContext;
using Entity.UserModels;

namespace BLL.UserRepository
{
    public class TutorRepository:UserRepo<Tutor>,IUserRepository<Tutor>
    {
       
    }
}
