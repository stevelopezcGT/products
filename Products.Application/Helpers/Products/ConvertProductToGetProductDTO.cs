using Products.Domain.DTOs;
using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Helpers.Products
{
    public static class ConvertProductToGetProductDTO
    {
        public static GetProductDTO Convert(Product product, Status status)
        {
            return new GetProductDTO
            {
                Description = product.Description,
                Discount = GetProductDiscount.Get(product.Id),
                Name = product.Name,
                Price = product.Price,
                ProductId = product.Id,
                Stock = product.Stock,
                StatusName = status.StatusName
            };
        }
    }
}
