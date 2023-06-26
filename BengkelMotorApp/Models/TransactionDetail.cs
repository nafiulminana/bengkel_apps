using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BengkelMotorApp.Models
{
    public class TransactionDetail
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("transaction_id")]
        public int TransactionId { get; set; }

        [Required]
        [Column("service_type_id")]
        public int ServiceTypeId { get; set; }

        [Required]
        [Column("spare_part_id")]
        public int SparePartId { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("total_price", TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [ForeignKey("TransactionId")]
        public Transaction Transaction { get; set; } = null!;

        [ForeignKey("ServiceTypeId")]
        public ServiceType ServiceType { get; set; } = null!;

        [ForeignKey("SparePartId")]
        public SparePart SparePart { get; set; } = null!;
    }
}
