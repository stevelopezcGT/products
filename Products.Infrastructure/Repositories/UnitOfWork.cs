using Products.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductsDBContext dbContext;

    public UnitOfWork(ProductsDBContext _dbContext) {
        dbContext = _dbContext;
    }

    private IProductRepository _productRepository;
    public IProductRepository ProductRepository => _productRepository?? (_productRepository = new ProductRepository(dbContext));

    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        return new GenericRepository<T>(dbContext);
    }

    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}
