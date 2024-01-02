﻿using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Data;

public class ProductsDBContext : DbContext
{
    public ProductsDBContext( DbContextOptions<ProductsDBContext> options) : base(options) { }
    
    public DbSet<Product> Products{ get; set; }
}
