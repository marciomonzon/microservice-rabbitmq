using Microsoft.EntityFrameworkCore;

namespace EDA_Inventory.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }

        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
