using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class BasePagination
    {
        [Range(0, int.MaxValue)]
        public int Page { get; set; } = 0;
        [Range(5, int.MaxValue)]
        public int Size { get; set; } = 10;
    }
}
