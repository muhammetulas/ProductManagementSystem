namespace ProductManagementSystem.DBContext
{
    public class ProductDataAccess: IProductDataAccess
    {
        private readonly ICategoryDataAccess? categoryDataAccess;

        public List<Product>? GetAllProduct()
        {
            using var context = new ProductManagementSystemDbContext();
            return context.Products?.ToList();
        }

        public void SaveProduct(Product order)
        {
            using var context = new ProductManagementSystemDbContext();
            context.Add<Product>(order);
            context.SaveChanges();
        }
    }
}
