using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Data;

namespace DLL.DataContext
{
    public class LocationRepository:DataRepository<Location>, IDataRepository<Location>
    {
       
    }
}
