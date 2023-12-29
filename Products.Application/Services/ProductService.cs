using Products.Application.Helpers.Products;
using Products.Application.Interfaces;
using Products.Domain.DTOs;
using Products.Domain.Entities;
using Products.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository productRepository;
        private readonly IStatusService statusService;

        public ProductService(IUnitOfWork _unitOfWork, 
                              IProductRepository _productRepository, 
                              IStatusService _statusService) 
        {
            this.unitOfWork = _unitOfWork;
            this.productRepository = _productRepository;
            statusService = _statusService;
        }

        public GetProductDTO Add(NewProductDTO productDTO)
        {
            var product = ConvertNewProductDTOtoProduct.Convert(productDTO);
            productRepository.Add(product);

            var result = unitOfWork.SaveChanges();

            var status = statusService.GetStatus(productDTO.StatusId);
            return ConvertProductToGetProductDTO.Convert(product, status);
        }

        public async Task<int> Delete(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            productRepository.Remove(product);

            var result = unitOfWork.SaveChanges();
            return result;

        }

        public async Task<GetProductDTO> GetProductById(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            var status = statusService.GetStatus(product.StatusId);
            return ConvertProductToGetProductDTO.Convert(product, status);
        }

        public async Task<GetProductDTO> Update(EditProductDTO productDTO)
        {
            var product = await productRepository.GetByIdAsync(productDTO.Id);

            product = ConvertEditProductDTOtoProduct.Convert(productDTO, product);

            productRepository.Update(product);
            unitOfWork.SaveChanges();

            var status = statusService.GetStatus(productDTO.StatusId);
            return ConvertProductToGetProductDTO.Convert(product, status);
        }
    }
}
