namespace Common.DTOs.Models
{
    public class CreateProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

    }
}
