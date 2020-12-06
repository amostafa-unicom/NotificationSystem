using NotificationHubSystem.Core.DTOs.UseCase.Base;
using System.Collections.Generic;

namespace NotificationHubSystem.Core.UseCases.MailAddUseCase
{
    public class MailAddInputDto: NotificationBase
    {
        public List<string> To { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Bcc { get; set; }
        public string Subject { get; set; }
        public bool IsHtml { get; set; }
    }
}
