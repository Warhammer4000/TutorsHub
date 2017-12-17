using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.UserModels;

namespace Entity.Logs
{
    public class UserLog:Log
    {
        public DateTime LogDateTime { get; set; }
        public Role Role { get; set; }

    }
}
