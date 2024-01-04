using MediatR;
using Products.Application.Abstractions.Messaging;
using Products.Application.Interfaces.Products;
using Products.Domain.DTOs;
using Products.Domain.Shared;

namespace Products.Application.Features.Product.Edit;

class EditProductHandler : IRequestHandler<EditProductCommand>
{
    private readonly IProductService productService;

    public EditProductHandler(IProductService _productService)
    {
        productService = _productService;
    }

    public async Task Handle(EditProductCommand requestEditProduct, CancellationToken cancellationToken)
    {
        await productService.Update(requestEditProduct);

        //return Result.Success();
    }
}

