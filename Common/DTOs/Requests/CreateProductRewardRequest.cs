﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class CreateProductRewardRequest
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        [Range(0, int.MaxValue)]
        public int Reward { get; set; }
        [Range(1, 12)]
        public int Month { get; set; }
        [Range(2000, 2400)]
        public int Year { get; set; }
    }
}
