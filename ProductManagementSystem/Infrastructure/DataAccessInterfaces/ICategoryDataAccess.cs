namespace ProductManagementSystem.DBContext
{
    public interface ICategoryDataAccess
    {
        public List<Category>? GetAllCategories();
        List<Category>? GetSubCategories(int categoryId);
        public void SaveCategory(Category category);
    }
}
