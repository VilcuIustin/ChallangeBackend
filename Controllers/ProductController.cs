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
    public class ProductController : ControllerBase
    {

        private readonly IProductsService _productsService;
        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<bool>>> CreateProductAsync(CreateProductRequest productDetails)
            => await _productsService.CreateProductAsync(productDetails);

        [HttpPost("paginated")]
        public async Task<ActionResult<BaseResponse<List<MinimalProductResponse>>>> GetProductsPaginatedAsync(ProductsPaginatedReques pagination)
            => await _productsService.GetProductsPaginatedAsync(pagination);

        [HttpGet("all")]
        public async Task<ActionResult<BaseResponse<List<MinimalProductResponse>>>> GetAllProductsAsync()
            => await GetProductsPaginatedAsync(new ProductsPaginatedReques { Size = int.MaxValue });
    }
}
