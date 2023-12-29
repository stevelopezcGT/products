using Products.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Interfaces
{
    public interface IProductService
    {
        GetProductDTO Add(NewProductDTO productDTO);
        Task<GetProductDTO> Update(EditProductDTO productDTO);
        Task<int> Delete(int id);
        Task<GetProductDTO> GetProductById(int id);
    }
}
