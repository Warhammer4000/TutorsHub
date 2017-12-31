using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entity.Others
{
    public class Schedule
    {
        public Dictionary<string,Timings> WeekDays { get; set; }

        public string ScheduleAsString {
            get => JsonConvert.SerializeObject(WeekDays);
            set => WeekDays = JsonConvert.DeserializeObject<Dictionary<string, Timings>>(value);
        }
        public Schedule()
        {
            WeekDays = new Dictionary<string, Timings>
            {
                {"Saturday", new Timings()},
                {"Sunday", new Timings()},
                {"Monday", new Timings()},
                {"Tuesday", new Timings()},
                {"Wednesday", new Timings()},
                {"Thursday", new Timings()},
                {"Friday", new Timings()}
            };
        }



    }

    public class Timings
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Meridium { get; set; }
    }
    }
