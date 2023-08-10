using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrdersWorker.Core.DbEntities;
using OrdersWorker.Core.Enums;
using OrdersWorker.Domain.Interfaces.Repositories;
using OrderWorker.Business.Implements.Handler;
using OrderWorker.Business.Interfaces.BackgroundServices;
using OrderWorker.Business.Interfaces.Services;

namespace OrdersWorker.Business.Implements.BackgroundServices;

public class OrderHandlerBackgroundService : BackgroundService, IOrderHandlerBackgroundService
{
    private Timer? _timer = null;
    private readonly IServiceProvider _services;
    private static List<string> NO_HANDLERS = new ();

    public OrderHandlerBackgroundService(IServiceProvider services)
    {
        _services = services;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken = default)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        return Task.CompletedTask;
    }

    public void DoWork(object? state)
    {
        var handlers = HandlersLoader.Handlers;
        var modified = new List<Order>();
        using (var scope = _services.CreateScope())
        {
            var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
            var orders = orderRepository.GetAllAsync(default);
            foreach (var order in orders)
            {
                if (order.OrderStatus == OrderStatus.Processed ||
                    NO_HANDLERS.Contains(order.SystemType)) continue;
                try
                {
                    if (!HandlersLoader.Handlers.ContainsKey(order.SystemType))
                    {
                        NO_HANDLERS.Add(order.SystemType);
                        throw new ArgumentException("No handler for this system.", order.SystemType);
                    }
                    var handler = handlers[order.SystemType];
                    modified.Add(order);
                    handler.Run(order);
                }
                catch (Exception e)
                {
                    notificationService.NotificationErrorAsync(e.ToString());
                }
            }

            if (modified.Any()) orderRepository.UpdateRangeAsync(modified, default).GetAwaiter().GetResult();
        }
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return base.StopAsync(cancellationToken);
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}