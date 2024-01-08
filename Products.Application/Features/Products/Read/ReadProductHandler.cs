using MediatR;
using Products.Application.Abstractions.Messaging;
using Products.Application.Interfaces.Products;
using Products.Domain.DTOs;
using Products.Domain.Enums;
using Products.Domain.Shared;

namespace Products.Application.Features.Product.Read;

internal sealed class ReadProductHandler : IQueryHandler<ReadProductQuery, ProductResponse>
{
    private readonly IProductService productService;

    public ReadProductHandler(IProductService _productService)
    {
        productService = _productService;
    }

    public async Task<Result<ProductResponse>> Handle(ReadProductQuery requestProduct, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(requestProduct.Id);

        if (product == null)
            return Result.Failure<ProductResponse>(new Error(CodeMessages.PRODUCT_NOT_FOUND, Messages.PRODUCT_NOT_FOUND));

        return product;
    }

}
