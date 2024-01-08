using MediatR;
using Products.Application.Abstractions.Messaging;
using Products.Application.Interfaces.Products;
using Products.Domain.DTOs;
using Products.Domain.Enums;
using Products.Domain.Shared;

namespace Products.Application.Features.Product.Edit;

class EditProductHandler : IRequestHandler<EditProductCommand, Result>
{
    private readonly IProductService productService;

    public EditProductHandler(IProductService _productService)
    {
        productService = _productService;
    }

    public async Task<Result> Handle(EditProductCommand requestEditProduct, CancellationToken cancellationToken)
    {
        var result = await productService.Update(requestEditProduct);

        return result? Result.Success(): Result.Failure(new Error(CodeMessages.PRODUCT_CANNOT_UPDATE, Messages.PRODUCT_CANNOT_UPDATE));
    }


}

