using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.UserModels;

namespace DLL.UserContext
{
    public class AdminContext:UserContext<Admin>, IUserContext<Admin>
    {

    }
}
