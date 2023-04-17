using Common.DTOs.Models;
using Dapper;
using System.Data.SqlClient;

namespace DataLayer.Repositories
{
    public class UserRoleRepository : BaseRepository, IUserRoleRepository
    {
        public UserRoleRepository(SqlTransaction transaction) : base(transaction)
        {
        }

        public Task CreateUserRole(UserRole userRole)
            => _connection.ExecuteAsync(StoredProcedures.CreateUserRole, userRole, transaction: _transaction, commandType: System.Data.CommandType.StoredProcedure);
    }
}