using Products.Application.Features.Product.Create;

namespace Products.Test.Products.CreateProduct;
public static class CreateCommandHelper
{
    public static CreateProductCommand createProductCommand=> new CreateProductCommand
        {
            Description = "Test",
            Price = 10,
            StatusId = 0,
            Stock = 10,
            Name = "Test"
        };
    
}
