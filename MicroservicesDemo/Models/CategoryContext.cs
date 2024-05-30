using Microsoft.EntityFrameworkCore;

namespace MicroservicesDemo.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {

        }

        public DbSet<CategoryDetails> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryDetails>().HasData(
                new CategoryDetails
                {
                    CategoryId = 1,
                    CategoryName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Categories")["1"]
                },
                new CategoryDetails
                {
                    CategoryId = 2,
                    CategoryName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Categories")["2"]
                }
                );
        }
    }
}
