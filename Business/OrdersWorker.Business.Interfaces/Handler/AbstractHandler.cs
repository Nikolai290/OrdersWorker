using System.Reflection.Metadata;
using OrdersWorker.Core.DbEntities;

namespace OrderWorker.Business.Interfaces.Handler;

public abstract class AbstractHandler : IOrderHandler
{
    public void Run(Order order)
    {
        order.Handle(Handle);
    }

    protected abstract bool Handle(string source, out string result);
}