using System.Reflection;
using OrderWorker.Business.Interfaces.Attributes;
using OrderWorker.Business.Interfaces.Handler;

namespace OrderWorker.Business.Implements.Handler;

public class HandlersLoader
{
    public static Dictionary<string, IOrderHandler> Handlers = new Dictionary<string, IOrderHandler>();
    public static void LoadHandlers()
    {
        var handlers = Directory.EnumerateFiles(".").Where(p => p.EndsWith(".dll"));

        foreach (var handlerPath in handlers)
        {
            var assembly = Assembly.LoadFrom(handlerPath);
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IOrderHandler))))
                {
                    var systemType = type.GetCustomAttribute(typeof(SystemTypeAttribute), false);

                    if (systemType is null)
                    {
                        throw new Exception("Обработчик не содержит атрибут SystemType.");
                    }

                    var constructors = type.GetConstructors();
                    var handlerInstance = constructors.First().Invoke(new object[] { });
                    
                    Handlers.Add(systemType.ToString(), handlerInstance as IOrderHandler);
                }
            }
        }

    }
}