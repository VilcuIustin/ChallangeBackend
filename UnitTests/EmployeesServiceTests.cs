using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class EmployeesServiceTests
    {
        private readonly IEmployeesService _sut;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public EmployeesServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new EmployeesService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetEmployeesPaginatedAsync_ReturnEmployees()
        {
            var request = new EmployeesPagination();

            _unitOfWorkMock.Setup(u => u.EmployeesRepository.GetEmployeesPaginatedAsync(request))
                .ReturnsAsync(new List<MinimalEmployeeDetails>());

            var response = await _sut.GetEmployeesPaginatedAsync(request);
            
            Assert.NotNull(response.Content);
            Assert.Null(response.Error);

        }

    }
}
