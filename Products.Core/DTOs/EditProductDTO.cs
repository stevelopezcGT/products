using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.DTOs
{
    public class EditProductDTO
    {
        [Required(ErrorMessage = "Invalid Product Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Invalid Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 1, ErrorMessage = "Invalid Status")]
        public int StatusId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid Stock")]
        public decimal Stock { get; set; }

        [Required(ErrorMessage = "Invalid Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid Price")]
        public decimal Price { get; set; } = 0;
    }
}
