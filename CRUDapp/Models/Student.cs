
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDapp.Models
{
    [Table("tblStudent")]
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int RollNo { get; set; }
        [Required]
        [MaxLength (20)]
        [MinLength(4)]
        public string? Name { get; set; }
        [Required]
        public String? Class { get; set; }
        [Required]
        public double  Marks { get; set; }

        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
    }
}
