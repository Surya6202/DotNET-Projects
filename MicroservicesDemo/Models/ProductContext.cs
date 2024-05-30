using Microsoft.EntityFrameworkCore;

namespace MicroservicesDemo.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<ProductDetails> Products { get; set; }
    }
}
