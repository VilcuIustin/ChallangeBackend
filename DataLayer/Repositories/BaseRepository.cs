using System.Data.SqlClient;

namespace DataLayer.Repositories
{
    public class BaseRepository
    {
        internal readonly SqlConnection _connection;
        internal readonly SqlTransaction _transaction;
        public BaseRepository(SqlTransaction transaction)
        {
            _transaction = transaction;
            _connection = _transaction.Connection;
        }
    }
}
