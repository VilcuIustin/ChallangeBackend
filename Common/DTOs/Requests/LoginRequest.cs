using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
