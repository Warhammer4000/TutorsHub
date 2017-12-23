using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.BlogContext;
using Entity.BlogModel;

namespace BLL.BlogRepository
{
    public class BlogService
    {
        public List<Blog> GetAll() => new DLL.BlogContext.BlogRepository().GetAll();


        public List<Blog> GetAll(string key) => new DLL.BlogContext.BlogRepository().GetAll(key);
        public Blog GetById(int id) => GetAll().FirstOrDefault(r => r.Id == id);
        public bool Add(Blog blog) => new DLL.BlogContext.BlogRepository().Add(blog);

        public bool Remove(int id) => new DLL.BlogContext.BlogRepository().Remove(id);


        public bool Update(Blog blog) => new DLL.BlogContext.BlogRepository().Update(blog);
    }
}
