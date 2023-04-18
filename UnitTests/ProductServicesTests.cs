namespace UnitTests
{
    public class ProductServicesTests
    {

        private readonly IProductsService _sut;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        public ProductServicesTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new ProductsService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task CreateProductAsync_ShouldCreateProduct()
        {
            var request = new CreateProductRequest
            {
                Name = "test"
            };

            _unitOfWorkMock.Setup(u => u.ProductsRepository.CheckIfProductExistByNameAsync(request.Name))
                .ReturnsAsync(false);

            _unitOfWorkMock.Setup(u => u.ProductsRepository.AddProductAsync(It.IsAny<CreateProduct>()));

            var response = await _sut.CreateProductAsync(request);

            Assert.Null(response.Error);
            Assert.True(response.Content);

        }

        [Fact]
        public async Task CreateProductAsync_ShouldShowProductExist()
        {
            var request = new CreateProductRequest
            {
                Name = "test"
            };

            _unitOfWorkMock.Setup(u => u.ProductsRepository.CheckIfProductExistByNameAsync(request.Name))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.ProductsRepository.AddProductAsync(It.IsAny<CreateProduct>()));

            var response = await _sut.CreateProductAsync(request);

            Assert.NotNull(response.Error);
            Assert.Contains("There is already a product with this name", response.Error);

        }

    }
}
