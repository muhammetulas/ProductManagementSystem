namespace ProductManagementSystem.DBContext
{
    public interface IProductDataAccess
    {
        public List<Product>? GetAllProduct();

        public void SaveProduct(Product order);
    }
}
