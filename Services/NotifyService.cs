namespace EventsInBlazorTests.Services;

internal class NotifyService(ILogger<NotifyService> logger)
{
    public event Action? OnNotificationReceived;

    /// <summary>
    /// Sendet eine Benachrichtigung an alle registrierten Abonnenten, indem das Ereignis ausgelöst wird.
    /// </summary>
    public void SendNotification()
    {
        logger.LogInformation("Sende Benachrichtigung");
        NotificationReceivedHandler();
        logger.LogInformation("Benachrichtigung gesendet");
    }

    /// <summary>
    /// Internes Hilfsmittel zum sicheren Auslösen des Ereignisses (ruft alle Handler auf, falls vorhanden).
    /// </summary>
    private void NotificationReceivedHandler() => OnNotificationReceived?.Invoke();
}