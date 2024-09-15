using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}
