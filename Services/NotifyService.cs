namespace EventsInBlazorTests.Services;

internal class NotifyService(ILogger<NotifyService> logger)
{
    public event Action? OnNotificationReceived;

    // Sendet eine Benachrichtigung an alle registrierten Abonnenten.
    public void SendNotification()
    {
        logger.LogInformation("Sende Benachrichtigung");
        NotificationReceivedHandler();
        logger.LogInformation("Benachrichtigung gesendet");
    }


    // Klasseninterne Funktion zum Triggern des Eventhandlers
    private void NotificationReceivedHandler() => OnNotificationReceived?.Invoke();
}