using Common.DTOs.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(SqlTransaction transaction) : base(transaction) { }

        public Task<bool> CheckUserExistByIdAsync(Guid userId)
            => _connection.QueryFirstOrDefaultAsync<bool>(StoredProcedures.CheckIfUserExistsById,
                new
                {
                    userId = userId
                }, transaction: _transaction, commandType: CommandType.StoredProcedure);

        public async Task<bool> CreateUser(User user)
            => (await _connection.ExecuteAsync(StoredProcedures.CreateUser, user, transaction: _transaction, commandType: System.Data.CommandType.StoredProcedure)) == 1;

        public async Task<bool> EmailExistsAsync(string email)
            => (await _connection.QueryAsync<bool>(StoredProcedures.CheckIfEmailExists, new { email = email }, transaction: _transaction, commandType: CommandType.StoredProcedure))
            .FirstOrDefault();

        public async Task<UserDetailsLogin?> GetUserForLogin(string email)
        {
            var response = await _connection.QueryAsync<UserDetailsLogin, RoleDetails, UserDetailsLogin>(
                StoredProcedures.GetUserForLogin,
                (userDetails, roleDetails) =>
                {
                    userDetails.Roles.Add(roleDetails);
                    return userDetails;
                },
                 new { email = email }, splitOn: "id, roleId",
                 transaction: _transaction, commandType: CommandType.StoredProcedure);
            return response?.GroupBy(u => u.Id)
                .Select(u =>
                {
                    var user = u.First();
                    user.Roles = u.SelectMany(us => us.Roles).ToList();
                    return user;
                }).FirstOrDefault();
        }
    }
}
