using Common.DTOs.Requests;
using Common.DTOs.Responses;

namespace DataLayer.Repositories
{
    public interface IEmployeesRepository
    {
        Task<List<MinimalEmployeeDetails>> GetEmployeesPaginatedAsync(EmployeesPagination pagination);
    }
}
