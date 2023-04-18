namespace Common.DTOs.Models
{
    public class UserDetailsLogin
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<RoleDetails> Roles { get; set; } = new List<RoleDetails>();
    }
}
