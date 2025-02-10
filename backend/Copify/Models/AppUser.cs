using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Copify.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
    }
}
