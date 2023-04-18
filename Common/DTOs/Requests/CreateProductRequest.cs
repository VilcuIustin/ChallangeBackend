using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Requests
{
    public class CreateProductRequest
    {
        [MaxLength(256)]
        public string Name { get; set; } = default!;
    }
}
