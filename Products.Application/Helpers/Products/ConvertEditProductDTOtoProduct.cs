using Products.Domain.DTOs;
using Products.Domain.Entities;

namespace Products.Application.Helpers.Products
{
    public static class ConvertEditProductDTOtoProduct
    {
        public static Product Convert(EditProductDTO editProductDTO, Product product)
        {
            product.Description = editProductDTO.Description;
            product.Name = editProductDTO.Name;
            product.Price = editProductDTO.Price;
            product.StatusId = editProductDTO.StatusId;
            product.Stock = editProductDTO.Stock;

            return product;
        }
    }
}
