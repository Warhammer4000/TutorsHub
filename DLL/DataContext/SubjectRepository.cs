using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Entity.Data;

namespace DLL.DataContext
{
    public class SubjectRepository:DataRepository<Subject> ,IDataRepository<Subject>
    {
       
    }
}
