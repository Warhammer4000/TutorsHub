using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Others
{
    public class Schedule
    {
        public Dictionary<string,Timings> WeekDays { get; set; }

        public Schedule()
        {
            WeekDays.Add("Saturday",new Timings());
            WeekDays.Add("Sunday", new Timings());
            WeekDays.Add("Monday", new Timings());
            WeekDays.Add("Tuesday", new Timings());
            WeekDays.Add("Wednesday", new Timings());
            WeekDays.Add("Thursday", new Timings());
            WeekDays.Add("Friday", new Timings());
        }



    }

    public class Timings
    {
        public Dictionary<string, string> Times { get; set; }
        //Keys will have time as string and values would be user's key[For now Email]
    }
}
