

using OrdersWorker.Core.DbEntities;
using OrdersWorker.Domain.Interfaces.Repositories;

namespace OrdersWorker.Domain.Implements.Repositories;

public class SystemTypeRepository : BaseCrudRepository<SystemType, Guid>, ISystemTypeRepository
{
    public SystemTypeRepository(MsSqlContext msSqlContext) : base(msSqlContext)
    {
    }
} 
