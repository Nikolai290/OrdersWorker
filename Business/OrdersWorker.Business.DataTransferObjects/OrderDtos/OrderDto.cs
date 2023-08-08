namespace OrdersWorker.Business.DataTransferObjects.OrderDtos;

public record OrderDto(string OrderNumber, ProductDto[] Products, string CreatedAt);