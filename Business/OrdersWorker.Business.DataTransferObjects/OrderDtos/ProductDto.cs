namespace OrdersWorker.Business.DataTransferObjects.OrderDtos;

public record ProductDto(
    string Id,
    string Name,
    string Comment,
    int Quantity,
    decimal PaidPrice,
    decimal UnitPrice,
    string RemoteCode,
    string Description,
    string YatPercentage,
    string DiscountAmount);