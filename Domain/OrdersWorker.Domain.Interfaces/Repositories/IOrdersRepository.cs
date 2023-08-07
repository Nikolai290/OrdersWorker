using OrdersWorker.Core.DbEntities;

namespace OrdersWorker.Domain.Interfaces.Repositories;

public interface IOrdersRepository : IBaseCrudRepository<Order>
{
    
}