using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDapp.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [Display(Name="Employee Name")]
        [MaxLength(30)]
        [MinLength(4)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string? Mobile { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string? City { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Gender { get; set; }

        [Required]
        public Double Salary { get; set; }

        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
    }
}
