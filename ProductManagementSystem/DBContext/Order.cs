using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementSystem.DBContext
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Price { get; set; }
    }
}
