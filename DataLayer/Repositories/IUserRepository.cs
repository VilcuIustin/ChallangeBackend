using Common.DTOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
