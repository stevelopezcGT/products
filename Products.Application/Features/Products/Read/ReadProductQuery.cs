using MediatR;
using Products.Domain.DTOs;
using Products.Domain.Shared;

namespace Products.Application.Features.Product.Read;

public sealed class ReadProductQuery : IRequest<Result<ProductResponse>>
{
    public int Id { get; set; }
}

