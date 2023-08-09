using Microsoft.Extensions.Logging;

namespace OrdersWorker.Business.Implements.FileLog;

public class FileLogger : ILogger
{
    private static object _lock = new object();

    private DateTime _lastUpdate;
    private string _directoryPath;
    private string _fileName;
    
    private string FullPath()
    {
        return $"{_directoryPath}/{_fileName}";
    }
    
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        UpdateCurrentPath();
        UpdateDirectory();
        if (formatter != null)
        {
            lock (_lock)
            {
                if (!Directory.Exists(_directoryPath))
                    Directory.CreateDirectory(_directoryPath);
                using var file = File.AppendText(FullPath());
                file.WriteLineAsync(formatter(state, exception) + Environment.NewLine).GetAwaiter().GetResult();
            }
        }
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }
    
    
    private void UpdateCurrentPath()
    {
        var dateTime = DateTime.Now;
        if (dateTime.Date == _lastUpdate.Date &&
            dateTime.Hour == _lastUpdate.Hour) return;
        _lastUpdate = dateTime;
        _directoryPath = $"./logs/{dateTime:yyyy-MM-dd}";
        _fileName = $"log-{dateTime:HH}.txt";
    }
    
    private void UpdateDirectory()
    {
        if (!Directory.Exists(_directoryPath))
            Directory.CreateDirectory(_directoryPath);
    }
}