using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Requests
{
    public class RegisterRequest
    {
        [MaxLength(128)]
        [Required]
        public string FirstName { get; set; } = default!;
        [MaxLength(128)]
        [Required]
        public string LastName { get; set; } = default!;
        [MaxLength(320)]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        [EnumDataType(typeof(RoleType))]
        public RoleType Role { get; set; }
    }
}
