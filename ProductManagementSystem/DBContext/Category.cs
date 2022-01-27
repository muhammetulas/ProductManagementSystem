using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.DBContext
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public int ParentID { get; set; }
    }
}
