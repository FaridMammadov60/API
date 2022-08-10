using API.Configuration;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DATA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfigurtaion());

            modelBuilder.Entity<Category>().HasData(
              new Category
              {
                  Id = 1,
                  Name = "Computer"
              },
              new Category
              {
                  Id = 2,
                  Name = "Phone"

              },
              new Category
              {
                  Id = 3,
                  Name = "Game"
              },
              new Category
              {
                  Id = 4,
                  Name = "Electronic"
              });

        }
    }
}
