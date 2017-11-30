
using System.Linq;
using BLL;
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
            
            Admin = new ServiceProvider().Create<Tutor>().GetAll().Count;
            Executive = 0;


            Tutor = new ServiceProvider().Create<Tutor>().GetAll().Count;
            Total = Admin + Executive + Tutor;
        }

    }
}