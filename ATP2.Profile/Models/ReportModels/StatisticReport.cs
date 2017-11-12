
using System.Linq;
using BLL.UserRepository;
using Entity;
using Entity.UserModels;

namespace ATP2.Profile.Models.ReportModels
{
    public class StatisticReport
    {
        public int Admin { get; }
        public int Executive { get; }
        public int Tutor { get; }
        public int Total { get;  }

        public StatisticReport()
        {
    
            Admin = new AdminRepository().GetAll().Count;
            Executive = 0;
            Tutor = new TutorRepository().GetAll().Count;
            Total = Admin + Executive + Tutor;
        }

    }
}