using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.DTOs
{
    public class NewProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public decimal Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
    }
}
