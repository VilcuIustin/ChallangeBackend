using Common.DTOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IUserRoleRepository
    {
        public Task CreateUserRole(UserRole userRole);
    }
}
