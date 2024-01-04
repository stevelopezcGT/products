using Products.Application.Features.Product.Create;
using Products.Domain.Entities;

namespace Products.Application.Helpers.Products;

public static class ConvertNewProductDTOtoProduct
{
    public static Product Convert(CreateProductCommand newProductDTO)
    {
        return new Product
        {
            Description = newProductDTO.Description,
            Name = newProductDTO.Name,
            Price = newProductDTO.Price,
            StatusId = newProductDTO.StatusId,
            Stock = newProductDTO.Stock,
            CreatedAt= DateTimeOffset.Now,
            UpdatedAt= DateTimeOffset.Now
        };

    }
}
