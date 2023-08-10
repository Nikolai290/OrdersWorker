using OrdersWorker.Business.Implements.Services;
using OrdersWorker.Domain.Implements.Repositories;
using OrdersWorker.Domain.Interfaces.Repositories;
using OrderWorker.Business.Interfaces.Services;

namespace WebApp.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }
    
    public static IServiceCollection AddRServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<INotificationService, NotificationService>();
        return services;
    }
}