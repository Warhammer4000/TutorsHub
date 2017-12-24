using System.Collections.Generic;
using System.Linq;
using DLL.DataContext;
using Entity.Data;


namespace BLL.DataRepositoryFolder
{
    public abstract class DataService<T> where T:DataModel 
    {
        public List<T> GetAll() => new DataRepository<T>().GetAll();

        public T GetWitId(int id) => new DataRepository<T>().GetAll().FirstOrDefault(r => r.Id == id);

        public bool Add(T t) => new DataRepository<T>().Add(t);

        public bool Delete(int id) => new DataRepository<T>().Delete(id);

    }
}
