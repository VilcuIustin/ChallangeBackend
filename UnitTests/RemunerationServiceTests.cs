namespace UnitTests
{
    public class RemunerationServiceTests
    {
        private readonly IRemunerationService _sut;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public RemunerationServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new RemunerationService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetRemunerationByDateAsync_ReturnRemuneration()
        {
            var month = 1;
            var year = 2023;

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(month, year))
                .ReturnsAsync(1);
            _unitOfWorkMock.Setup(u => u.RemunerationRepository.GetRemunerationByDateAsync(1))
                .ReturnsAsync(new List<SalesByProductResponse>());

            var response = await _sut.GetRemunerationByDateAsync(month, year);

            Assert.NotNull(response.Content);
            Assert.Null(response.Error);
        }

        [Fact]
        public async Task GetRemunerationByDateAsync_ReturnDateNotFound()
        {
            var month = 1;
            var year = 2023;

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(month, year));

            _unitOfWorkMock.Setup(u => u.RemunerationRepository.GetRemunerationByDateAsync(1))
                .ReturnsAsync(new List<SalesByProductResponse>());

            var response = await _sut.GetRemunerationByDateAsync(month, year);

            Assert.Null(response.Content);
            Assert.Contains("Contact the administrator", response.Error);
        }
    }
}
