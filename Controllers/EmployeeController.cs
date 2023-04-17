using BusinessLayer.Services;
using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallangeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        public EmployeeController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<BaseResponse<List<MinimalEmployeeDetails>>>> GetEmployeesPaginatedAsync(EmployeesPagination pagination)
            => await _employeesService.GetEmployeesPaginatedAsync(pagination);
    }
}
