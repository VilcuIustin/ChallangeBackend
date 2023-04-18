using Common.DTOs.Models;
using Common.DTOs.Responses;

namespace DataLayer.Repositories
{
    public interface IProductRewardsRepository
    {
        public Task<bool> ProductRewardsExistsByProductIdDateIdAsync(Guid productId, int dateId);
        public Task CreateProductRewardsAsync(CreateProductReward productReward);
        public Task<Dictionary<(int, int), ProductRewardsResponse>> GetProductRewardsAsync(Guid productId, int startMonth, int startYear, int endMonth, int endYear);
        public Task<bool> ProductRewardsExistsByIdAsync(Guid id);
        Task UpdateRewardAmountAsync(Guid id, int reward);
    }
}
