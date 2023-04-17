using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Responses
{
    public class SalesByProductResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public List<EmployeeRemunerationResponse> EmployeesRemuneration { get; set; } = new();
    }
}
