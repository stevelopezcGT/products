using MediatR;

namespace Products.Application.Abstractions.Messaging;
public interface ICommandBase
{
}

public interface ICommandBase<TResponse> : IRequest<TResponse>
{
}
