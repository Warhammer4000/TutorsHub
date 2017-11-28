using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.Data;
using Entity.QuestionModels;
using Entity.UserModels;

namespace DLL
{
    internal class Context:DbContext
    {
        public  Context():base("Name=TutorsHub")
        {
            var ensureDLLIsCopied =
                System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Guests { get; set; }
        public DbSet<Executive> Executives { get; set; }
        public DbSet<Question> QuestionPapers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Location> Locations { get; set; }


    }
}
