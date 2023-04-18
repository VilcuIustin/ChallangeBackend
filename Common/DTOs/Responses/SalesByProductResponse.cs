namespace Common.DTOs.Responses
{
    public class SalesByProductResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public List<EmployeeRemunerationResponse> EmployeesRemuneration { get; set; } = new();
    }
}
