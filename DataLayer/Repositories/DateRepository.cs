using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
