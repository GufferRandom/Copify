using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Copify.Dto
{
    public class RegisterDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "The FirstName is Too Small")]
        [MaxLength(30, ErrorMessage = "The FirstName is Too Big")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string UserName{get;set;}=string.Empty;
        [Required]
        [MinLength(4, ErrorMessage = "The LastName is Too Small")]
        [MaxLength(50, ErrorMessage = "The LastName is Too Big")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Gmail{get;set;}=string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber{get;set;}=string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } =string.Empty;
    }
}