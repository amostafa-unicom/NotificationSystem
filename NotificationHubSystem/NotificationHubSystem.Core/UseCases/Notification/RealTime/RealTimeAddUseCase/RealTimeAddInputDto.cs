namespace NotificationHubSystem.Core.UseCases.Notification.RealTime.RealTimeAddUseCase
{
    public class RealTimeAddInputDto
    {
        public int ReceiverId { get; set; }
        public string Body { get; set; }
        public string Event { get; set; }
    }
}
