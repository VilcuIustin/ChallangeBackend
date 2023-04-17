using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IEmployeesService
    {
        public Task<BaseResponse<List<MinimalEmployeeDetails>>> GetEmployeesPaginatedAsync(EmployeesPagination pagination);
    }
}
