using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Data;

namespace Entity.QuestionModels
{
   
    public class Question
    {
        [Key]
        public int Sl { get; set; }
        [Required]
        public int Id { get; set; }

        [Required]
        public int Difficulty { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Q { get; set; }
        [Required]
        public string A { get; set; }
        [Required]
        public string B { get; set; }
        [Required]
        public string C { get; set; }
        [Required]
        public string D { get; set; }
        [Required]
        public string Answer { get; set; }

    }
}
