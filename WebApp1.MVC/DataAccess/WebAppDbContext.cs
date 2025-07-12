using Microsoft.EntityFrameworkCore;
using WebApp1.MVC.Models;

namespace WebApp1.MVC.DataAccess
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {
            if (MusicDetails.Local.Count == 0 || Users.Local.Count == 0)
            {
                MusicDetails.AddRange(new Music[]
                {
                    new Music { MusicId = 1, MusicName = "Sugar Baby", Author = "AR" },
                    new Music { MusicId = 2, MusicName = "Muthumalai", Author = "AR" },
                    new Music { MusicId = 3, MusicName = "Look into me", Author = "Prasad" }
                });

                Users.AddRange(new User[]
                {
                    new User { UserId = 1, UserName = "Surya", Password = "123" },
                    new User { UserId = 2, UserName = "Vijay", Password = "456" }
                });

                SaveChanges();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>()
                .Property(m => m.PublishedDate)
                .HasColumnType("date");
        }

        public DbSet<Music> MusicDetails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}