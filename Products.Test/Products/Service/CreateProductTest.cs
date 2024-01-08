using Moq;
using Products.Application.Interfaces.Discounts;
using Products.Application.Interfaces.Products;
using Products.Application.Interfaces.Statuses;
using Products.Application.Services.Products;
using Products.Domain.Entities;
using Products.Domain.Interfaces;
using Products.Test.Products.EditProduct;

namespace Products.Test.Products.CreateProduct;

[TestClass]
public class CreateProductTest : IDisposable
{
    
    private readonly Mock<IStatusService> _statusServiceMock;
    private readonly Mock<IDiscountService> _discountServiceMock;
    private readonly Mock<IProductRepository> _productrepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    private readonly IProductService _productService;

    public CreateProductTest()
    {
        _productrepositoryMock = new();
        _discountServiceMock = new();
        _statusServiceMock = new();
        _unitOfWorkMock = new();
        _productService = new ProductService(_unitOfWorkMock.Object, _productrepositoryMock.Object, _statusServiceMock.Object, _discountServiceMock.Object);
    }

    public void Dispose()
    {
        Mock.VerifyAll();
    }

    [TestMethod]
    public void Service_Add_Should_ReturnSuccessResult()
    {
        //Arrange
        var command = CreateCommandHelper.createProductCommand;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);
        _unitOfWorkMock.Setup(setup => setup.ProductRepository).Returns(_productrepositoryMock.Object);
        _unitOfWorkMock.Setup(setup => setup.SaveChanges()).Returns(1);
        _productrepositoryMock.Setup(setup => setup.Add(It.IsAny<Product>()));

        //Act
        var result = _productService.Add(command);
        result.Wait();

        //Assert
        Assert.IsTrue(result.Result == 0);
    }

    [TestMethod]
    public void Service_Edit_Should_ReturnSuccessResult()
    {
        //Arrange
        var command = EditProductHelper.editProductCommand;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);
        _unitOfWorkMock.Setup(setup => setup.ProductRepository).Returns(_productrepositoryMock.Object);
        _productrepositoryMock.Setup(setup => setup.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(GetProduct);
        _unitOfWorkMock.Setup(setup => setup.SaveChanges()).Returns(1);
        _productrepositoryMock.Setup(setup => setup.Add(It.IsAny<Product>()));

        //Act
        var result = _productService.Update(command);
        result.Wait();

        //Assert
        Assert.IsTrue(result.Result);
    }

    private Product GetProduct() =>
        new Product
        {
            Id = 1,
            Description = "Test",
            Price = 10,
            StatusId = 0,
            Stock = 10,
            Name = "Test"
        };
}
