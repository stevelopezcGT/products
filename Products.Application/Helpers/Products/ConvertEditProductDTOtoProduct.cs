using Products.Application.Features.Product.Edit;
using Products.Domain.Entities;

namespace Products.Application.Helpers.Products;

public static class ConvertEditProductDTOtoProduct
{
    public static Product Convert(EditProductCommand editProductDTO, Product product)
    {
        product.Description = editProductDTO.Description;
        product.Name = editProductDTO.Name;
        product.Price = editProductDTO.Price;
        product.StatusId = editProductDTO.StatusId;
        product.Stock = editProductDTO.Stock;
        product.UpdatedAt = DateTimeOffset.Now;

        return product;
    }
}

