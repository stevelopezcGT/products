using MediatR;
using Products.Application.Interfaces.Products;
using Products.Domain.Shared;

namespace Products.Application.Features.Product.Create;

internal sealed class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<int>>
{
    private readonly IProductService productService;

    public CreateProductHandler(IProductService _productService)
    {
        productService = _productService;
    }

    public async Task<Result<int>> Handle(CreateProductCommand requestNewProduct, CancellationToken cancellationToken)
    {
        var newProductId = await productService.Add(requestNewProduct);
        return Result.Success(newProductId);
    }

    
}
