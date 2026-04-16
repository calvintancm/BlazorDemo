using BlazorDemo.Data;
using BlazorDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Services
{
    public class ProductService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        public ProductService(IDbContextFactory<AppDbContext> factory) => _factory = factory;

        public async Task<List<Product>> GetAllAsync()
        {
            using var db = _factory.CreateDbContext();
            return await db.Products.Include(p => p.Category).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            using var db = _factory.CreateDbContext();
            return await db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateAsync(Product product)
        {
            using var db = _factory.CreateDbContext();
            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            using var db = _factory.CreateDbContext();
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var db = _factory.CreateDbContext();
            var p = await db.Products.FindAsync(id);
            if (p != null) { db.Products.Remove(p); await db.SaveChangesAsync(); }
        }
    }
}