using MediatR;
using Products.Domain.DTOs;

namespace Products.Application.Features.Product.Queries;

public class GetProduct : IRequest<GetProductResponse>
{
    public int Id { get; set; }
}

