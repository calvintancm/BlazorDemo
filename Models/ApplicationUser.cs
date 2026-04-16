using Microsoft.AspNetCore.Identity;

namespace BlazorDemo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string? Department { get; set; }
    }
}