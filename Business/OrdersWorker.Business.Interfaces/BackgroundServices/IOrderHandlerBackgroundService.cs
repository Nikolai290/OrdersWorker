using Microsoft.Extensions.Hosting;

namespace OrderWorker.Business.Interfaces.BackgroundServices;

public interface IOrderHandlerBackgroundService : IHostedService, IDisposable
{
    void DoWork(object? state);

}