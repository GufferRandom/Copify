using System.ComponentModel.DataAnnotations;

namespace Copify.Dto
{
    public class LoginDto
    {
        [Required]
        public string UserNameOrGmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
