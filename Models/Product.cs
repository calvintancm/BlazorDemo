using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required, Range(0.01, 99999.99)]
        public decimal Price { get; set; }

        [Required, Range(0, 9999)]
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}