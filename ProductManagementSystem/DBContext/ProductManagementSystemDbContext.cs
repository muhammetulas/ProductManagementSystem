using Microsoft.EntityFrameworkCore;

namespace ProductManagementSystem.DBContext
{
    public class ProductManagementSystemDbContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderProduct>? OrderProducts{ get; set; }
        public DbSet<Product>? Products { get; set; }

        public ProductManagementSystemDbContext()
        {

        }

        public ProductManagementSystemDbContext(DbContextOptions<ProductManagementSystemDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=DESKTOP-ARTO37F;initial catalog=ProductManagementSystem;integrated security=true;");
        }
    }
}
