﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Interfaces;

public interface IUnitOfWork
{
    int SaveChanges();

    Task<int> SaveChangesAsync();

    IGenericRepository<T> GenericRepository<T>() where T : class;
    IProductRepository ProductRepository { get; }
}
