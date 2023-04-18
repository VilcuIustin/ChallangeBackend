using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;

namespace BusinessLayer.Services
{
    public interface IEmployeesService
    {
        public Task<BaseResponse<List<MinimalEmployeeDetails>>> GetEmployeesPaginatedAsync(EmployeesPagination pagination);
    }
}
