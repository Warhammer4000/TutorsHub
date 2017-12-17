using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Logs
{
    public class Log
    {
        [Key]
        public int Serial { get; set; }
        public string Message { get; set; }

    }
}
