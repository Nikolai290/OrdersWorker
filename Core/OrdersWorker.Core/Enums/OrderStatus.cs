namespace OrdersWorker.Core.Enums;

public enum OrderStatus : byte
{
    NewOrder = 1,
    Processed = 2,
    Error = 3
}