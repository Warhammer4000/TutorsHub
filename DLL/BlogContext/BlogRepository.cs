using System;
using System.Collections.Generic;
using System.Linq;

using Entity.BlogModel;

namespace DLL.BlogContext
{
    public class BlogRepository
    {


        public List<Blog> GetAll()
        {
            using (var context = new Context())
            {
                return context.Set<Blog>().ToList();
            }
        }


        public List<Blog> GetAll(string key)
        {
            using (var context = new Context())
            {
                return context.Set<Blog>().Where(r=>r.Key==key).ToList();
            }
        }

        public bool Add(Blog blog)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Set<Blog>().Add(blog);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }

        public bool Remove(int id)
        {
            using (var context = new Context())
            {
                try
                {
                    var blog = context.Set<Blog>().First(r => r.Id == id);
                    context.Set<Blog>().Remove(blog);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }


        public bool Update(Blog blog)
        {
            using (var context = new Context())
            {
                try
                {
                    var oldBlog = context.Set<Blog>().First(r => r.Id == blog.Id);
                    oldBlog.Content = blog.Content;
                    oldBlog.Title = blog.Title;
                    oldBlog.Private = blog.Private;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }



    }
}
