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
    public class ProductController : BaseController
    {

        private readonly IProductsService _productsService;
        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpPost]
        public async Task<BaseResponse<bool>> CreateProductAsync(CreateProductRequest productDetails)
            => SetStatusCode(await _productsService.CreateProductAsync(productDetails));

        [HttpPost("paginated")]
        public async Task<BaseResponse<List<MinimalProductResponse>>> GetProductsPaginatedAsync(ProductsPaginatedReques pagination)
            => SetStatusCode(await _productsService.GetProductsPaginatedAsync(pagination));

        [HttpGet("all")]
        public async Task<BaseResponse<List<MinimalProductResponse>>> GetAllProductsAsync()
            => SetStatusCode(await GetProductsPaginatedAsync(new ProductsPaginatedReques { Size = int.MaxValue }));
    }
}
