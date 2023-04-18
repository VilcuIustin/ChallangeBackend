using Common.DTOs.Requests;
using Common.DTOs.Responses;
using Dapper;
using System.Data;
using System.Data.SqlClient;

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
