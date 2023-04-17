using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class EditProductRewardRequest
    {
        public Guid Id { get; set; }
        [Range(0, int.MaxValue)]
        public int Reward { get; set; }
    }
}
