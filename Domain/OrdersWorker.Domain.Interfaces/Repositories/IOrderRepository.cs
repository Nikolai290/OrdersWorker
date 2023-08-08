using OrdersWorker.Core.DbEntities;

namespace OrdersWorker.Domain.Interfaces.Repositories;

public interface IOrderRepository : IBaseCrudRepository<Order, Guid>
{
    
}