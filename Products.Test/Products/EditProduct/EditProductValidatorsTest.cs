using FluentValidation.TestHelper;
using Moq;
using Products.Application.Features.Products.Edit;
using Products.Application.Interfaces.Products;
using Products.Application.Interfaces.Statuses;
using Products.Test.Products.EditProduct;

namespace Products.Test.Products;

[TestClass]
public class EditProductTestHandle : IDisposable
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly Mock<IStatusService> _statusServiceMock;
    private readonly EditProductCommandValidator _validator;

    public EditProductTestHandle()
    {
        _productServiceMock = new();
        _statusServiceMock = new();
        _validator = new EditProductCommandValidator(_statusServiceMock.Object, _productServiceMock.Object);
    }

    public void Dispose()
    {
        Mock.VerifyAll();
    }

    [TestMethod]
    public void Handler_Should_ReturnSuccesResult_WhenProductExists()
    {
        //Arrange
        var command = EditProductHelper.editProductCommand;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);
        _productServiceMock.Setup(setup => setup.ExistsAsync(command.Id)).ReturnsAsync(true);

        //Act        
        var result = _validator.TestValidateAsync(command);
        result.Wait();

        //Assert
        result.Result.ShouldNotHaveValidationErrorFor(command => command.Id);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenProductIsNotExists()
    {
        //Arrange
        var command = EditProductHelper.editProductCommand;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);
        _productServiceMock.Setup(setup => setup.ExistsAsync(command.Id)).ReturnsAsync(false);

        //Act        
        var result = _validator.TestValidateAsync(command);
        result.Wait();

        //Assert
        result.Result.ShouldHaveValidationErrorFor(command => command.Id);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenNameIsNullOrEmpty()
    {
        //Arrange
        var command = EditProductHelper.editProductCommand;
        command.Name = string.Empty;
        _statusServiceMock.Setup(setup=> setup.Exists(It.IsAny<int>())).Returns(true);

        //Act        
        var result = _validator.TestValidateAsync(command);
        result.Wait();

        //Assert
        result.Result.ShouldHaveValidationErrorFor(command => command.Name);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenDescriptionIsNullOrEmpty()
    {
        //Arrange
        var command = EditProductHelper.editProductCommand;
        command.Description = string.Empty;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);

        //Act        
        var result = _validator.TestValidateAsync(command);
        result.Wait();

        //Assert
        result.Result.ShouldHaveValidationErrorFor(command => command.Description);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenStockIsNullOrEmpty()
    {
        //Arrange
        var command = EditProductHelper.editProductCommand;
        command.Stock = 0;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);

        //Act        
        var result = _validator.TestValidateAsync(command);
        result.Wait();

        //Assert
        result.Result.ShouldHaveValidationErrorFor(command => command.Stock);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenPriceIsNullOrEmpty()
    {
        //Arrange
        var command = EditProductHelper.editProductCommand;
        command.Price = 0;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);

        //Act        
        var result = _validator.TestValidateAsync(command);
        result.Wait();

        //Assert
        result.Result.ShouldHaveValidationErrorFor(command => command.Price);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenStatusIdIsNotValid()
    {
        //Arrange
        var command = EditProductHelper.editProductCommand;
        command.StatusId = 3;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(false);

        //Act        
        var result = _validator.TestValidateAsync(command);
        result.Wait();

        //Assert
        result.Result.ShouldHaveValidationErrorFor(command => command.StatusId);
    }

    [TestMethod]
    public void Handler_Should_ReturnSuccessResult_WhenStatusIdValid()
    {
        //Arrange
        var command = EditProductHelper.editProductCommand;
        command.StatusId = 1;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);
        _productServiceMock.Setup(setup => setup.ExistsAsync(command.Id)).ReturnsAsync(true);

        //Act        
        var result = _validator.TestValidateAsync(command);
        result.Wait();

        //Assert
        result.Result.ShouldNotHaveValidationErrorFor(command => command.StatusId);
    }
}
