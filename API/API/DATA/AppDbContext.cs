using API.Configuration;
using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.DATA
{
    public class AppDbContext : IdentityDbContext<AppUser>
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
                  Name = "Computer",
                  IsActive = true
              },
              new Category
              {
                  Id = 2,
                  Name = "Phone",
                  IsActive = true

              },
              new Category
              {
                  Id = 3,
                  Name = "Game",
                  IsActive = true
              },
              new Category
              {
                  Id = 4,
                  Name = "Electronic",
                  IsActive = true
              });
            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  Id = 1,
                  Name = "Lenova Thinkpad",
                  CategoryId = 1,
                  Price = 1800,
                  DisCountPrice = 60,
                  IsActive = true

              },
               new Product
               {
                   Id = 2,
                   Name = "Iphone 13 Pro",
                   CategoryId = 2,
                   Price = 2300,
                   DisCountPrice = 40,
                   IsActive = true
               });

        }
    }
}
