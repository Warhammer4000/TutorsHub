using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Entity.UserModels;

namespace Entity.Data
{
    public class DataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Key]
        public string Name { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }
       
    }
}
