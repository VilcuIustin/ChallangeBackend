using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Models
{
    public class CreateEmployeeSale
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        [Range(0, int.MaxValue)]
        public int ProductsSold { get; set; }
        public int DateId { get; set; }
    }
}
