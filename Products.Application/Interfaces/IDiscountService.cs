using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Interfaces
{
    public interface IDiscountService
    {
        Task<decimal> GetDiscount(int productId);
    }
}
