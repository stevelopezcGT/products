using MediatR;
using Products.Application.Features.Product.Queries;
using Products.Application.Interfaces;
using Products.Domain.DTOs;

namespace Products.Application.Features.Product.Handlers;
class GetProductHandler : IRequestHandler<GetProduct, GetProductResponse>
{
    private readonly IProductService productService;

    public GetProductHandler(IProductService _productService)
    {
        productService = _productService;
    }

    public async Task<GetProductResponse> Handle(GetProduct requestProduct, CancellationToken cancellationToken)
    {
        return await productService.GetProductById(requestProduct.Id);
    }
}
