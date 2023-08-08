using OrdersWorker.Core.DbEntities;
using OrderWorker.Business.Interfaces.Attributes;
using OrderWorker.Business.Interfaces.Handler;

namespace OrdersWorker.Business.Uber.Handler;

[SystemType("uber")]
public class UberHandler : IOrderHandler
{
    public void Run(Order order)
    {
        order.Handle(Handle);
    }

    private bool Handle(string source, out string result)
    {
        throw new NotImplementedException("uber выбрасывает исключение.");
    }
}