namespace ProductManagementSystem.DBContext
{
    public interface IOrderDataAccess
    {
        public List<Order>? GetAllOrder();

        public void SaveOrder(Order order);
    }
}
