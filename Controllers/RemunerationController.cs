using BusinessLayer.Services;
using Common.DTOs;
using Common.DTOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChallangeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemunerationController : ControllerBase
    {

        private readonly IRemunerationService _remunerationService;

        public RemunerationController(IRemunerationService remunerationService)
        {
            _remunerationService = remunerationService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<SalesByProductResponse>>>>
            GetRemunerationByDateAsync([Range(1,12)]int month, [Range(2000,2400)]int year)
            => await _remunerationService.GetRemunerationByDateAsync(month, year);

    }
}
