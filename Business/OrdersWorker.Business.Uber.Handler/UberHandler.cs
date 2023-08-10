using OrderWorker.Business.Interfaces.Attributes;
using OrderWorker.Business.Interfaces.Handler;

namespace OrdersWorker.Business.Uber.Handler;

[SystemType("uber")]
public class UberHandler : AbstractHandler
{
    protected override bool Handle(string source, out string result)
    {
        throw new NotImplementedException("UBER HAS THROWN AN EXCEPTION!!!");
    }
}