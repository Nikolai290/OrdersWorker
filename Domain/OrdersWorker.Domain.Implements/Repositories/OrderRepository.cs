using OrdersWorker.Core.DbEntities;
using OrdersWorker.Domain.Interfaces.Repositories;

namespace OrdersWorker.Domain.Implements.Repositories;

public class OrderRepository : BaseCrudRepository<Order, Guid>, IOrderRepository
{
    public OrderRepository(MsSqlContext msSqlContext) : base(msSqlContext)
    {
    }
}