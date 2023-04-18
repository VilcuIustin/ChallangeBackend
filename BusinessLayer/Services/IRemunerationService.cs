using Common.DTOs;
using Common.DTOs.Responses;

namespace BusinessLayer.Services
{
    public interface IRemunerationService
    {
        public Task<BaseResponse<List<SalesByProductResponse>>> GetRemunerationByDateAsync(int month, int year);
    }
}
