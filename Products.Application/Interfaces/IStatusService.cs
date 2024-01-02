using Microsoft.Extensions.Caching.Memory;
using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Interfaces;

public interface IStatusService
{
    List<Status> GetStatuses();
    Status GetStatus(int id);
}
