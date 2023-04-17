using Common.DTOs.Requests;
using Common.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IEmployeesRepository
    {
        Task<List<MinimalEmployeeDetails>> GetEmployeesPaginatedAsync(EmployeesPagination pagination);
    }
}
