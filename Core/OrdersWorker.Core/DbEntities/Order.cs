using OrdersWorker.Core.Enums;

namespace OrdersWorker.Core.DbEntities;

public record Order(
    Guid Id,
    string SystemType,
    string OrderNumber,
    string SourceOrder,
    DateTimeOffset CreatedAt) : BaseDbEntity(Id)
{
    public string? ConvertedOrder { get; private set; }
    public OrderStatus OrderStatus { get; private set; } = OrderStatus.NewOrder;

    public delegate bool TryConvert(string source, out string result);

    public void Handle(TryConvert converter)
    {
        try
        {
            var success = converter.Invoke(SourceOrder, out string convertedOrder);
            if (!success)
            {
                OrderStatus =  OrderStatus.Error;
                return;
            }
            OrderStatus = OrderStatus.Processed;
            ConvertedOrder = convertedOrder;
        }
        catch
        {
            OrderStatus =  OrderStatus.Error;
            throw;
        }

    }
}