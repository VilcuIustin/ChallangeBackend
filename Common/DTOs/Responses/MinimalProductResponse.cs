namespace Common.DTOs.Responses
{
    public class MinimalProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
