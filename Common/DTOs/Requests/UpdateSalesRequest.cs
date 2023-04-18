using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Requests
{
    public class UpdateSalesRequest
    {
        public Guid Id { get; set; }
        [Range(0, int.MaxValue)]
        public int ProductsSold { get; set; }
    }
}
