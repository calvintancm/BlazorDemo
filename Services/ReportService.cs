using BlazorDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Services
{
    public class ReportSummary
    {
        public string Category { get; set; } = "";
        public int ProductCount { get; set; }
        public int TotalStock { get; set; }
        public decimal TotalValue { get; set; }
    }

    public class ReportService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        public ReportService(IDbContextFactory<AppDbContext> factory) => _factory = factory;

        public async Task<List<ReportSummary>> GetCategoryReportAsync()
        {
            using var db = _factory.CreateDbContext();
            return await db.Products
                .Include(p => p.Category)
                .GroupBy(p => p.Category!.Name)
                .Select(g => new ReportSummary
                {
                    Category = g.Key,
                    ProductCount = g.Count(),
                    TotalStock = g.Sum(p => p.Stock),
                    TotalValue = g.Sum(p => p.Price * p.Stock)
                })
                .ToListAsync();
        }
    }
}