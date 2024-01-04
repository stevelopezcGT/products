using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Exceptions;
public sealed class ProductNotFoundException : KeyNotFoundException
{
    public ProductNotFoundException(int productId) : base($"Product {productId} not found")
    {        
    }
}
