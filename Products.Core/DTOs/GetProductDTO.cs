using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.DTOs
{
    public class GetProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StatusName { get; set; }
        public decimal Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
        public decimal FinalPrice { get { return Price * (100 - Discount) / 100; } }
    }
}
