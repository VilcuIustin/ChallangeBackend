using BusinessLayer.Services;
using ChallangeBackend.Attributes;
using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallangeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [AllowRole(RoleType.Admin | RoleType.Manager)]
    public class ProductRewardController : BaseController
    {
        private readonly IProductRewardService _productReward;
        public ProductRewardController(IProductRewardService productReward)
        {
            _productReward = productReward;
        }

        [HttpPost]
        public async Task<BaseResponse<bool>> CreateProductRewardAsync(CreateProductRewardRequest reward)
            => SetStatusCode(await _productReward.CreateProductRewardAsync(reward));

        [HttpGet]
        public async Task<BaseResponse<List<ProductRewardsResponse>>> GetProductRewardsAsync([FromQuery]Guid productId)
            => SetStatusCode(await _productReward.GetProductRewardsAsync(productId));

        [HttpPatch]
        public async Task<BaseResponse<bool>> UpdateProductRewardAsync(CreateProductRewardRequest reward)
            => SetStatusCode(await _productReward.UpdateProductRewardAsync(reward));
    }
}
