using Common.DTOs.Requests;
using Common.DTOs.Responses;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    internal class EmployeesRepository : BaseRepository, IEmployeesRepository
    {
        public EmployeesRepository(SqlTransaction transaction) : base(transaction)
        {
        }

        public async Task<List<MinimalEmployeeDetails>> GetEmployeesPaginatedAsync(EmployeesPagination pagination)
            => (await _connection.QueryAsync<MinimalEmployeeDetails>(StoredProcedures.GetActiveEmployees, pagination,
                transaction: _transaction, commandType: CommandType.StoredProcedure))
            .ToList();
    }
}
