using ProductManagementSystem.DBContext;

namespace ProductManagementSystem.Services
{
    public interface IService
    {
        List<Product>? GetProductsOfCategoryAndDescendants(int categoryID);
        Entities.OrderStatistics GetOrderStatistics(List<Entities.Orders> orders);
    }
}
