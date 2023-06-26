using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BengkelMotorApp.Models
{
    public class Transaction : BaseModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("user_id", TypeName = "varchar(255)")]
        public string? UserId { get; set; }

        [Required]
        [Column("transaction_number", TypeName = "varchar(255)")]
        public string? TransactionNumber { get; set; }

        [Required]
        [Column("transaction_date", TypeName = "datetime")]
        public DateTime? TransactionDate { get; set; }

        [Required]
        [Column("total_price", TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Column("description", TypeName = "text")]
        public string? Description { get; set; }

        List<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
    }
}
