using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.DataContext;
using Entity.Data;

namespace BLL.DataRepository
{
    public class SubjectService:IDataService<Subject>
    {
        public List<Subject> GetAll()
        {
            return new SubjectContext().GetAll();
        }
    }
}
