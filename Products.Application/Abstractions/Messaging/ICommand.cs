using MediatR;

namespace Products.Application.Abstractions.Messaging;
public interface ICommand : IRequest, ICommandBase
{
}

public interface ICommand<TResponse> : IRequest<TResponse>, ICommandBase
{
}