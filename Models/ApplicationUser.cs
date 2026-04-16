using Microsoft.AspNetCore.Identity;

namespace BlazorDemo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}