using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class UpdateSalesRequest
    {
        public Guid Id { get; set; }
        [Range(0, int.MaxValue)]
        public int ProductsSold { get; set; }
    }
}
