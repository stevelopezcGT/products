﻿using MediatR;
using Products.Application.Abstractions.Messaging;
using Products.Domain.DTOs;
using Products.Domain.Shared;

namespace Products.Application.Features.Product.Read;

public sealed class ReadProductQuery : IQuery<ProductResponse>
{
    public int Id { get; set; }
}

