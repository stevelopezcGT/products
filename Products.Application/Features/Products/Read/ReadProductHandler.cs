using MediatR;
using Products.Application.Interfaces.Products;
using Products.Domain.DTOs;
using Products.Domain.Enums;
using Products.Domain.Shared;

namespace Products.Application.Features.Product.Read;

internal sealed class ReadProductHandler : IRequestHandler<ReadProductQuery, Result>
{
    private readonly IProductService productService;

    public ReadProductHandler(IProductService _productService)
    {
        productService = _productService;
    }

    public async Task<Result> Handle(ReadProductQuery requestProduct, CancellationToken cancellationToken)
    {
        var product = await productService.GetProductById(requestProduct.Id);

        if (product == null)
            return Result.Failure(new Error(CodeMessages.PRODUCT_NOT_FOUND, Messages.PRODUCT_NOT_FOUND));

        return Result.Success(product);
    }   
}
