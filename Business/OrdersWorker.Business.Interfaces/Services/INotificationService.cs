namespace OrderWorker.Business.Interfaces.Services;

public interface INotificationService
{
    Task NotificationErrorAsync(string message);
}