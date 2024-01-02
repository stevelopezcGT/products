using MediatR;
using Products.Application.Features.Product.Commands;
using Products.Application.Interfaces;
using Products.Domain.DTOs;

namespace Products.Application.Features.Product.Handlers;
class NewProductHandler : IRequestHandler<NewProduct, GetProductResponse>
{
    private readonly IProductService productService;

    public NewProductHandler(IProductService _productService)
    {
        productService = _productService;
    }

    public async Task<GetProductResponse> Handle(NewProduct requestNewProduct, CancellationToken cancellationToken)
    {
        return await productService.Add(requestNewProduct);
    }
}
