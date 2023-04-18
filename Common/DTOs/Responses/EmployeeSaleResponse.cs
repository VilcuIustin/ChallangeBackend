namespace Common.DTOs.Responses
{
    public class EmployeeSaleResponse
    {
        public Guid Id { get; set; }
        public int ProductsSold { get; set; }
        public string ProductName { get; set; } = default!;
    }
}
