namespace ProductManagementSystem.DBContext
{
    public class OrderDataAccess : IOrderDataAccess
    {
        public List<Order>? GetAllOrder()
        {
            using var context = new ProductManagementSystemDbContext();
            return context.Orders?.ToList();
        }

        public void SaveOrder(Order order)
        {
            using var context = new ProductManagementSystemDbContext();
            context.Add<Order>(order);
            context.SaveChanges();
        }
    }
}
