using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementSystem.DBContext
{
    public class OrderProduct
    {
        [Key]
        public int ID { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Price { get; set; }
    }
}
