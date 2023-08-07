using OrdersWorker.Core.Enums;

namespace OrdersWorker.Core.DbEntities;

public record Order(
    SystemType SystemType,
    string OrderNumber,
    string SourceOrder,
    string ConvertedOrder,
    OrderStatus OrderStatus,
    DateTime CreatedAt) : BaseDbEntity;