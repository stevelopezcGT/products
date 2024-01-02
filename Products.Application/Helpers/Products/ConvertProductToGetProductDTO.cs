using Products.Domain.DTOs;
using Products.Domain.Entities;

namespace Products.Application.Helpers.Products;

public static class ConvertProductToGetProductDTO
{
    public static GetProductResponse Convert(Product product, Status status, decimal discount)
    {
        return new GetProductResponse
        {
            Description = product.Description,
            Discount = discount,
            Name = product.Name,
            Price = product.Price,
            ProductId = product.Id,
            Stock = product.Stock,
            StatusName = status.StatusName,

        };
    }
}

