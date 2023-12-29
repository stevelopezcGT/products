using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Data
{
    public class ProductsDBContext : DbContext
    {
        public DbSet<Product> Products{ get; set; }
    }
}
