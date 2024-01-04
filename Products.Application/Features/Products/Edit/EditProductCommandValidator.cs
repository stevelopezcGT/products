using FluentValidation;
using Products.Application.Features.Product.Edit;
using Products.Application.Interfaces.Products;
using Products.Application.Interfaces.Statuses;

namespace Products.Application.Features.Products.Edit;
public sealed class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator(IStatusService _statusService, IProductService productService)
    {
        RuleFor(c => c.Id).MustAsync(async (product, _) =>
        {
            return await productService.ExistsAsync(product);
        }).WithMessage("Product does not Exists").WithErrorCode("404");

        RuleFor(c => c.Name).NotNull().NotEmpty().WithMessage("Invalid Name").WithErrorCode("400");
        RuleFor(c => c.StatusId).Must((status, _) =>
        {
            return _statusService.Exists(status.StatusId);
        }).WithMessage("Invalid Status").WithErrorCode("404");
        RuleFor(c => c.Stock).GreaterThan(0).WithMessage("Invalid Stock").WithErrorCode("400");
        RuleFor(c => c.Description).NotNull().NotEmpty().WithMessage("Invalid Description").WithErrorCode("400");
        RuleFor(c => c.Price).GreaterThan(0).WithMessage("Invalid Price").WithErrorCode("400");
    }
}
