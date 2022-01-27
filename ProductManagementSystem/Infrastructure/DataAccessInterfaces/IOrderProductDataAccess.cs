namespace ProductManagementSystem.DBContext
{
    public interface IOrderProductDataAccess
    {
        public List<OrderProduct>? GetAllOrderProduct();
        public decimal GetPriceByOrderAndProductId(int orderID, int productID);
        public void SaveOrderProduct(OrderProduct orderProduct);
    }
}
