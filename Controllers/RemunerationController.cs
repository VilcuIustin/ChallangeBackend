using BusinessLayer.Services;
using ChallangeBackend.Attributes;
using Common.DTOs;
using Common.DTOs.Responses;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChallangeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [AllowRole(RoleType.Admin | RoleType.Manager)]
    public class RemunerationController : BaseController
    {

        private readonly IRemunerationService _remunerationService;

        public RemunerationController(IRemunerationService remunerationService)
        {
            _remunerationService = remunerationService;
        }

        [HttpGet]
        public async Task<BaseResponse<List<SalesByProductResponse>>>
            GetRemunerationByDateAsync([Range(1, 12)] int month, [Range(2000, 2400)] int year)
            => SetStatusCode(await _remunerationService.GetRemunerationByDateAsync(month, year));

    }
}
