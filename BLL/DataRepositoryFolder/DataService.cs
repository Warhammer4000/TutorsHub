using System.Collections.Generic;
using System.Linq;
using DLL.DataContext;
using Entity.Data;


namespace BLL.DataRepositoryFolder
{
    public abstract class DataService<T> where T:DataModel 
    {
        public List<T> GetAll()
        {
            return new DataRepository<T>().GetAll();
        }

        public T GetWitId(int id)
        {
            return new DataRepository<T>().GetAll().FirstOrDefault(r => r.Id==id);
        }

        public bool Add(T t)
        {
            return new DataRepository<T>().Add(t);
        }
        
        public bool Delete(int id)
        {
            return new DataRepository<T>().Delete(id);
        }

    }
}
