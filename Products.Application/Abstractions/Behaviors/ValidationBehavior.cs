using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Products.Application.Abstractions.Messaging;

namespace Products.Application.Abstractions.Behaviours;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : ICommandBase
{

    private readonly IEnumerable<IValidator<TRequest>> validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> _validators)
    {
        validators = _validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validatorTasks = await Task.WhenAll(
            validators
                .Select(validator => validator.ValidateAsync(context))
            );

        var errors = validatorTasks
            .Where(validatorResult => !validatorResult.IsValid)
            .SelectMany(validatorResult => validatorResult.Errors)
            .Select(validationFailure => new ValidationFailure
            {
                ErrorMessage= validationFailure.ErrorMessage,
                PropertyName = validationFailure.PropertyName,
                ErrorCode = validationFailure.ErrorCode
            })
            .ToList();

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        var response = await next();

        return response;
    }
}
