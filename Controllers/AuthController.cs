using BusinessLayer.Services;
using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ChallangeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<LoginResponse>>> LoginAsync(LoginRequest loginData = default!)
            => await _userService.LoginAsync(loginData);

        [HttpPost("enroll")] // TODO: This endpoint should be used by admins or managers
        public async Task<ActionResult<BaseResponse<bool>>> EnrollAsync(RegisterRequest registerData = default!)
            => await _userService.EnrollAsync(registerData); 

    }
}
