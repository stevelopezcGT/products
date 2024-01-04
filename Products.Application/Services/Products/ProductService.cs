using Products.Application.Features.Product.Create;
using Products.Application.Features.Product.Edit;
using Products.Application.Helpers.Products;
using Products.Application.Interfaces.Discounts;
using Products.Application.Interfaces.Products;
using Products.Application.Interfaces.Statuses;
using Products.Domain.DTOs;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces;

namespace Products.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IProductRepository productRepository;
    private readonly IStatusService statusService;
    private readonly IDiscountService discountService;

    public ProductService(IUnitOfWork _unitOfWork,
                          IProductRepository _productRepository,
                          IStatusService _statusService,
                          IDiscountService _discountService)
    {
        unitOfWork = _unitOfWork;
        productRepository = _productRepository;
        statusService = _statusService;
        discountService = _discountService;
    }

    public async Task Add(CreateProductCommand newProduct)
    {
        var product = ConvertNewProductDTOtoProduct.Convert(newProduct);
        productRepository.Add(product);

        await unitOfWork.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var product = await productRepository.GetByIdAsync(id);
        productRepository.Remove(product);

        var result = unitOfWork.SaveChanges();
        return result;

    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await productRepository.AnyAsync(x => x.Id == id);
    }

    public async Task<ProductResponse> GetProductById(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product == null)
            throw new ProductNotFoundException(id);

        return await ProductToResponse(product);
    }

    public async Task Update(EditProductCommand editProduct)
    {
        var product = await productRepository.GetByIdAsync(editProduct.Id);
        product = ConvertEditProductDTOtoProduct.Convert(editProduct, product);

        productRepository.Update(product);
        unitOfWork.SaveChanges();
    }

    private async Task<ProductResponse> ProductToResponse(Product product)
    {
        var status = statusService.GetStatus(product.StatusId);
        var discount = await discountService.GetDiscount(product.Id);
        return ConvertProductToGetProductDTO.Convert(product, status, discount);
    }

}
