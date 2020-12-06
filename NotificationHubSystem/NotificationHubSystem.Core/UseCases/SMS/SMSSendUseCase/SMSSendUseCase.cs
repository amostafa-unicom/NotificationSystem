using NotificationHubSystem.Core.Base;
using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.SharedKernal;
using NotificationHubSystem.SharedKernal.Settings;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharp.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationHubSystem.Core.UseCases.SMS.SMSSendUseCase
{
    internal class SMSSendUseCase : BaseUseCase, ISMSSendUseCase
    {
        #region Props
        private readonly SMSSettings _SMSSettings;
        private RestClient Client;
        #endregion
        public SMSSendUseCase(SMSSettings sMSSettings)
        {
            _SMSSettings = sMSSettings;
            Client = new RestClient
            {
                BaseUrl = new Uri(_SMSSettings.UnifonicBaseUrl),
                Timeout = 60000
            };
            Client.AddDefaultParameter("AppSid", _SMSSettings.AppSid);
        }
        public async Task<bool> HandleUseCase(List<NotificationBase> _request, IOutputPort<ResultDto<bool>> _response)
        {

            _request.ForEach(sms =>
            {
                UnifonicResponseDto result=SendSmsMessage(sms.SMS.Recipient, sms.Body);
                if (result.Success)
                    sms.StatusId = (byte)SharedKernal.Enum.CommonEnum.SendingStatus.Success;
                else
                {
                    sms.StatusId = (byte)SharedKernal.Enum.CommonEnum.SendingStatus.Failed;
                    sms.Exception = result.Message;
                }
            });
            await UnitOfWork.Commit();
            _response.HandlePresenter(new ResultDto<bool>());
            return true;
        }

        /// <summary>
        ///  Send SMS message to only one recipient; you must have sufficient balance and an active package to send to your desired destination
        /// </summary>
        /// <param name="recipient">Destination mobile number, mobile number must be in international format without 00 or + Example: (4452023498)</param>
        /// <param name="body">Message body supports both English and Unicode characters, concatenated messages is supported</param>
        public virtual UnifonicResponseDto SendSmsMessage(string recipient, string body)
        { 

            var request = new RestRequest(Method.POST) { Resource = _SMSSettings.SendSMSUrl };

            request.AddParameter("SenderID", _SMSSettings.SenderID); 
            request.AddParameter("Recipient", recipient);
            request.AddParameter("Body", body);
            return Execute(request);
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
        /// <param name="request">The request to execute</param>
        public virtual UnifonicResponseDto Execute(IRestRequest request)
        {
            request.OnBeforeDeserialization = resp =>
            {
                if (((int)resp.StatusCode) >= 400)
                {
                    //RestSharp doesn't like data[]
                    resp.Content = resp.Content.Replace(",\"data\":[]", string.Empty);
                }
            };

            IRestResponse<UnifonicResponseDto> response = Client.Execute<UnifonicResponseDto>(request);

            return response?.Data;
        }
    }
}
