
using Common.DTOs.Models;
using Common.DTOs.Requests;
using Common.DTOs.Responses;

namespace UnitTests
{
    public class ProductRewardsServiceTests
    {

        private readonly IProductRewardService _sut;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public ProductRewardsServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new ProductRewardService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task CreateProductRewardAsync_ShouldCreateProductReward()
        {
            var request = new CreateProductRewardRequest
            {
                Month = 1,
                Year = 2023,
                ProductId = Guid.NewGuid(),
                Reward = 10
            };

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(request.Month, request.Year))
                .ReturnsAsync(1);

            _unitOfWorkMock.Setup(u => u.ProductsRepository.CheckProductExistById(request.ProductId))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.ProductRewardsExistsByProductIdDateIdAsync(request.ProductId, 1))
                .ReturnsAsync(false);

            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.CreateProductRewardsAsync(It.IsAny<CreateProductReward>()));

            var response = await _sut.CreateProductRewardAsync(request);

            Assert.Null(response.Error);
            Assert.True(response.Content);
        }

        [Fact]
        public async Task CreateProductRewardAsync_ShouldSayDateInvalide()
        {
            var request = new CreateProductRewardRequest
            {
                Month = 1,
                Year = 2023,
                ProductId = Guid.NewGuid(),
                Reward = 10
            };

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(request.Month, request.Year));

            _unitOfWorkMock.Setup(u => u.ProductsRepository.CheckProductExistById(request.ProductId))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.ProductRewardsExistsByProductIdDateIdAsync(request.ProductId, 1))
                .ReturnsAsync(false);

            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.CreateProductRewardsAsync(It.IsAny<CreateProductReward>()));

            var response = await _sut.CreateProductRewardAsync(request);

            Assert.False(response.Content);
            Assert.NotNull(response.Error);
        }

        [Fact]
        public async Task CreateProductRewardAsync_ShouldSayProductNotFound()
        {
            var request = new CreateProductRewardRequest
            {
                Month = 1,
                Year = 2023,
                ProductId = Guid.NewGuid(),
                Reward = 10
            };

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(request.Month, request.Year))
                 .ReturnsAsync(1);

            _unitOfWorkMock.Setup(u => u.ProductsRepository.CheckProductExistById(request.ProductId))
                .ReturnsAsync(false);

            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.ProductRewardsExistsByProductIdDateIdAsync(request.ProductId, 1))
                .ReturnsAsync(false);

            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.CreateProductRewardsAsync(It.IsAny<CreateProductReward>()));

            var response = await _sut.CreateProductRewardAsync(request);

            Assert.False(response.Content);
            Assert.NotNull(response.Error);
        }

        [Fact]
        public async Task CreateProductRewardAsync_ShouldSayProductRewardExists()
        {
            var request = new CreateProductRewardRequest
            {
                Month = 1,
                Year = 2023,
                ProductId = Guid.NewGuid(),
                Reward = 10
            };

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(request.Month, request.Year))
                 .ReturnsAsync(1);

            _unitOfWorkMock.Setup(u => u.ProductsRepository.CheckProductExistById(request.ProductId))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.ProductRewardsExistsByProductIdDateIdAsync(request.ProductId, 1))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.CreateProductRewardsAsync(It.IsAny<CreateProductReward>()));

            var response = await _sut.CreateProductRewardAsync(request);

            Assert.False(response.Content);
            Assert.NotNull(response.Error);
        }

        [Fact]
        public async Task UpdateProductRewardAsync_ShouldUpdateProductReward()
        {
            var request = new CreateProductRewardRequest
            {
                Id = Guid.NewGuid(),
                Month = 1,
                Year = 2023,
                Reward = 10
            };

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(request.Month, request.Year))
                .ReturnsAsync(1);

            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.ProductRewardsExistsByIdAsync(request.Id))
                .ReturnsAsync(true);

            var response = await _sut.UpdateProductRewardAsync(request);

            Assert.Null(response.Error);
            Assert.True(response.Content);
        }

        [Fact]
        public async Task UpdateProductRewardAsync_ShouldReturnDateInvalide()
        {
            var request = new CreateProductRewardRequest
            {
                Id = Guid.NewGuid(),
                Month = 1,
                Year = 2023,
                Reward = 10
            };

            _unitOfWorkMock.Setup(u => u.DateRepository.GetDateIdByMonthAndYear(request.Month, request.Year));

            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.ProductRewardsExistsByIdAsync(request.Id))
                .ReturnsAsync(true);

            var response = await _sut.UpdateProductRewardAsync(request);

            Assert.NotNull(response.Error);
            Assert.False(response.Content);
        }

        [Fact]
        public async Task GetProductRewardsAsync_ShouldGetRewards()
        {
            var productId = Guid.NewGuid();
            var now = DateTime.UtcNow;
            _unitOfWorkMock.Setup(u => u.ProductRewardsRepository.GetProductRewardsAsync(productId, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new Dictionary<(int, int), ProductRewardsResponse>
                {
                    { (now.Month, now.Year), 
                        new ()
                        {
                            Reward = 50,
                            Id = Guid.NewGuid(),
                            Month = now.Month,
                            Year = now.Year
                        }
                    }
                });

            var response = await _sut.GetProductRewardsAsync(productId);

            Assert.NotNull(response.Content);
            Assert.Null(response.Error);
            Assert.True(response.Content?.Any(c => c.Year == now.Year && c.Month == now.Month));
        }
    }
}
