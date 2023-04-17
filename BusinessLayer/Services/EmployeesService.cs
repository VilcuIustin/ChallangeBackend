using Common.DTOs;
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
            catch(Exception ex)
            {
                return new()
                {
                    Error = "Something went wrong"
                };
            }
        }
    }
}
