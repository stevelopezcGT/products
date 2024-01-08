using FluentValidation.TestHelper;
using Moq;
using Products.Application.Features.Product.Create;
using Products.Application.Interfaces.Products;
using Products.Application.Interfaces.Statuses;

namespace Products.Test.Products.CreateProduct;

[TestClass]
public class CreateProductValidatorsTest
{
    private readonly Mock<IStatusService> _statusServiceMock;
    private readonly CreateProductCommandValidator _validator;

    public CreateProductValidatorsTest()
    {
        _statusServiceMock = new();
        _validator = new CreateProductCommandValidator(_statusServiceMock.Object);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenNameIsNullOrEmpty()
    {
        //Arrange
        var command = CreateCommandHelper.createProductCommand;
        command.Name = string.Empty;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);

        //Act
        var result = _validator.TestValidate(command);

        //Assert
        result.ShouldHaveValidationErrorFor(command => command.Name);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenDescriptionIsNullOrEmpty()
    {
        //Arrange
        var command = CreateCommandHelper.createProductCommand;
        command.Description = string.Empty;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);

        //Act
        var result = _validator.TestValidate(command);

        //Assert
        result.ShouldHaveValidationErrorFor(command => command.Description);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenStockIsNullOrEmpty()
    {
        //Arrange
        var command = CreateCommandHelper.createProductCommand;
        command.Stock = 0;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);

        //Act
        var result = _validator.TestValidate(command);

        //Assert
        result.ShouldHaveValidationErrorFor(command => command.Stock);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenPriceIsNullOrEmpty()
    {
        //Arrange
        var command = CreateCommandHelper.createProductCommand;
        command.Price = 0;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);

        //Act
        var result = _validator.TestValidate(command);

        //Assert
        result.ShouldHaveValidationErrorFor(command => command.Price);
    }

    [TestMethod]
    public void Handler_Should_ReturnFailureResult_WhenStatusIdIsNotValid()
    {
        //Arrange
        var command = CreateCommandHelper.createProductCommand;
        command.StatusId = 3;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(false);

        //Act
        var result = _validator.TestValidate(command);

        //Assert
        result.ShouldHaveValidationErrorFor(command => command.StatusId);
    }

    [TestMethod]
    public void Handler_Should_ReturnSuccessResult_WhenStatusIdValid()
    {
        //Arrange
        var command = CreateCommandHelper.createProductCommand;
        command.StatusId = 1;
        _statusServiceMock.Setup(setup => setup.Exists(It.IsAny<int>())).Returns(true);

        //Act
        var result = _validator.TestValidate(command);

        //Assert
        result.ShouldNotHaveValidationErrorFor(command => command.StatusId);
    }


}
