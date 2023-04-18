using Common.DTOs.Models;
using Common.DTOs.Responses;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.Repositories
{
    public class ProductRewardRepository : BaseRepository, IProductRewardsRepository
    {
        public ProductRewardRepository(SqlTransaction transaction) : base(transaction)
        {
        }

        public Task CreateProductRewardsAsync(CreateProductReward productReward)
        => _connection.ExecuteAsync(StoredProcedures.AddProductReward,
                productReward, transaction: _transaction, commandType: CommandType.StoredProcedure);

        public async Task<Dictionary<(int, int), ProductRewardsResponse>> GetProductRewardsAsync(Guid productId, int startMonth, int startYear, int endMonth, int endYear)
       => (await _connection.QueryAsync<ProductRewardsResponse>(StoredProcedures.GetProductRewards,
                new
                {
                    productId = productId,
                    startMonth = startMonth,
                    startYear = startYear,
                    endMonth = endMonth,
                    endYear = endYear
                }, transaction: _transaction, commandType: CommandType.StoredProcedure))
            .ToDictionary(pr => (pr.Year, pr.Month));

        public Task<bool> ProductRewardsExistsByIdAsync(Guid id)
         => _connection.QueryFirstOrDefaultAsync<bool>(StoredProcedures.ProductRewardsExistsById,
                new { id }, transaction: _transaction, commandType: CommandType.StoredProcedure);

        public Task<bool> ProductRewardsExistsByProductIdDateIdAsync(Guid productId, int dateId)
            => _connection.QueryFirstOrDefaultAsync<bool>(StoredProcedures.CheckIfProductRewardExistByNameAndDate,
                new { ProductId = productId, DateId = dateId }, transaction: _transaction, commandType: CommandType.StoredProcedure);

        public Task UpdateRewardAmountAsync(Guid id, int reward)
        => _connection.ExecuteAsync(StoredProcedures.UpdateProductReward,
                new { id, reward }, transaction: _transaction, commandType: CommandType.StoredProcedure);
    }
}
