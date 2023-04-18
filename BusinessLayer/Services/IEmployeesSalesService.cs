using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;

namespace BusinessLayer.Services
{
    public interface IEmployeesSalesService
    {
        public Task<BaseResponse<bool>> CreateEmployeeSaleAsync(CreateEmployeeSalesRequest salesData);
        public Task<BaseResponse<List<EmployeeSaleResponse>>> GetEmployeesSalesByDateAsync(Guid employeeId, int month, int year);
        Task<BaseResponse<bool>> UpdateEmployeesSalesAsync(UpdateEmployeeSalesRequest saleDetails);
    }
}
