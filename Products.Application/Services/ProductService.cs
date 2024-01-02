using Products.Application.Features.Product.Commands;
using Products.Application.Helpers.Products;
using Products.Application.Interfaces;
using Products.Domain.DTOs;
using Products.Domain.Interfaces;

namespace Products.Application.Services;

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
        this.unitOfWork = _unitOfWork;
        this.productRepository = _productRepository;
        statusService = _statusService;
        discountService = _discountService;
    }

    public async Task<GetProductResponse> Add(NewProduct newProduct)
    {
        var product = ConvertNewProductDTOtoProduct.Convert(newProduct);
        productRepository.Add(product);

        await unitOfWork.SaveChangesAsync();

        var status = statusService.GetStatus(newProduct.StatusId);
        return ConvertProductToGetProductDTO.Convert(product, status, 0);
    }

    public async Task<int> Delete(int id)
    {
        var product = await productRepository.GetByIdAsync(id);
        if (product == null)
            throw new Exception("Product doesn't exists");

        productRepository.Remove(product);

        var result = unitOfWork.SaveChanges();
        return result;

    }

    public async Task<GetProductResponse> GetProductById(int id)
    {
        var product = await productRepository.GetByIdAsync(id);
        if (product == null)
            throw new Exception("Product doesn't exists");

        var status = statusService.GetStatus(product.StatusId);
        var discount = await discountService.GetDiscount( id );
        return ConvertProductToGetProductDTO.Convert(product, status, discount);
    }

    public async Task<GetProductResponse> Update(EditProduct editProduct)
    {
        var product = await productRepository.GetByIdAsync(editProduct.Id);
        if (product == null)
            throw new Exception("Product doesn't exists");

        product = ConvertEditProductDTOtoProduct.Convert(editProduct, product);

        productRepository.Update(product);
        unitOfWork.SaveChanges();

        var status = statusService.GetStatus(editProduct.StatusId);
        var discount = await discountService.GetDiscount(editProduct.Id);
        return ConvertProductToGetProductDTO.Convert(product, status, discount);
    }
}
