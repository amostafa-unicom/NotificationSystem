using Newtonsoft.Json;
using NotificationHubSystem.Core.Base;
using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.Core.Interfaces.Repository.Custom;
using NotificationHubSystem.SharedKernal;
using NotificationHubSystem.SharedKernal.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NotificationHubSystem.Core.UseCases.Notification.SendPushNotificationUseCase
{
    internal class SendPushNotificationUseCase : BaseUseCase, ISendPushNotificationUseCase
    {
        public INotificationBaseRepository NotificationBaseRepository { get; set; }
        private readonly PushNotificationSettings pushNotificationSettings;
        public SendPushNotificationUseCase(PushNotificationSettings _pushNotificationSettings)
        {
            pushNotificationSettings = _pushNotificationSettings;
        }
        public async Task<bool> HandleUseCase(List<NotificationBase> _request, IOutputPort<ResultDto<bool>> _response)
        {
            if (_request?.Any() ?? default)
            {

                for (int i = 0; i < _request.Count; i++)
                {
                    FirebaseNotificationDTO firebaseDto = new FirebaseNotificationDTO()
                    {
                        Data = _request[i].PushNotification.SendData != default ? JsonConvert.DeserializeObject<object>(_request[i].PushNotification.SendData) : default,
                        RegistrationIds = new List<string> { _request[i].PushNotification.NotificationTokenId },
                        Notification = new Notification()
                        {
                            Body = _request[i].Body,
                            Title = _request[i].PushNotification.Title,
                            Sound = string.Empty
                        },
                    };

                    HTTPResponse result = await FirebaseRequest<FirebaseNotificationDTO>(firebaseDto);

                    #region Update Notification Status

                    _request[i].StatusId = (byte)result.Status;
                    _request[i].Exception = result.Body.ToString();
                    #endregion
                }
                await UnitOfWork.Commit();

                _response.HandlePresenter(new ResultDto<bool>(true));
            }
            else
                _response.HandlePresenter(new ResultDto<bool>(default));
            return true;
        }



        /// <summary>
        /// Request URL [POST] for firebase.
        /// </summary>
        /// <typeparam name="T">HTTPResponseJsonDTO body type</typeparam>
        /// <typeparam name="K">content type</typeparam>
        /// <param name="content">posted object.</param>
        /// <returns>HTTPResponseJsonDTO<T></returns>
        public async Task<HTTPResponse> FirebaseRequest<K>(K content)
        {
            #region Declare return type with initial value
            HTTPResponse response = new HTTPResponse();
            #endregion
            try
            {
                #region Create Request Object
                HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(pushNotificationSettings.FirebaseUrl);
                byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(content));
                request.Method = "POST";
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;
                request.Timeout = pushNotificationSettings.RequestTimeout;
                request.Headers.Add($"Authorization: key={pushNotificationSettings.AuthKey}");
                request.Headers.Add($"Sender: id={pushNotificationSettings.SenderId}");
                #endregion
                #region Read Response
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using HttpWebResponse tResponse = (HttpWebResponse)await request.GetResponseAsync();
                    if (tResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using Stream dataStreamResponse = tResponse.GetResponseStream();
                        using StreamReader tReader = new StreamReader(dataStreamResponse);
                        response = new HTTPResponse()
                        {
                            HttpStatusCode = tResponse.StatusCode,
                            Status = SharedKernal.Enum.CommonEnum.SendingStatus.Success,
                            Body = tReader.ReadToEnd()
                        };
                    }
                }
                #endregion
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                HttpWebResponse resp = (HttpWebResponse)webex.Response;
                using Stream respStream = errResp.GetResponseStream();
                if (resp.StatusCode == HttpStatusCode.BadRequest)
                {
                    string responseContent = new StreamReader(respStream).ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(responseContent))
                    {
                        response = new HTTPResponse()
                        {
                            HttpStatusCode = resp.StatusCode,
                            Status = SharedKernal.Enum.CommonEnum.SendingStatus.Failed,
                            Body = responseContent
                        };
                    }
                }
            }
            catch (Exception exception)
            {
                response = new HTTPResponse()
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Status = SharedKernal.Enum.CommonEnum.SendingStatus.Failed,
                };
            }
            return response;
        }
    }
}
