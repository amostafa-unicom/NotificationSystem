using NotificationHubSystem.Core.DTOs.UseCase.Base;

namespace NotificationHubSystem.Core.UseCases.RealTime.RealTimeAddUseCase
{
    public class RealTimeAddInputDto: NotificationBase
    {
        public string Event { get; set; }
    }
}
