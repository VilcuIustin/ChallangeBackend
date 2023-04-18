using Common.DTOs.Models;

namespace DataLayer.Repositories
{
    public interface IUserRoleRepository
    {
        public Task CreateUserRole(UserRole userRole);
    }
}
