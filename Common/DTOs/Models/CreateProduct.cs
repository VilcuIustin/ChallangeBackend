using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Models
{
    public class CreateProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

    }
}
