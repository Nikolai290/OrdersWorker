using System.Reflection;
using Microsoft.Extensions.Logging;
using OrderWorker.Business.Interfaces.Attributes;
using OrderWorker.Business.Interfaces.Handler;

namespace OrderWorker.Business.Implements.Handler;

public class HandlersLoader
{
    public static Dictionary<string, IOrderHandler> Handlers = new Dictionary<string, IOrderHandler>();
    public static void LoadHandlers(ILogger logger)
    {
        logger.LogInformation($"Loading handlers.");
        var handlers = Directory.EnumerateFiles(".").Where(p => p.EndsWith(".dll"));
        logger.LogInformation($"Found {handlers.Count()} handlers.");

        foreach (var handlerPath in handlers)
        {
            logger.LogInformation($"Loading {handlerPath}");
            var assembly = Assembly.LoadFrom(handlerPath);
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IOrderHandler))))
                {
                    var systemType = type.GetCustomAttribute(typeof(SystemTypeAttribute), false);
                    logger.LogInformation($"Handler {systemType}");
                    if (systemType is null)
                    {
                        throw new Exception("No systemType provided. Untrusted handler!");
                    }

                    var constructors = type.GetConstructors();
                    var handlerInstance = constructors.First().Invoke(new object[] { });
                    logger.LogInformation("Handler loaded and ready.");
                    Handlers.Add(systemType.ToString(), handlerInstance as IOrderHandler);
                }
            }
        }

    }
}