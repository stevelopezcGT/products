using Products.Application.Features.Product.Edit;

namespace Products.Test.Products.EditProduct;
public static class EditProductHelper
{
    public static EditProductCommand editProductCommand => 
        new EditProductCommand
        {
            Id = 1,
            Description = "Test",
            Price = 10,
            StatusId = 0,
            Stock = 10,
            Name = "Test"
        };
}
