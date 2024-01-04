using Products.Domain.Entities;

namespace Products.Application.Interfaces.Statuses;

public interface IStatusService
{
    List<Status> GetStatuses();
    Status GetStatus(int id);
    bool Exists (int id);
}
