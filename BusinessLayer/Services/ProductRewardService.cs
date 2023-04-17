using Common.DTOs;
using Common.DTOs.Models;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using DataLayer;

namespace BusinessLayer.Services
{
    public class ProductRewardService : IProductRewardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductRewardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> UpdateProductRewardAsync(CreateProductRewardRequest reward)
        {
            try
            {
                var dateId = await _unitOfWork.DateRepository.GetDateIdByMonthAndYear(reward.Month, reward.Year);

                if (dateId == null)
                {
                    return new()
                    {
                        Error = "Contact the administrator"
                    };
                }

                var productExists = await _unitOfWork.ProductRewardsRepository
                    .ProductRewardsExistsByIdAsync(reward.Id);

                if (!productExists)
                    return await CreateProductRewardAsync(reward);

                await _unitOfWork.ProductRewardsRepository.UpdateRewardAmountAsync(reward.Id, reward.Reward);
                await _unitOfWork.SaveChangesAsync();
                return new(true);

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return new()
                {
                    Error = "Something went wrong"
                };
            }
        }

        public async Task<BaseResponse<bool>> CreateProductRewardAsync(CreateProductRewardRequest reward)
        {
            try
            {
                var dateId = await _unitOfWork.DateRepository.GetDateIdByMonthAndYear(reward.Month, reward.Year);
                if (dateId == null)
                {
                    return new()
                    {
                        Error = "Contact the administrator"
                    };
                }

                var productExist = await _unitOfWork.ProductsRepository.CheckProductExistById(reward.ProductId);

                if (!productExist)
                    return new()
                    {
                        Error = "Product does not exist"
                    };

                var existingReward = await _unitOfWork.ProductRewardsRepository
                    .ProductRewardsExistsByProductIdDateIdAsync(reward.ProductId, dateId.Value);

                if (existingReward)
                    return new BaseResponse<bool>
                    {
                        Error = "There is already an reward for this product"
                    };

                var newProduct = new CreateProductReward
                {
                    Id = Guid.NewGuid(),
                    ProductId = reward.ProductId,
                    DateId = dateId.Value,
                    CreatedAt = DateTime.UtcNow,
                    Reward = reward.Reward
                };

                await _unitOfWork.ProductRewardsRepository.CreateProductRewardsAsync(newProduct);
                await _unitOfWork.SaveChangesAsync();
                return new(true);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return new()
                {
                    Error = "Something went wrong"
                };
            }
        }

        public Task<BaseResponse<bool>> EditProductRewardAsync(EditProductRewardRequest reward)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<List<ProductRewardsResponse>>> GetProductRewardsAsync(Guid productId)
        {
            try
            {
                const int numberOfMonths = 5;
                var currentDate = DateTime.UtcNow;
                var currentYear = currentDate.Year;
                var currentMonth = currentDate.Month;

                var startDate = currentDate.AddMonths(-numberOfMonths);

                var endMonth = startDate.AddMonths(numberOfMonths).Month;
                var endYear = startDate.AddMonths(numberOfMonths).Year;

                var response = await _unitOfWork.ProductRewardsRepository.GetProductRewardsAsync(productId, startDate.Month, startDate.Year, endMonth, endYear);
                for (int i = 0; i < numberOfMonths * 2; i++)
                {
                    if (!response.ContainsKey((startDate.Year, startDate.Month)))
                    {
                        response.Add((startDate.Year, startDate.Month), new ProductRewardsResponse
                        {
                            Month = startDate.Month,
                            Year = startDate.Year,
                        });

                    }
                    startDate = startDate.AddMonths(1);
                }
                return new(response.Values
                    .OrderBy(r => r.Year)
                    .ThenBy(r => r.Month)
                    .ToList());
            }
            catch (Exception ex)
            {
                return new()
                {
                    Error = "Something went wrong"
                };
            }
        }
    }
}
