using Common.DTOs.Models;
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
using System.Xml.Linq;

namespace DataLayer.Repositories
{
    public class ProductsRepository : BaseRepository, IProductsRepository
    {
        public ProductsRepository(SqlTransaction transaction) : base(transaction)
        {
        }

        public Task AddProductAsync(CreateProduct product)
         => _connection.ExecuteAsync(StoredProcedures.AddProduct,
                product, transaction: _transaction, commandType: CommandType.StoredProcedure);

        public Task<bool> CheckIfProductExistByNameAsync(string name)
            => _connection.QueryFirstOrDefaultAsync<bool>(StoredProcedures.CheckIfProductExistByName,
                new { Name = name }, transaction: _transaction, commandType: CommandType.StoredProcedure);

        public Task<bool> CheckProductExistById(Guid productId)
       => _connection.QueryFirstOrDefaultAsync<bool>(StoredProcedures.CheckIfProductExistById,
                new { Id = productId }, transaction: _transaction, commandType: CommandType.StoredProcedure);


        public async Task<List<MinimalProductResponse>> GetProductsPaginated(ProductsPaginatedReques pagination)
         => (await _connection.QueryAsync<MinimalProductResponse>(StoredProcedures.GetProductsPaginated,
                pagination, transaction: _transaction, commandType: CommandType.StoredProcedure)).ToList();
    }
}
