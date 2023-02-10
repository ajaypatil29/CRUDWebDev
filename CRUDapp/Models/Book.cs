using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDapp.Models
{
    [Table("tblBook")]
    public class Book
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string ? Author { get; set; }
      
        [Required]
      
        public double  Price { get; set; }
    }
}
