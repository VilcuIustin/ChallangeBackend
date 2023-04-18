using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Requests
{
    public class ProductsPaginatedReques : BasePagination
    {
        [MaxLength(256)]
        public string? Name { get; set; }
    }
}
