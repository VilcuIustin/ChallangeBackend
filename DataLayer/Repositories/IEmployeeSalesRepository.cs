using Common.DTOs.Models;
using Common.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IEmployeeSalesRepository
    {
        public Task CreateEmployeeSales(CreateEmployeeSale employeeSales);
        Task<List<EmployeeSaleResponse>> GetEmployeesSalesByDateAsync(Guid employeeId, int dateId);
        Task<bool> GetEmployeesSalesByIdAsync(Guid id);
        Task UpdateEmployeeSalesAsync(Guid id, int productsSold);
    }
}
