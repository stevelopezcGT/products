using MediatR;
using Products.Domain.DTOs;

namespace Products.Application.Features.Product.Read;

public sealed class ReadProductQuery : IRequest<ProductResponse>
{
    public int Id { get; set; }
}

