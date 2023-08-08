using OrdersWorker.Core.DbEntities;
using OrderWorker.Business.Interfaces.Attributes;
using OrderWorker.Business.Interfaces.Handler;

namespace OrdersWorker.Business.Zomato.Handler;

[SystemType("zomato")]
public class ZomatoHandler : IOrderHandler
{
    public void Run(Order order)
    {
        order.Handle(Handle);
    }

    private bool Handle(string source, out string result)
    {
        throw new NotImplementedException();
    }
}