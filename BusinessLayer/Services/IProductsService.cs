using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
