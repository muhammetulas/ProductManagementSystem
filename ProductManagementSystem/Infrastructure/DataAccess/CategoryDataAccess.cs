namespace ProductManagementSystem.DBContext
{
    public class CategoryDataAccess : ICategoryDataAccess
    {
        public List<Category>? GetAllCategories()
        {
            using var context = new ProductManagementSystemDbContext();
            return context.Categories?.ToList();
        }

        public List<Category>? GetSubCategories(int categoryId)
        {
            using var context = new ProductManagementSystemDbContext();
            return context.Categories?.Where(x => x.ParentID == categoryId)?.ToList();
        }

        public void SaveCategory(Category category)
        {
            using var context = new ProductManagementSystemDbContext();
            context.Add<Category>(category);
            context.SaveChanges();
        }
    }
}
