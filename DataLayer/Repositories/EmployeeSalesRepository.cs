using Common.DTOs.Models;
using Common.DTOs.Responses;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.Repositories
{
    public class EmployeeSalesRepository : BaseRepository, IEmployeeSalesRepository
    {
        public EmployeeSalesRepository(SqlTransaction transaction) : base(transaction)
        {
        }

        public Task CreateEmployeeSales(CreateEmployeeSale employeeSales)
            => _connection.ExecuteAsync(StoredProcedures.AddEmployeeSales, employeeSales,
                transaction: _transaction, commandType: CommandType.StoredProcedure);

        public async Task<List<EmployeeSaleResponse>> GetEmployeesSalesByDateAsync(Guid employeeId, int dateId)
         => (await _connection.QueryAsync<EmployeeSaleResponse>(StoredProcedures.GetEmployeesSalesByDate,
                new { employeeId, dateId }, transaction: _transaction, commandType: CommandType.StoredProcedure))
            .ToList();

        public Task<bool> GetEmployeesSalesByIdAsync(Guid id)
        => _connection.QueryFirstOrDefaultAsync<bool>(StoredProcedures.GetEmployeesSalesById, new { id },
                transaction: _transaction, commandType: CommandType.StoredProcedure);

        public Task UpdateEmployeeSalesAsync(Guid id, int productsSold)
        => _connection.ExecuteAsync(StoredProcedures.UpdateEmployeesSales, new { id, productsSold },
                transaction: _transaction, commandType: CommandType.StoredProcedure);
    }
}
