using MediatR;
using Products.Application.Interfaces.Products;
using Products.Domain.DTOs;
using Products.Domain.Enums;

namespace Products.Application.Features.Product.Read;

internal sealed class ReadProductHandler : IRequestHandler<ReadProductQuery, ProductResponse>
{
    private readonly IProductService productService;

    public ReadProductHandler(IProductService _productService)
    {
        productService = _productService;
    }

    public async Task<ProductResponse> Handle(ReadProductQuery requestProduct, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(requestProduct.Id);

        if (product == null)
            throw new KeyNotFoundException(CodeMessages.PRODUCT_NOT_FOUND);

        return product;
    }   
}
