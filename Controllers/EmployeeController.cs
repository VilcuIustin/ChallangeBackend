using BusinessLayer.Services;
using ChallangeBackend.Attributes;
using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using Common.Enums;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallangeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [AllowRole(RoleType.Admin | RoleType.Manager)]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeesService _employeesService;
        public EmployeeController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpPost("paginated")]
        public async Task<BaseResponse<List<MinimalEmployeeDetails>>> GetEmployeesPaginatedAsync(EmployeesPagination pagination)
            => SetStatusCode(await _employeesService.GetEmployeesPaginatedAsync(pagination));
    }
}
