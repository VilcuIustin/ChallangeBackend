using Common.DTOs.Models;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IProductsRepository
    {
        Task AddProductAsync(CreateProduct product);
        public Task<bool> CheckIfProductExistByNameAsync(string name);
        public Task<bool> CheckProductExistById(Guid productId);
        public Task<List<MinimalProductResponse>> GetProductsPaginated(ProductsPaginatedReques pagination);
    }
}
