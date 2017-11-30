using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.DataContext;
using Entity.Data;

namespace BLL.DataRepository
{
    public class LocationService:IDataService<Location>
    {
        public List<Location> GetAll()
        {
           return new LocationContext().GetAll();
        }
    }
}
