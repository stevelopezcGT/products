using Moq;
using Products.Application.Features.Product.Create;
using Products.Application.Interfaces.Products;
using Products.Application.Interfaces.Statuses;

namespace Products.Test.Products.CreateProduct;

[TestClass]
public class CreateProductHandleTest : IDisposable
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly Mock<IStatusService> _statusServiceMock;

    public CreateProductHandleTest()
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
        var command = CreateCommandHelper.createProductCommand;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);
        _productServiceMock.Setup(setup => setup.Add(command)).ReturnsAsync(5);
        var handler = new CreateProductHandler(_productServiceMock.Object);

        //Act
        var result = handler.Handle(command, default);
        result.Wait();

        //Assert
        Assert.IsTrue(result.Result.IsSuccess);
    }
}
