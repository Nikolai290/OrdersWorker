using System.Data;
using Microsoft.Extensions.Logging;

namespace OrdersWorker.Business.Implements.FileLog;

public class FileLoggerProvider : ILoggerProvider
{
    public void Dispose()
    {
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger();
    }
}