
using System.Linq;

using DLL.Service;
using Entity;

namespace ATP2.Profile.Models.ReportModels
{
    public class StatisticReport
    {
        public int Admin { get; }
        public int Executive { get; }
        public int User { get; }
        public int Total { get;  }

        public StatisticReport()
        {
            var users= new UserService().GetUsers();
            Admin = users.Count(r => r.Role == Role.Admin);
            Executive = users.Count(r => r.Role == Role.Executive);
            User = users.Count(r => r.Role == Role.User);
            Total = Admin + Executive + User;
        }

    }
}