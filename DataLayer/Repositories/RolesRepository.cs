using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class RolesRepository : BaseRepository, IRolesRepository
    {
        public RolesRepository(SqlTransaction transaction) : base(transaction) { }
        public Task<Guid> GetRoleIdByName(string role)
            => _connection.QueryFirstAsync<Guid>(StoredProcedures.GetRoleIdByName, new { name= role }, transaction: _transaction, commandType: System.Data.CommandType.StoredProcedure);
    }
}
