using System.Text.Json;

namespace OrderWorker.Business.Interfaces.Services;

public interface IOrderService
{
    Task AddOrderAsync(string systemType, JsonDocument requestBodyJson, CancellationToken cancellationToken);
}