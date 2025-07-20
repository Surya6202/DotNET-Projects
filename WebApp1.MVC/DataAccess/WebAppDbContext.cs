using Microsoft.EntityFrameworkCore;
using System;
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
                    
                    // ✅ Tamil
                    new Music { MusicId = 1, MusicName = "Sugar Baby", Author = "AR", PublishedDate = DateTime.UtcNow.AddDays(-10) },
                    new Music { MusicId = 2, MusicName = "Muthumalai", Author = "AR", PublishedDate = DateTime.UtcNow.AddDays(-30) },

                    // 🌟 Telugu
                    new Music { MusicId = 3, MusicName = "Neela Megham", Author = "DSP", PublishedDate = DateTime.UtcNow.AddDays(-5) },
                    new Music { MusicId = 4, MusicName = "Chilipi Maatallo", Author = "Thaman", PublishedDate = DateTime.UtcNow.AddDays(15) }, // Upcoming

                    // 🌟 Hindi
                    new Music { MusicId = 5, MusicName = "Dil Ki Duniya", Author = "Pritam", PublishedDate = DateTime.UtcNow.AddDays(20) }, // Upcoming
                    new Music { MusicId = 6, MusicName = "Safar", Author = "Amit Trivedi", PublishedDate = DateTime.UtcNow.AddDays(-3) },

                    // 🌟 Kannada
                    new Music { MusicId = 7, MusicName = "Ee Hrudaya", Author = "Ajaneesh Loknath", PublishedDate = DateTime.UtcNow.AddDays(-7) },
                    new Music { MusicId = 8, MusicName = "Neene Neene", Author = "Raghu Dixit", PublishedDate = DateTime.UtcNow.AddDays(10) } // Upcoming
                });

                Users.AddRange(new User[]
                {
                    new User { UserId = 1, UserName = "Surya", Role = "Admin", Password = "123" },
                    new User { UserId = 2, UserName = "Prabhas", Password = "456" }
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