using MailKit.Net.Smtp;
using MimeKit;
using NotificationHubSystem.Core.Base;
using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.SharedKernal;
using NotificationHubSystem.SharedKernal.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationHubSystem.Core.UseCases.Mail.MailSendUseCase
{
    internal class MailSendUseCase : BaseUseCase, IMailSendUseCase
    {
        #region Props
        private readonly SMTPServerSettings _sMTPServerSettings;
        #endregion
        public MailSendUseCase(SMTPServerSettings sMTPServerSettings)
        {
            _sMTPServerSettings = sMTPServerSettings;
        }

        public async Task<bool> HandleUseCase(List<NotificationBase> _request, IOutputPort<ResultDto<bool>> _response)
        {
            _request.ForEach(mail =>
            {
                MimeMessage MailObj = CreateEmailMessage(
                    mail.Mail.To.Split(',').ToList(),
                    mail.Mail.CC?.Any() ?? default ? mail.Mail.CC.Split(',').ToList() : new List<string>(),
                    mail.Mail.BCC?.Any() ?? default ? mail.Mail.BCC.Split(',').ToList() : new List<string>(),
                    mail.Mail.Subject,
                    mail.Body, mail.Mail.IsHtml);

                string sendingResult = Send(MailObj);
                if (string.IsNullOrWhiteSpace(sendingResult))
                    mail.StatusId = (byte)SharedKernal.Enum.CommonEnum.SendingStatus.Success;
                else
                {
                    mail.StatusId = (byte)SharedKernal.Enum.CommonEnum.SendingStatus.Failed;
                    mail.Exception = sendingResult;
                }
            });
            await UnitOfWork.Commit();
            _response.HandlePresenter(new ResultDto<bool>());
            return true;
        }

        private MimeMessage CreateEmailMessage(List<string> to, List<string> cc, List<string> bcc, string subject, string content, bool isHtml)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(MailboxAddress.Parse(_sMTPServerSettings.From));
            emailMessage.To.AddRange(to.Select(x => MailboxAddress.Parse(x)));
            emailMessage.Cc.AddRange(cc.Select(x => MailboxAddress.Parse(x)));
            emailMessage.Bcc.AddRange(cc.Select(x => MailboxAddress.Parse(x)));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(isHtml ? MimeKit.Text.TextFormat.Html : MimeKit.Text.TextFormat.Text) { Text = content };

            return emailMessage;
        }

        private string Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_sMTPServerSettings.SmtpServer, _sMTPServerSettings.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_sMTPServerSettings.UserName, _sMTPServerSettings.Password);

                    client.Send(mailMessage);
                    return string.Empty;

                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception or both.
                    return ex.Message;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();

                }
            }
        }
    }
}
