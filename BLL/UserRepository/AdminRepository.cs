
using System.Collections.Generic;

using DLL.UserContext;
using Entity.UserModels;

namespace BLL.UserRepository
{
    public class AdminRepository:UserRepo<Admin>,IUserRepository<Admin>
    {
        
    }
}
