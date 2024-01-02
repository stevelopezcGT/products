using MediatR;
using Products.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Products.Application.Features.Product.Commands;
public class EditProduct : IRequest<GetProductResponse>
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

