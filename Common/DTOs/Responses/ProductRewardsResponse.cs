using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Responses
{
    public class ProductRewardsResponse
    {
        public Guid Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Reward { get; set; }
    }
}
