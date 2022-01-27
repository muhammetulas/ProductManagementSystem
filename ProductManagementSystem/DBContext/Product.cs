using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.DBContext
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public int CategoryID { get; set; }
    }
}
