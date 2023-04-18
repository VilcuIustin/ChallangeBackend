namespace Common.DTOs.Responses
{
    public class EmployeeRemunerationResponse
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = default!;
        public int Remuneration { get; set; }
    }
}
