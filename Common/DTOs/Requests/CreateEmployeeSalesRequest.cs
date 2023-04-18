using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Requests
{
    public class CreateEmployeeSalesRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid ProductId { get; set; }
        [Range(0, int.MaxValue)]
        public int ProductsSold { get; set; }
        [Range(1, 12)]
        public int Month { get; set; }
        [Range(2000, 2400)]
        public int Year { get; set; }
    }
}
