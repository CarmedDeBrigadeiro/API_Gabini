using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }
    }
}
