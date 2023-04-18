using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using DataLayer;

namespace BusinessLayer.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<List<MinimalEmployeeDetails>>> GetEmployeesPaginatedAsync(EmployeesPagination pagination)
        {
            try
            {
                var response = await _unitOfWork.EmployeesRepository.GetEmployeesPaginatedAsync(pagination);
                return new(response);
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
