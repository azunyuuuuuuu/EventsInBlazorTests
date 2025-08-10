namespace EventsInBlazorTests.Services;

internal class NotifyService(ILogger<NotifyService> logger)
{
    public event Action? OnNotificationReceived;

    public void SendNotification()
    {
        logger.LogInformation("Sending notification");
        NotificationReceivedHandler();
        logger.LogInformation("Notification sent");
    }

    private void NotificationReceivedHandler() => OnNotificationReceived?.Invoke();
}