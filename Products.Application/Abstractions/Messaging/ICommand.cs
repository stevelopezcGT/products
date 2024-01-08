using MediatR;
using Products.Domain.Shared;

namespace Products.Application.Abstractions.Messaging;
public interface ICommand : IRequest<Result>, ICommandBase
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, ICommandBase
{
}