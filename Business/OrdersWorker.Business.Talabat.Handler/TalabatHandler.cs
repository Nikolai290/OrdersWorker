using System.Text.Json;
using OrdersWorker.Business.DataTransferObjects.OrderDtos;
using OrdersWorker.Core.DbEntities;
using OrderWorker.Business.Interfaces.Attributes;
using OrderWorker.Business.Interfaces.Handler;

namespace OrdersWorker.Business.Talabat.Handler;

[SystemType("talabat")]
public class TalabatHandler : IOrderHandler
{
    public void Run(Order order)
    {
        order.Handle(Handle);
    }

    private bool Handle(string source, out string result)
    {
        var success = true;
        result = "";
        var dto = JsonSerializer.Deserialize<OrderDto>(source);
        
        return success;
    }
}