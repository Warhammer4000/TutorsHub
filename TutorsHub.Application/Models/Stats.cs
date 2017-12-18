using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TutorsHub.Application.Models
{
    public class Stats
    {
        public int AdminStats { get; set; }
        public int TutorStats { get; set; }
        public int StudentStats { get; set; }

        public IDictionary<String, int> Locationstats = new Dictionary<string, int>();


    }
}