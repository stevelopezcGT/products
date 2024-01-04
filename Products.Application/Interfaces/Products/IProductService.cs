using Products.Application.Features.Product.Create;
using Products.Application.Features.Product.Edit;
using Products.Domain.DTOs;

namespace Products.Application.Interfaces.Products;

public interface IProductService
{
    Task Add(CreateProductCommand newProduct);
    Task Update(EditProductCommand editProduct);
    Task<int> Delete(int id);
    Task<ProductResponse> GetProductById(int id);
    Task<bool> ExistsAsync(int id);

}

