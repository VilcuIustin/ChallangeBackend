using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class ProductsPaginatedReques : BasePagination
    {
        [MaxLength(256)]
        public string? Name { get; set; }
    }
}
