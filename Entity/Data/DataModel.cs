using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.UserModels;

namespace Entity.Data
{
    public class DataModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }
        public List<Tutor> Tutors { get; set; }

    }
}
