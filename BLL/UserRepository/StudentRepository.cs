using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.UserModels;

namespace BLL.UserRepository
{
    internal class StudentRepository:UserRepo<Student>,IUserRepository<Student>
    {
    }
}
