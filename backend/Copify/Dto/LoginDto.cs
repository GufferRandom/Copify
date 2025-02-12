using System.ComponentModel.DataAnnotations;
namespace Copify.Dto
{
    public class LoginDto
    {
        [Required]
        public string UserNameOrGmail { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
