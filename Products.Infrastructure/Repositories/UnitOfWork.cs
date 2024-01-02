using Products.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductsDBContext dBContext;

    public UnitOfWork(ProductsDBContext _dbContext) {
        dBContext = _dbContext;
    }

    private IProductRepository _productRepository;
    public IProductRepository ProductRepository => _productRepository?? (_productRepository = new ProductRepository(dBContext));

    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        return new GenericRepository<T>(dBContext);
    }

    public int SaveChanges()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
