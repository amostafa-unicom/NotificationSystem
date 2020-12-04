namespace NotificationHubSystem.Core.UseCases.Notification.RealTime.RealTimeSendUseCase
{
    internal class RealTimeSendInputDto
    {
        public int NotificationId { get; set; }
        public string Event { get; set; }
        public string Body { get; set; }
    }
}
