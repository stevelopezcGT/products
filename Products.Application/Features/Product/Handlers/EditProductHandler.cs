using MediatR;
using Products.Application.Features.Product.Commands;
using Products.Application.Interfaces;
using Products.Domain.DTOs;

namespace Products.Application.Features.Product.Handlers;

class EditProductHandler : IRequestHandler<EditProduct, GetProductResponse>
{
    private readonly IProductService productService;

    public EditProductHandler(IProductService _productService)
    {
        productService = _productService;
    }

    public async Task<GetProductResponse> Handle(EditProduct requestEditProduct, CancellationToken cancellationToken)
    {
        return await productService.Update(requestEditProduct);
    }
}

