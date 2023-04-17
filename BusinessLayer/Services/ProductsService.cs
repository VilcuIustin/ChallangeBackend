using Common.DTOs;
using Common.DTOs.Models;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> CreateProductAsync(CreateProductRequest productDetails)
        {
            try
            {
                productDetails.Name = productDetails.Name.Trim().ToLower();
                var productExists = await _unitOfWork.ProductsRepository
                    .CheckIfProductExistByNameAsync(productDetails.Name);

                if (productExists)
                    return new BaseResponse<bool>
                    {
                        Error = "There is already a product with this name"
                    };

                var product = new CreateProduct
                {
                    Id = Guid.NewGuid(),
                    Name = productDetails.Name,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.ProductsRepository.AddProductAsync(product);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<bool>(true);
            }
            catch(Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return new BaseResponse<bool> { Error = "Something went wrong" };
            }
        }

        public Task GetProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<List<MinimalProductResponse>>> GetProductsPaginatedAsync(ProductsPaginatedReques pagination)
        {
            try
            {
                var response = await _unitOfWork.ProductsRepository.GetProductsPaginated(pagination);
                return new(response);
            }
            catch(Exception ex)
            {
                return new BaseResponse<List<MinimalProductResponse>>
                {
                    Error = "Something went wrong"
                };
            }
        }

        public Task UpdateProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
