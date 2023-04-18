using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Requests
{
    public class LoginRequest
    {
        [MaxLength(320)]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        [MinLength(8)]
        public string Password { get; set; } = default!;
    }
}
