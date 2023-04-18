using Dapper;
using System.Data.SqlClient;

namespace DataLayer.Repositories
{
    public class RolesRepository : BaseRepository, IRolesRepository
    {
        public RolesRepository(SqlTransaction transaction) : base(transaction) { }
        public Task<Guid> GetRoleIdByName(string role)
            => _connection.QueryFirstAsync<Guid>(StoredProcedures.GetRoleIdByName, new { name = role }, transaction: _transaction, commandType: System.Data.CommandType.StoredProcedure);
    }
}
