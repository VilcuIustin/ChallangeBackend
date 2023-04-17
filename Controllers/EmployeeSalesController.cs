using BusinessLayer.Services;
using Common.DTOs.Responses;
using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.DTOs.Requests;

namespace ChallangeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSalesController : ControllerBase
    {
        private readonly IEmployeesSalesService _employeesSalesService;

        public EmployeeSalesController(IEmployeesSalesService employeesSalesService)
        {
            _employeesSalesService = employeesSalesService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<EmployeeSaleResponse>>>> GetEmployeesSalesByDateAsync([FromQuery] Guid employeeId, [FromQuery] int month,[FromQuery] int year)
            => await _employeesSalesService.GetEmployeesSalesByDateAsync(employeeId, month, year);

        [HttpPost]
        public async Task<ActionResult<BaseResponse<bool>>> CreateEmployteeSalesAsync(CreateEmployeeSalesRequest salesData)
            => await _employeesSalesService.CreateEmployeeSaleAsync(salesData);

        [HttpPatch]
        public async Task<ActionResult<BaseResponse<bool>>> UpdateEmployeesSalesAsync(UpdateEmployeeSalesRequest saleDetails)
            => await _employeesSalesService.UpdateEmployeesSalesAsync(saleDetails);
    }
}
