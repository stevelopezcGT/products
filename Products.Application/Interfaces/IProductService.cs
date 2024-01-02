using Products.Application.Features.Product.Commands;
using Products.Domain.DTOs;

namespace Products.Application.Interfaces;

public interface IProductService
{
    Task<GetProductResponse> Add(NewProduct newProduct);
    Task<GetProductResponse> Update(EditProduct editProduct);
    Task<int> Delete(int id);
    Task<GetProductResponse> GetProductById(int id);
}

