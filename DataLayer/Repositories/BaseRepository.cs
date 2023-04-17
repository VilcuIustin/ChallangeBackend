using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
