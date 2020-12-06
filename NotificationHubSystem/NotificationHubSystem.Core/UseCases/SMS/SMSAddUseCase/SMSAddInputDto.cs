using NotificationHubSystem.Core.DTOs.UseCase.Base;

namespace NotificationHubSystem.Core.UseCases.SMS.SMSAddUseCase
{
    public class SMSAddInputDto: NotificationBase
    {
        public string Recipient { get; set; }
    }
}
