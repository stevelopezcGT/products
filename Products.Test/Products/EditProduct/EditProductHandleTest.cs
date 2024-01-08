using Moq;
using Products.Application.Features.Product.Edit;
using Products.Application.Interfaces.Products;
using Products.Application.Interfaces.Statuses;

namespace Products.Test.Products.EditProduct;

[TestClass]
public class EditProductHandleTest : IDisposable
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly Mock<IStatusService> _statusServiceMock;

    public EditProductHandleTest()
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
        var command = EditProductHelper.editProductCommand;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);
        _productServiceMock.Setup(setup => setup.Update(command)).ReturnsAsync(true);
        var handler = new EditProductHandler(_productServiceMock.Object);

        //Act
        var result = handler.Handle(command, default);
        result.Wait();

        //Assert
        Assert.IsTrue(result.Result.IsSuccess);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult()
    {
        //Arrange
        var command = EditProductHelper.editProductCommand;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);
        _productServiceMock.Setup(setup => setup.Update(command)).ReturnsAsync(false);
        var handler = new EditProductHandler(_productServiceMock.Object);

        //Act
        var result = handler.Handle(command, default);
        result.Wait();

        //Assert
        Assert.IsTrue(result.Result.IsFailure);
    }

    
}
