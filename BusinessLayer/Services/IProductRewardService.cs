using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
