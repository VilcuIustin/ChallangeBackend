using Common.DTOs;
using Common.DTOs.Models;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using DataLayer;

namespace BusinessLayer.Services
{
    public class EmployeesSalesService : IEmployeesSalesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesSalesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> CreateEmployeeSaleAsync(CreateEmployeeSalesRequest salesData)
        {
            try
            {
                var dateId = await _unitOfWork.DateRepository.GetDateIdByMonthAndYear(salesData.Month, salesData.Year);
                if (dateId == null)
                {
                    return new BaseResponse<bool>
                    {
                        Error = "Contact the administrator"
                    };
                }

                var productExists = await _unitOfWork.ProductsRepository.CheckProductExistById(salesData.ProductId);
                if (!productExists)
                {
                    return new BaseResponse<bool>
                    {
                        Error = "Product does not exist"
                    };
                }

                var employeeExists = await _unitOfWork.userRepository.CheckUserExistByIdAsync(salesData.EmployeeId);
                if (!employeeExists)
                {
                    return new BaseResponse<bool>
                    {
                        Error = "Employee does not exist"
                    };
                }

                var newEmployeeSale = new CreateEmployeeSale
                {
                    Id = Guid.NewGuid(),
                    UserId = salesData.EmployeeId,
                    DateId = dateId.Value,
                    ProductId = salesData.ProductId,
                    ProductsSold = salesData.ProductsSold,
                };

                await _unitOfWork.EmployeeSalesRepository.CreateEmployeeSales(newEmployeeSale);
                await _unitOfWork.SaveChangesAsync();

                return new(true);

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return new()
                {
                    Error = "Something went wrong"
                };
            }
        }

        public async Task<BaseResponse<List<EmployeeSaleResponse>>> GetEmployeesSalesByDateAsync(Guid employeeId, int month, int year)
        {
            try
            {
                var dateId = await _unitOfWork.DateRepository.GetDateIdByMonthAndYear(month, year);
                if (dateId is null)
                    return new()
                    {
                        Error = "Date not found"
                    };

                var response = await _unitOfWork.EmployeeSalesRepository.GetEmployeesSalesByDateAsync(employeeId, dateId.Value);
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

        public async Task<BaseResponse<bool>> UpdateEmployeesSalesAsync(UpdateEmployeeSalesRequest saleDetails)
        {
            try
            {
                var salesExist = await _unitOfWork.EmployeeSalesRepository.GetEmployeesSalesByIdAsync(saleDetails.Id);

                if (!salesExist)
                    return new()
                    {
                        Error = "Sale does not exist"
                    };

                await _unitOfWork.EmployeeSalesRepository.UpdateEmployeeSalesAsync(saleDetails.Id, saleDetails.ProductsSold);
                await _unitOfWork.SaveChangesAsync();
                return new(true);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return new()
                {
                    Error = "Something went wrong"
                };
            }
        }
    }
}
