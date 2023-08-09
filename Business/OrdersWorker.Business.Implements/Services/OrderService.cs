using System.Text.Json;
using OrdersWorker.Core.DbEntities;
using OrdersWorker.Domain.Interfaces.Repositories;
using OrderWorker.Business.Implements.Handler;
using OrderWorker.Business.Interfaces.Services;

namespace OrdersWorker.Business.Implements.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task AddOrderAsync(string systemType, JsonDocument requestBodyJson, CancellationToken cancellationToken)
    {
        var orderNumber = requestBodyJson.RootElement.GetProperty("orderNumber").ToString();
        var createdAt = requestBodyJson.RootElement.GetProperty("createdAt").ToString();
        var order = new Order(
            Guid.NewGuid(),
            systemType,
            orderNumber,
            requestBodyJson.RootElement.GetRawText(),
            DateTimeOffset.Parse(createdAt));
        var json = JsonSerializer.Serialize(order);
        
        var result = await _orderRepository.CreateAsync(order, cancellationToken);
    }
}