namespace ProductManagementSystem.DBContext
{
    public class OrderProductDataAccess : IOrderProductDataAccess
    {
        public List<OrderProduct>? GetAllOrderProduct()
        {
            using var context = new ProductManagementSystemDbContext();
            return context.OrderProducts?.ToList();
        }

        public decimal GetPriceByOrderAndProductId(int orderID, int productID)
        {
            using var context = new ProductManagementSystemDbContext();
            return context.OrderProducts.Any(x => x.OrderId == orderID && x.ProductId == productID) ? (decimal)(context.OrderProducts?.First(x => x.OrderId == orderID && x.ProductId == productID).Price) : 0;
        }

        public void SaveOrderProduct(OrderProduct orderProduct)
        {
            using var context = new ProductManagementSystemDbContext();
            context.Add<OrderProduct>(orderProduct);
            context.SaveChanges();
        }
    }
}
