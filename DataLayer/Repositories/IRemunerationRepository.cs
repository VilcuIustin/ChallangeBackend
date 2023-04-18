using Common.DTOs.Responses;

namespace DataLayer.Repositories
{
    public interface IRemunerationRepository
    {
        public Task<List<SalesByProductResponse>> GetRemunerationByDateAsync(int dateId);
    }
}
