using Common.DTOs.Models;

namespace DataLayer.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> EmailExistsAsync(string email);
        public Task<bool> CheckUserExistByIdAsync(Guid userId);
        public Task<bool> CreateUser(User user);
        public Task<UserDetailsLogin?> GetUserForLogin(string email);
    }
}
