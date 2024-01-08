using Moq;
using Products.Application.Features.Product.Read;
using Products.Application.Interfaces.Products;
using Products.Application.Interfaces.Statuses;

namespace Products.Test.Products.GetProduct;

[TestClass]
public class ReadProductHandleTest : IDisposable
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly Mock<IStatusService> _statusServiceMock;

    public ReadProductHandleTest()
    {
        _productServiceMock = new();
        _statusServiceMock = new();
    }

    public void Dispose()
    {
        Mock.VerifyAll();
    }

    [TestMethod]
    public void Handler_Should_ReturnSuccessResult()
    {
        //Arrange
        var query = ReadProductHelper.createReadProductQuery;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);
        _productServiceMock.Setup(setup => setup.GetProductById(query.Id)).ReturnsAsync(ReadProductHelper.GetProductResponse);
        var handler = new ReadProductHandler(_productServiceMock.Object);

        //Act
        var result = handler.Handle(query, default);
        result.Wait();

        //Assert
        Assert.IsTrue(result.Result.IsSuccess);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult()
    {
        //Arrange
        var query = ReadProductHelper.createReadProductQuery;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);
        var handler = new ReadProductHandler(_productServiceMock.Object);

        //Act
        var result = handler.Handle(query, default);
        result.Wait();

        //Assert
        Assert.IsTrue(result.Result.IsFailure);
    }
}
