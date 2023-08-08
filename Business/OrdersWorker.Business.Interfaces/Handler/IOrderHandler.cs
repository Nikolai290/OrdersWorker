using OrdersWorker.Core.DbEntities;

namespace OrderWorker.Business.Interfaces.Handler;

public interface IOrderHandler
{
    void Run(Order order);
}