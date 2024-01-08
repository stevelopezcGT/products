using Products.Application.Features.Product.Read;
using Products.Domain.DTOs;

namespace Products.Test.Products.GetProduct;
public static class ReadProductHelper
{    
    public static ReadProductQuery createReadProductQuery => 
        new ReadProductQuery
        {
            Id = 1,
        };

    public static ProductResponse GetProductResponse=> new ProductResponse
        {
            ProductId = 1,
            Description = "description",
            Name = "name",
            Discount = 10,
            Price = 100,
            StatusName = "status"
        };
}
