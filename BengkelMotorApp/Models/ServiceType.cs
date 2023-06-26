using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BengkelMotorApp.Models
{
    public class ServiceType : BaseModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(255)")]
        public string? Name { get; set; }
        
        [Required]
        [Column("price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("is_active")]
        public bool? IsActive { get; set; }
    }
}
