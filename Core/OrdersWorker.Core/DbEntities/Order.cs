using OrdersWorker.Core.Enums;

namespace OrdersWorker.Core.DbEntities;

public record Order(Guid Id, string SystemType, string OrderNumber, string SourceOrder, DateTimeOffset CreatedAt, string? ConvertedOrder, OrderStatus OrderStatus) : BaseDbEntity(Id)
{

    public string SystemType { get; init; } = SystemType;
    public string OrderNumber { get; init; } = OrderNumber;
    public string SourceOrder { get; init; } = SourceOrder;
    public DateTimeOffset CreatedAt { get; init; } = CreatedAt;
    public string? ConvertedOrder { get; private set; } = ConvertedOrder;
    public OrderStatus OrderStatus { get; private set; } = OrderStatus;

    public delegate bool TryConvert(string source, out string result);

    public void Handle(TryConvert converter)
    {
        try
        {
            var success = converter.Invoke(SourceOrder, out string convertedOrder);
            if (!success)
            {
                OrderStatus = OrderStatus.Error;
                return;
            }

            OrderStatus = OrderStatus.Processed;
            ConvertedOrder = convertedOrder;
        }
        catch
        {
            OrderStatus = OrderStatus.Error;
            throw;
        }
    }
}