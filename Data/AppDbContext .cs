using BlazorDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Food & Beverage" }
            );

            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop Pro", Price = 2999.99m, Stock = 15, CategoryId = 1, Description = "High-performance laptop" },
                new Product { Id = 2, Name = "T-Shirt", Price = 29.99m, Stock = 100, CategoryId = 2, Description = "100% Cotton" },
                new Product { Id = 3, Name = "Coffee Beans", Price = 19.99m, Stock = 50, CategoryId = 3, Description = "Premium arabica" }
            );
        }
    }
}