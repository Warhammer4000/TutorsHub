using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DLL
{
    public class Context:DbContext
    {
        public  Context():base("Name=ATP2")
        {
            
        }

        public DbSet<User> Users { get; set; }


    }
}
