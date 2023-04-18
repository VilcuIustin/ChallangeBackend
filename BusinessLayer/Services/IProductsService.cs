using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;

namespace BusinessLayer.Services
{
    public interface IProductsService
    {
        public Task<BaseResponse<bool>> CreateProductAsync(CreateProductRequest productDetails);
        public Task<BaseResponse<List<MinimalProductResponse>>> GetProductsPaginatedAsync(ProductsPaginatedReques pagination);
        public Task GetProductAsync();
        public Task UpdateProductAsync();
    }
}
