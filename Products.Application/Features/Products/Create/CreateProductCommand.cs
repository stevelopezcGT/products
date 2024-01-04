﻿using Products.Application.Abstractions.Messaging;

namespace Products.Application.Features.Product.Create;

public class CreateProductCommand : ICommand
{
    public string? Name { get; set; }
    public int StatusId { get; set; }
    public decimal Stock { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

