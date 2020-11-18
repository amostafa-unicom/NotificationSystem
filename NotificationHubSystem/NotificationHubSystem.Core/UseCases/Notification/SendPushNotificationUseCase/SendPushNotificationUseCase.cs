using CorePush.Google;
using Newtonsoft.Json;
using NotificationHubSystem.Core.Base;
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
        public async Task<bool> HandleUseCase(List<PushNotification> _request, IOutputPort<ResultDto<bool>> _response)
        {
            if (_request?.Any() ?? default)
            {
                for (int i = 0; i < _request.Count; i++)
                {
                    FirebaseNotificationDTO firebaseDto = new FirebaseNotificationDTO()
                    {
                        Data = _request[i].SendData !=default? JsonConvert.DeserializeObject<object>(_request[i].SendData):default,
                        RegistrationIds = new List<string> { _request[i].NotificationTokenId },
                        Notification = new Notification()
                        {
                            Body = _request[i].Body,
                            Title = _request[i].Title,
                            Sound = string.Empty
                        },
                    };

                    HTTPResponseJsonDTO<string> result = await FirebaseRequest<string, FirebaseNotificationDTO>(firebaseDto);

                    #region Update Notification Status
                    Entities.NotificationBase NotificationBase = NotificationBaseRepository.GetWhere(x => x.Id == _request[i].NotificationId).FirstOrDefault();
                    NotificationBase.StatusId = (byte)result.Status;
                    NotificationBase.Exception = result.Body.ToString();
                    #endregion
                }
                await UnitOfWork.Commit();

                _response.HandlePresenter(new ResultDto<bool>(true));
            }else
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
        public async Task<HTTPResponseJsonDTO<T>> FirebaseRequest<T, K>(K content)
        {
            #region Declare return type with initial value
            HTTPResponseJsonDTO<T> response = new HTTPResponseJsonDTO<T>();
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
                        response = new HTTPResponseJsonDTO<T>()
                        {
                            HttpStatusCode = tResponse.StatusCode,
                            Status = SharedKernal.Enum.CommonEnum.SendingStatus.Success,
                            Body = JsonConvert.DeserializeObject<T>(tReader.ReadToEnd())
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
                        response = new HTTPResponseJsonDTO<T>()
                        {
                            HttpStatusCode = resp.StatusCode,
                            Status = SharedKernal.Enum.CommonEnum.SendingStatus.Failed,
                            Body = JsonConvert.DeserializeObject<T>(responseContent)
                        };
                    }
                }
            }
            catch (Exception exception)
            {
                response = new HTTPResponseJsonDTO<T>()
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Status = SharedKernal.Enum.CommonEnum.SendingStatus.Failed,
                };
            }
            return response;
        }
    }

    internal class HTTPResponseJsonDTO<T>
    {
        public HTTPResponseJsonDTO()
        {
        }

        public HttpStatusCode HttpStatusCode { get; set; }
        public SharedKernal.Enum.CommonEnum.SendingStatus Status { get; set; }
        public T Body { get; set; }
    }
}
