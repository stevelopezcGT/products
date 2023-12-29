using Products.Domain.DTOs;
using Products.Domain.Entities;

namespace Products.Application.Helpers.Products
{
    public static class ConvertNewProductDTOtoProduct
    {
        public static Product Convert(NewProductDTO newProductDTO)
        {
            return new Product
            {
                Description = newProductDTO.Description,
                Name = newProductDTO.Name,
                Price = newProductDTO.Price,
                StatusId = newProductDTO.StatusId,
                Stock = newProductDTO.Stock
            };

        }
    }
}
