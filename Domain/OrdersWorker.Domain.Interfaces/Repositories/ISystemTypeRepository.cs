using OrdersWorker.Core.DbEntities;

namespace OrdersWorker.Domain.Interfaces.Repositories;

public interface ISystemTypeRepository : IBaseCrudRepository<SystemType, Guid>
{

    bool Exists(string name);
}