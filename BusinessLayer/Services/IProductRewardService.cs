using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;

namespace BusinessLayer.Services
{
    public interface IProductRewardService
    {
        Task<BaseResponse<bool>> UpdateProductRewardAsync(CreateProductRewardRequest reward);
        public Task<BaseResponse<bool>> CreateProductRewardAsync(CreateProductRewardRequest reward);
        public Task<BaseResponse<bool>> EditProductRewardAsync(EditProductRewardRequest reward);
        public Task<BaseResponse<List<ProductRewardsResponse>>> GetProductRewardsAsync(Guid productId);
    }
}
