using BusinessLayer.Services;
using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallangeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRewardController : ControllerBase
    {
        private readonly IProductRewardService _productReward;
        public ProductRewardController(IProductRewardService productReward)
        {
            _productReward = productReward;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<bool>>> CreateProductRewardAsync(CreateProductRewardRequest reward)
            => await _productReward.CreateProductRewardAsync(reward);

        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<ProductRewardsResponse>>>> GetProductRewardsAsync([FromQuery]Guid productId)
            => await _productReward.GetProductRewardsAsync(productId);

        [HttpPatch]
        public async Task<ActionResult<BaseResponse<bool>>> UpdateProductRewardAsync(CreateProductRewardRequest reward)
            => await _productReward.UpdateProductRewardAsync(reward);
    }
}
