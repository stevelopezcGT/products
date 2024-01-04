using FluentValidation;
using Products.Application.Interfaces.Statuses;

namespace Products.Application.Features.Product.Create;
public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator(IStatusService _statusService)
    {
        RuleFor(c => c.Name).NotNull().NotEmpty().WithMessage("Invalid Name");
        RuleFor(c => c.StatusId).Must((status, _) =>
        {
            return _statusService.Exists(status.StatusId);
        }).WithMessage("Invalid Status").WithErrorCode("400");
        RuleFor(c => c.Stock).GreaterThan(0).WithMessage("Invalid Stock").WithErrorCode("400");
        RuleFor(c => c.Description).NotNull().NotEmpty().WithMessage("Invalid Description").WithErrorCode("400");
        RuleFor(c => c.Price).GreaterThan(0).WithMessage("Invalid Price").WithErrorCode("400");
    }
}
