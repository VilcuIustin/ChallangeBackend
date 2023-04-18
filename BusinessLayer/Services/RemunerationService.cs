using Common.DTOs;
using Common.DTOs.Responses;
using DataLayer;

namespace BusinessLayer.Services
{
    public class RemunerationService : IRemunerationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemunerationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<List<SalesByProductResponse>>> GetRemunerationByDateAsync(int month, int year)
        {
            try
            {
                var dateId = await _unitOfWork.DateRepository.GetDateIdByMonthAndYear(month, year);

                if (dateId == null)
                {
                    return new()
                    {
                        Error = "Contact the administrator"
                    };
                }

                return new(await _unitOfWork.RemunerationRepository.GetRemunerationByDateAsync(dateId.Value));
            }
            catch (Exception ex)
            {
                return new()
                {
                    Error = "Something went wrong"
                };
            }
        }
    }
}
