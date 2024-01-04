using Microsoft.Extensions.Caching.Memory;
using Products.Application.Interfaces.Statuses;
using Products.Domain.Entities;

namespace Products.Application.Services.Statuses;

public class StatusService : IStatusService
{
    private readonly IMemoryCache memoryCache;
    const int MAX_DURATION_IN_MINUTES = 5;
    const string STATUS_KEY = "status";

    public StatusService(IMemoryCache _memoryCache)
    {
        memoryCache = _memoryCache;
    }

    public Status? GetStatus(int id)
    {
        return GetStatuses().FirstOrDefault(d => d.Id == id);
    }

    public List<Status> GetStatuses()
    {
        List<Status> listStatus;
        if (!memoryCache.TryGetValue(STATUS_KEY, out listStatus))
            listStatus = AddStatuses();

        return listStatus;
    }

    public bool Exists(int id)
    {
        return GetStatuses().Any(d => d.Id == id);
    }

    private List<Status> AddStatuses()
    {
        List<Status> listStatus = new List<Status>
        {
            new Status { Id = 1, StatusName = "Active"},
            new Status { Id = 0, StatusName = "Inactive"}
        };

        memoryCache.Set(STATUS_KEY, listStatus, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(MAX_DURATION_IN_MINUTES)));

        return listStatus;
    }
}
