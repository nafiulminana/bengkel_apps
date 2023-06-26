using System.ComponentModel.DataAnnotations.Schema;

namespace BengkelMotorApp.Models
{
    public class BaseModel
    {
        [Column("created_by")]
        public string? CreatedBy { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_by")]
        public string? UpdatedBy { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
