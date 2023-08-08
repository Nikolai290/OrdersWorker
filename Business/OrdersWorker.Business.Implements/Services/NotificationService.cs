using Microsoft.Extensions.Logging;
using OrderWorker.Business.Interfaces.Services;

namespace OrdersWorker.Business.Implements.Services;

public class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> _logger;

    public NotificationService(ILogger<NotificationService> logger)
    {
        _logger = logger;
    }
    public Task NotificationErrorAsync(string message)
    {
        _logger.LogError(message);
        return Task.Delay(10000);
    }
}