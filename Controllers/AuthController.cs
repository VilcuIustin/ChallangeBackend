using BusinessLayer.Services;
using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChallangeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public string generateHash()
        {
            return BCrypt.Net.BCrypt.HashPassword("123456789");
        }

        [HttpPost("login")]
        public async Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest loginData = default!)
            => SetStatusCode(await _userService.LoginAsync(loginData));

        [HttpPost("enroll")] // TODO: This endpoint should be used by admins or managers
        [Authorize]
        public async Task<BaseResponse<bool>> EnrollAsync(RegisterRequest registerData = default!)
            => SetStatusCode(await _userService.EnrollAsync(registerData));

    }
}
