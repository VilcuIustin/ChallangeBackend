using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Models
{
    public class CreateProductReward
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        [Range(0, int.MaxValue)]
        public int Reward { get; set; }
        public int DateId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
