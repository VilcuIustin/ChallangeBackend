using Common.DTOs;
using Common.DTOs.Models;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<BaseResponse<bool>> EnrollAsync(RegisterRequest registerData)
        {
            try
            {
                registerData.Email = registerData.Email.Trim().ToLower();
                var userExists = await _unitOfWork.UserRepository.EmailExistsAsync(registerData.Email);
                if (userExists)
                    return new BaseResponse<bool>
                    {
                        Error = "User already exist",
                    };

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = registerData.FirstName,
                    LastName = registerData.LastName,
                    Email = registerData.Email,
                    CreatedAt = DateTime.UtcNow
                };

                var roleId = await _unitOfWork.RolesRepository.GetRoleIdByName(Enum.GetName(registerData.Role));
                var userRole = new UserRole
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    RoleId = roleId,
                };

                await _unitOfWork.UserRepository.CreateUser(user);
                await _unitOfWork.UserRoleRepository.CreateUserRole(userRole);

                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest loginData)
        {
            var userData = await _unitOfWork.UserRepository.GetUserForLogin(loginData.Email);

            if (userData == null)
            {
                return new()
                {
                    Error = "Email or password invalid"
                };
            }

            if (userData.Password == null)
            {
                return new()
                {
                    Error = "Account is not active"
                };
            }

            if (!BCrypt.Net.BCrypt.Verify(loginData.Password, userData.Password))
            {
                return new()
                {
                    Error = "Email or password invalid"
                };
            }

            var response = GenerateTokens(userData);
            return new(response);

        }

        private LoginResponse GenerateTokens(UserDetailsLogin userData)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            var userClaims = new ClaimsIdentity();

            userClaims.AddClaim(new Claim("UserId", userData.Id.ToString()));
            userClaims.AddClaim(new Claim("Email", userData.Email));

            foreach (var role in userData.Roles.Select(ur => ur.RoleName))
                userClaims.AddClaim(new Claim(ClaimTypes.Role, role));


            var tokenDetails = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Subject = userClaims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature),
            };

            var token = jwtTokenHandler.CreateToken(tokenDetails);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            tokenDetails.Expires = DateTime.UtcNow.AddDays(30);

            token = jwtTokenHandler.CreateToken(tokenDetails);
            var refreshToken = jwtTokenHandler.WriteToken(token);


            return new LoginResponse
            {
                AccessToken = jwtToken,
                RefreshToken = refreshToken,
            };
        }
    }
}
