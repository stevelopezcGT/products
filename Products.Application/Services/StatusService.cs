using Microsoft.Extensions.Caching.Memory;
using Products.Application.Interfaces;
using Products.Domain.Entities;

namespace Products.Application.Services
{
    public class StatusService : IStatusService
    {
        private readonly IMemoryCache memoryCache;
        const int MAX_DURATION_IN_MINUTES = 5;
        const string STATUS_KEY = "status";

        public StatusService(IMemoryCache _memoryCache)
        {
            memoryCache = _memoryCache;
        }

        public Status GetStatus(int id)
        {
            return GetStatuses().FirstOrDefault(d=> d.Id == id);
        }

        public List<Status> GetStatuses()
        {
            List<Status> listStatus;
            if (!memoryCache.TryGetValue(STATUS_KEY, out listStatus))
                listStatus = AddStatuses();

            return listStatus;
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
}
