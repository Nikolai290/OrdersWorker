namespace OrdersWorker.Business.DataTransferObjects.OrderDtos;

public record ProductDto(
    string Id,
    string Name,
    string Comment,
    string Quantity,
    string PaidPrice,
    string UnitPrice,
    string RemoteCode,
    string Description,
    string YatPercentage,
    string DiscountAmount);