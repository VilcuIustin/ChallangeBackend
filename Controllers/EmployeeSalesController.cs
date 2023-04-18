using BusinessLayer.Services;
using Common.DTOs.Responses;
using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using ChallangeBackend.Attributes;
using Common.Enums;

namespace ChallangeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [AllowRole(RoleType.Admin | RoleType.Manager)]
    public class EmployeeSalesController : BaseController
    {
        private readonly IEmployeesSalesService _employeesSalesService;

        public EmployeeSalesController(IEmployeesSalesService employeesSalesService)
        {
            _employeesSalesService = employeesSalesService;
        }

        [HttpGet]
        public async Task<BaseResponse<List<EmployeeSaleResponse>>> GetEmployeesSalesByDateAsync([FromQuery] Guid employeeId, [FromQuery] int month,[FromQuery] int year)
            => SetStatusCode(await _employeesSalesService.GetEmployeesSalesByDateAsync(employeeId, month, year));

        [HttpPost]
        public async Task<BaseResponse<bool>> CreateEmployteeSalesAsync(CreateEmployeeSalesRequest salesData)
            => SetStatusCode(await _employeesSalesService.CreateEmployeeSaleAsync(salesData));

        [HttpPatch]
        public async Task<BaseResponse<bool>> UpdateEmployeesSalesAsync(UpdateEmployeeSalesRequest saleDetails)
            => SetStatusCode(await _employeesSalesService.UpdateEmployeesSalesAsync(saleDetails));
    }
}
