using Common.DTOs.Models;
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
                new {employeeId, dateId}, transaction: _transaction, commandType: CommandType.StoredProcedure))
            .ToList();

        public Task UpdateEmployeeSales()
        {
            throw new NotImplementedException();
        }
    }
}
