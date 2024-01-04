using MediatR;
using Products.Application.Interfaces.Products;

namespace Products.Application.Features.Product.Create;

internal sealed class CreateProductHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductService productService;

    public CreateProductHandler(IProductService _productService)
    {
        productService = _productService;
    }

    public async Task Handle(CreateProductCommand requestNewProduct, CancellationToken cancellationToken)
    {
        await productService.Add(requestNewProduct);
    }

    
}
