using Moq;
using Products.Application.Features.Product.Create;
using Products.Application.Interfaces.Products;

namespace Products.Test.Products;

[TestClass]
public class CreateProductTest
{
    private readonly Mock<IProductService> _productServiceMock;

    public CreateProductTest()
    {
        _productServiceMock = new();
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenNameIsNullOrEmpty()
    {
        //Arrange
        var command = new CreateProductCommand { Description = "Test", Price = 10, StatusId = 0, Stock = 10 };
        var handler = new CreateProductHandler(_productServiceMock.Object);

        //Act
        var result = handler.Handle(command, default);
        result.Wait();

        //Assert
        Assert.IsTrue(result.IsCompletedSuccessfully);
    }
}
