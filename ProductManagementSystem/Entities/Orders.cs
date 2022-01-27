namespace ProductManagementSystem.Entities
{
    public class Orders
    {
        public int OrderID { get; set; }
        public List<Products> Products { get; set; }
    }
}
