
namespace UnitTests
{
    public class EmployeeSalesTests
    {
        private readonly IEmployeesSalesService _sut;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public EmployeeSalesTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new EmployeesSalesService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task CreateEmployeeSaleAsync_ShouldCreateRecord()
        {
            var request = new CreateEmployeeSalesRequest
            {
                EmployeeId = Guid.NewGuid(),
                Month = 1,
                Year = 2023,
                ProductsSold = 100,
                ProductId = Guid.NewGuid()
            };

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(request.Month, request.Year))
                .ReturnsAsync(1);

            _unitOfWorkMock.Setup(u => u.ProductsRepository.CheckProductExistById(request.ProductId))
                .ReturnsAsync(true);
            _unitOfWorkMock.Setup(u => u.UserRepository.CheckUserExistByIdAsync(request.EmployeeId))
                .ReturnsAsync(true);
            _unitOfWorkMock.Setup(u => u.EmployeeSalesRepository.CreateEmployeeSales(It.IsAny<CreateEmployeeSale>()));

            var response = await _sut.CreateEmployeeSaleAsync(request);

            Assert.True(response.Content);
            Assert.Null(response.Error);
        }

        [Fact]
        public async Task CreateEmployeeSaleAsync_ShouldSayDateInvalid()
        {
            var request = new CreateEmployeeSalesRequest
            {
                EmployeeId = Guid.NewGuid(),
                Month = 1,
                Year = 2023,
                ProductsSold = 100,
                ProductId = Guid.NewGuid()
            };

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(request.Month, request.Year));

            _unitOfWorkMock.Setup(u => u.ProductsRepository.CheckProductExistById(request.ProductId))
                .ReturnsAsync(true);
            _unitOfWorkMock.Setup(u => u.UserRepository.CheckUserExistByIdAsync(request.EmployeeId))
                .ReturnsAsync(true);
            _unitOfWorkMock.Setup(u => u.EmployeeSalesRepository.CreateEmployeeSales(It.IsAny<CreateEmployeeSale>()));

            var response = await _sut.CreateEmployeeSaleAsync(request);

            Assert.False(response.Content);
            Assert.Contains("Contact the administrator", response.Error);
        }

        [Fact]
        public async Task CreateEmployeeSaleAsync_ShouldSayProductNotFound()
        {
            var request = new CreateEmployeeSalesRequest
            {
                EmployeeId = Guid.NewGuid(),
                Month = 1,
                Year = 2023,
                ProductsSold = 100,
                ProductId = Guid.NewGuid()
            };

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(request.Month, request.Year))
                .ReturnsAsync(1);

            _unitOfWorkMock.Setup(u => u.ProductsRepository.CheckProductExistById(request.ProductId))
                .ReturnsAsync(false);
            _unitOfWorkMock.Setup(u => u.UserRepository.CheckUserExistByIdAsync(request.EmployeeId))
                .ReturnsAsync(true);
            _unitOfWorkMock.Setup(u => u.EmployeeSalesRepository.CreateEmployeeSales(It.IsAny<CreateEmployeeSale>()));

            var response = await _sut.CreateEmployeeSaleAsync(request);

            Assert.False(response.Content);
            Assert.Contains("Product does not exist", response.Error);
        }

        [Fact]
        public async Task CreateEmployeeSaleAsync_ReturnUserNotFound()
        {
            var request = new CreateEmployeeSalesRequest
            {
                EmployeeId = Guid.NewGuid(),
                Month = 1,
                Year = 2023,
                ProductsSold = 100,
                ProductId = Guid.NewGuid()
            };

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(request.Month, request.Year))
                .ReturnsAsync(1);

            _unitOfWorkMock.Setup(u => u.ProductsRepository.CheckProductExistById(request.ProductId))
                .ReturnsAsync(true);
            _unitOfWorkMock.Setup(u => u.UserRepository.CheckUserExistByIdAsync(request.EmployeeId))
                .ReturnsAsync(false);
            _unitOfWorkMock.Setup(u => u.EmployeeSalesRepository.CreateEmployeeSales(It.IsAny<CreateEmployeeSale>()));

            var response = await _sut.CreateEmployeeSaleAsync(request);

            Assert.False(response.Content);
            Assert.Contains("Employee does not exist", response.Error);
        }

        [Fact]
        public async Task GetEmployeesSalesByDateAsync_ReturnSales()
        {
            var employeeId = Guid.NewGuid();
            var month = 1;
            var year = 2023;

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(month, year))
                .ReturnsAsync(1);

            _unitOfWorkMock.Setup(u => u.EmployeeSalesRepository.GetEmployeesSalesByDateAsync(employeeId, 1))
                .ReturnsAsync(new List<EmployeeSaleResponse>()
                {
                    new EmployeeSaleResponse()
                    {
                        Id = Guid.NewGuid(),
                        ProductName = "product 1",
                        ProductsSold = 100
                    }
                });

            var response = await _sut.GetEmployeesSalesByDateAsync(employeeId, month, year);

            Assert.Null(response.Error);
            Assert.NotNull(response.Content);
            Assert.True(response.Content?.Any(c => c.ProductName == "product 1"));

        }

        [Fact]
        public async Task GetEmployeesSalesByDateAsync_ReturnInvalideDate()
        {
            var employeeId = Guid.NewGuid();
            var month = 1;
            var year = 2023;

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(month, year));

            _unitOfWorkMock.Setup(u => u.EmployeeSalesRepository.GetEmployeesSalesByDateAsync(employeeId, 1))
                .ReturnsAsync(new List<EmployeeSaleResponse>()
                {
                    new EmployeeSaleResponse()
                    {
                        Id = Guid.NewGuid(),
                        ProductName = "product 1",
                        ProductsSold = 100
                    }
                });

            var response = await _sut.GetEmployeesSalesByDateAsync(employeeId, month, year);


            Assert.Null(response.Content);
            Assert.Contains("Date not found", response.Error);

        }

        [Fact]
        public async Task UpdateEmployeesSalesAsync_ReturnSalesUpdated()
        {
            var request = new UpdateEmployeeSalesRequest
            {
                Id = Guid.NewGuid(),
                ProductsSold = 50
            };

            _unitOfWorkMock.Setup(u => u.EmployeeSalesRepository.GetEmployeesSalesByIdAsync(request.Id))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.EmployeeSalesRepository.UpdateEmployeeSalesAsync(request.Id, request.ProductsSold));

            var result = await _sut.UpdateEmployeesSalesAsync(request);

            Assert.True(result.Content);
            Assert.Null(result.Error);
        }

        [Fact]
        public async Task UpdateEmployeesSalesAsync_ReturnSaleNotFound()
        {
            var request = new UpdateEmployeeSalesRequest
            {
                Id = Guid.NewGuid(),
                ProductsSold = 50
            };

            _unitOfWorkMock.Setup(u => u.EmployeeSalesRepository.GetEmployeesSalesByIdAsync(request.Id))
                .ReturnsAsync(false);

            _unitOfWorkMock.Setup(u => u.EmployeeSalesRepository.UpdateEmployeeSalesAsync(request.Id, request.ProductsSold));

            var result = await _sut.UpdateEmployeesSalesAsync(request);

            Assert.False(result.Content);
            Assert.NotNull(result.Error);
            Assert.Contains("Sale does not exist", result.Error);
        }

    }
}
