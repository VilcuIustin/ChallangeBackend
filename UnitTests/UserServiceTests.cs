using Common.Enums;
using Microsoft.Extensions.Configuration;

namespace UnitTests
{
    public class UserServiceTests
    {

        private readonly IUserService _sut; //system under test
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private readonly Mock<IConfiguration> _configurationMock = new Mock<IConfiguration>();

        public UserServiceTests()
        {
            _sut = new UserService(_unitOfWorkMock.Object, _configurationMock.Object);
            _configurationMock.Setup(c => c["Jwt:Secret"]).Returns("12345678901234567890abcdefg.");
            _configurationMock.Setup(c => c["Jwt:Issuer"]).Returns("Backend");
            _configurationMock.Setup(c => c["Jwt:Audience"]).Returns("Frontend");
        }

        [Fact]
        public async Task EnrollAsync_ShouldReturnTrue()
        {
            var request = new RegisterRequest
            {
                Email = "iustin@mailinator.com",
                FirstName = "Iustin",
                LastName = "Justin",
                Role = RoleType.Employee
            };

            _unitOfWorkMock.Setup(u => u.userRepository.EmailExistsAsync(request.Email))
                .ReturnsAsync(false);
            _unitOfWorkMock.Setup(u => u.RolesRepository.GetRoleIdByName(Enum.GetName(request.Role)))
                .ReturnsAsync(Guid.NewGuid());
            _unitOfWorkMock.Setup(u => u.UserRoleRepository.CreateUserRole(It.IsAny<UserRole>()));

            var response = await _sut.EnrollAsync(request);

            Assert.True(response.Content);
        }

        [Fact]
        public async Task EnrollAsync_ShouldReturnErrorUserExists()
        {
            var request = new RegisterRequest
            {
                Email = "iustin@mailinator.com",
                FirstName = "Iustin",
                LastName = "Justin",
                Role = RoleType.Employee
            };

            _unitOfWorkMock.Setup(u => u.userRepository.EmailExistsAsync(request.Email))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.RolesRepository.GetRoleIdByName(Enum.GetName(request.Role)))
                .ReturnsAsync(Guid.NewGuid());

            _unitOfWorkMock.Setup(u => u.UserRoleRepository.CreateUserRole(It.IsAny<UserRole>()));

            var response = await _sut.EnrollAsync(request);

            Assert.False(response.Content);
            Assert.Contains("User already exist", response.Error);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnTokens()
        {
            var request = new LoginRequest
            {
                Email = "iustin@mailinator.com",
                Password = "password",
            };

            _unitOfWorkMock.Setup(u => u.userRepository.GetUserForLogin(request.Email))
                .ReturnsAsync(new UserDetailsLogin
                {
                    Id = Guid.NewGuid(),
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Roles = new List<RoleDetails>()
                });

            var response = await _sut.LoginAsync(request);

            Assert.Null(response.Error);
            Assert.NotNull(response.Content);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnUserNotFound()
        {
            var request = new LoginRequest
            {
                Email = "iustin@mailinator.com",
                Password = "password",
            };

            _unitOfWorkMock.Setup(u => u.userRepository.GetUserForLogin(request.Email));

            var response = await _sut.LoginAsync(request);

            Assert.NotNull(response.Error);
            Assert.Contains("Email or password invalid", response.Error);
        }


        [Fact]
        public async Task LoginAsync_ShouldReturnUserAccountNotActive()
        {
            var request = new LoginRequest
            {
                Email = "iustin@mailinator.com",
                Password = "password",
            };

            _unitOfWorkMock.Setup(u => u.userRepository.GetUserForLogin(request.Email))
                 .ReturnsAsync(new UserDetailsLogin
                 {
                     Id = Guid.NewGuid(),
                     Email = request.Email,
                     Password = null,
                     Roles = new List<RoleDetails>()
                 });

            var response = await _sut.LoginAsync(request);

            Assert.NotNull(response.Error);
            Assert.Contains("Account is not active", response.Error);
        }


        [Fact]
        public async Task LoginAsync_ShouldReturnUserCredentialInvalide()
        {
            var request = new LoginRequest
            {
                Email = "iustin@mailinator.com",
                Password = "password",
            };

            _unitOfWorkMock.Setup(u => u.userRepository.GetUserForLogin(request.Email))
                 .ReturnsAsync(new UserDetailsLogin
                 {
                     Id = Guid.NewGuid(),
                     Email = request.Email,
                     Password = BCrypt.Net.BCrypt.HashPassword(request.Password + "1"),
                     Roles = new List<RoleDetails>()
                 });

            var response = await _sut.LoginAsync(request);

            Assert.NotNull(response.Error);
            Assert.Contains("Email or password invalid", response.Error);
        }
    }
}
