using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.Repositories
{
    internal class DateRepository : BaseRepository, IDateRepository
    {
        public DateRepository(SqlTransaction transaction) : base(transaction)
        {
        }

        public Task<int?> GetDateIdByMonthAndYear(int month, int year)
         => _connection.QueryFirstOrDefaultAsync<int?>(StoredProcedures.GetDateIdByMonthAndYear,
                new { Month = month, Year = year }, transaction: _transaction, commandType: CommandType.StoredProcedure);
    }
}
