using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.UserContext;
using Entity.UserModels;

namespace BLL.UserRepository
{
    internal class TutorService:UserService<Tutor>,IUserService<Tutor>
    {
       
    }
}
