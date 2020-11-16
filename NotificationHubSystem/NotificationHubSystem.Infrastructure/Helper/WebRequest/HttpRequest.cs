using NotificationHubSystem.Core.DTOs.WebRequest;
using NotificationHubSystem.Core.Interfaces.Helper;
using NotificationHubSystem.SharedKernal.AppConfiguration.Serialization;
using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Helper;
using NotificationHubSystem.SharedKernal.Helper.SystemLogger;
using NotificationHubSystem.SharedKernal.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NotificationHubSystem.Infrastructure.Helper
{
    internal class HttpRequest : IHttpRequest
    {
        #region Properties
        protected ILogger Logger { get; }
        protected AppSettings AppSettings { get; }
        #endregion

        #region Constructor
        public HttpRequest(AppSettings appSettings, ILogger logger)
        {
            AppSettings = appSettings;
            Logger = logger;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Request URL [GET]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">Target url.</param>
        /// <returns>HTTPResponseDTO<T></returns>
        public HTTPResponseDTO<T> Get<T>(string url, Dictionary<string, string> headers = default) where T : class
        {
            #region Declare return type with initial value
            HTTPResponseDTO<T> response = new HTTPResponseDTO<T>();
            string referenceNo = Guid.NewGuid().ToString();
            #endregion
            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    #region Create Request
                    HttpWebRequest httpWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
                    httpWebRequest.Timeout = AppSettings.HttpRequestTimeout;
                    httpWebRequest.Method = HttpEnum.HttpMethod.Get.GetDescription();
                    httpWebRequest.ContentType = HttpEnum.HttpContentType.JSON.GetDescription();
                    httpWebRequest.Accept = HttpEnum.HttpContentType.JSON.GetDescription();
                    #endregion

                    #region Append Headers
                    if (headers?.Any() ?? default)
                    {
                        foreach (KeyValuePair<string, string> item in headers)
                        {
                            httpWebRequest.Headers.Add(item.Key, item.Value);
                        }
                    }
                    #endregion

                    #region Ignore SSL certificate validation
                    if (AppSettings.IgnoreSSL)
                    {
                        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    }
                    #endregion

                    #region Get Response
                    HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse != null)
                    {
                        string content = string.Empty;
                        using StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
                        content = streamReader.ReadToEnd();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            response = new HTTPResponseDTO<T>()
                            {
                                HttpStatusCode = httpResponse.StatusCode,
                                Body = JsonHandler.Deserialize<T>(content)
                            };
                        }
                    }
                    #endregion 
                }
            }
            catch (WebException webex)
            {
                response = WebExceptionHandler<T>(webex, referenceNo);
            }
            catch (Exception exception)
            {
                Logger.WriteLog(logType: CommonEnum.LogLevelEnum.Error, methodBase: System.Reflection.MethodBase.GetCurrentMethod(), referenceNo: referenceNo, exception: exception);
            }
            return response;
        }

        /// <summary>
        /// Request URL [POST]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">Target url.</param>
        /// <param name="obj">posted object.</param>
        /// <returns>HTTPResponseDTO<T></returns>
        public HTTPResponseDTO<T> Post<T>(string url, object obj, Dictionary<string, string> headers = default) where T : class
        {
            #region Declare return type with initial value
            HTTPResponseDTO<T> response = new HTTPResponseDTO<T>();
            string referenceNo = Guid.NewGuid().ToString();
            #endregion
            try
            {
                if (!string.IsNullOrWhiteSpace(url) && obj != null)
                {
                    #region Create Request
                    HttpWebRequest httpWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
                    httpWebRequest.Timeout = AppSettings.HttpRequestTimeout;
                    httpWebRequest.Method = HttpEnum.HttpMethod.Post.GetDescription();
                    httpWebRequest.ContentType = HttpEnum.HttpContentType.JSON.GetDescription();
                    httpWebRequest.Accept = HttpEnum.HttpContentType.JSON.GetDescription();
                    httpWebRequest.ContentLength = Encoding.UTF8.GetBytes(JsonHandler.Serialize(obj)).Length;
                    #endregion

                    #region Append Headers
                    if (headers?.Any() ?? default)
                    {
                        foreach (KeyValuePair<string, string> item in headers)
                        {
                            httpWebRequest.Headers.Add(item.Key, item.Value);
                        }
                    }
                    #endregion

                    #region Add To Request
                    using StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                    if (obj != null)
                        streamWriter.Write(JsonHandler.Serialize(obj));
                    streamWriter.Flush();
                    streamWriter.Close();
                    #endregion

                    #region Ignore SSL certificate validation
                    if (AppSettings.IgnoreSSL)
                    {
                        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    }
                    #endregion

                    #region Get Response
                    HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse != null)
                    {
                        string content = string.Empty;
                        using StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
                        content = streamReader.ReadToEnd();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            response = new HTTPResponseDTO<T>()
                            {
                                HttpStatusCode = httpResponse.StatusCode,
                                Body = JsonHandler.Deserialize<T>(content)
                            };
                        }
                    }
                    #endregion
                }
            }
            catch (WebException webex)
            {
                response = WebExceptionHandler<T>(webex, referenceNo);
            }
            catch (Exception exception)
            {
                Logger.WriteLog(logType: CommonEnum.LogLevelEnum.Error, methodBase: System.Reflection.MethodBase.GetCurrentMethod(), referenceNo: referenceNo, exception: exception);
            }
            return response;
        }

        /// <summary>
        /// Request URL [GET] in asynchronous way.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">Target url.</param>
        /// <returns>HTTPResponseDTO<T></returns>
        public async Task<HTTPResponseDTO<T>> GetAsync<T>(string url, Dictionary<string, string> headers = default) where T : class
        {
            #region Declare return type with initial value
            HTTPResponseDTO<T> response = new HTTPResponseDTO<T>();
            string referenceNo = Guid.NewGuid().ToString();
            #endregion
            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    #region Create Request
                    HttpWebRequest httpWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
                    httpWebRequest.Timeout = AppSettings.HttpRequestTimeout;
                    httpWebRequest.Method = HttpEnum.HttpMethod.Get.GetDescription();
                    httpWebRequest.ContentType = HttpEnum.HttpContentType.JSON.GetDescription();
                    httpWebRequest.Accept = HttpEnum.HttpContentType.JSON.GetDescription();
                    #endregion

                    #region Append Headers
                    if (headers?.Any() ?? default)
                    {
                        foreach (KeyValuePair<string, string> item in headers)
                        {
                            httpWebRequest.Headers.Add(item.Key, item.Value);
                        }
                    }
                    #endregion

                    #region Ignore SSL certificate validation
                    if (AppSettings.IgnoreSSL)
                    {
                        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    }
                    #endregion

                    #region Get Response
                    HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse != null)
                    {
                        string content = string.Empty;
                        using StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
                        content = await streamReader.ReadToEndAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            response = new HTTPResponseDTO<T>()
                            {
                                HttpStatusCode = httpResponse.StatusCode,
                                Body = JsonHandler.Deserialize<T>(content)
                            };
                        }
                    }
                    #endregion
                }
            }
            catch (WebException webex)
            {
                response = WebExceptionHandler<T>(webex, referenceNo);
            }
            catch (Exception exception)
            {
                Logger.WriteLog(logType: CommonEnum.LogLevelEnum.Error, methodBase: System.Reflection.MethodBase.GetCurrentMethod(), referenceNo: referenceNo, exception: exception);
            }
            return response;
        }

        /// <summary>
        /// Request URL [POST] in asynchronous way.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">Target url.</param>
        /// <param name="obj">posted object.</param>
        /// <returns>HTTPResponseDTO<T></returns>
        public async Task<HTTPResponseDTO<T>> PostAsync<T>(string url, object obj, Dictionary<string, string> headers = default) where T : class
        {
            #region Declare return type with initial value
            HTTPResponseDTO<T> response = new HTTPResponseDTO<T>();
            string referenceNo = Guid.NewGuid().ToString();
            #endregion
            try
            {
                if (!string.IsNullOrWhiteSpace(url) && obj != null)
                {
                    #region Create Request
                    HttpWebRequest httpWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
                    httpWebRequest.Timeout = AppSettings.HttpRequestTimeout;
                    httpWebRequest.Method = HttpEnum.HttpMethod.Post.GetDescription();
                    httpWebRequest.ContentType = HttpEnum.HttpContentType.JSON.GetDescription();
                    httpWebRequest.Accept = HttpEnum.HttpContentType.JSON.GetDescription();
                    httpWebRequest.ContentLength = Encoding.UTF8.GetBytes(JsonHandler.Serialize(obj)).Length;
                    #endregion

                    #region Append Headers
                    if (headers?.Any() ?? default)
                    {
                        foreach (KeyValuePair<string, string> item in headers)
                        {
                            httpWebRequest.Headers.Add(item.Key, item.Value);
                        }
                    }
                    #endregion

                    #region Add To Request
                    using StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                    if (obj != null)
                        await streamWriter.WriteAsync(JsonHandler.Serialize(obj));
                    streamWriter.Flush();
                    streamWriter.Close();
                    #endregion

                    #region Ignore SSL certificate validation
                    if (AppSettings.IgnoreSSL)
                    {
                        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    }
                    #endregion

                    #region Get Response
                    HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (httpResponse != null)
                    {
                        string content = string.Empty;
                        using StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
                        content = streamReader.ReadToEnd();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            response = new HTTPResponseDTO<T>()
                            {
                                HttpStatusCode = httpResponse.StatusCode,
                                Body = JsonHandler.Deserialize<T>(content)
                            };
                        }
                    }
                    #endregion
                }
            }
            catch (WebException webex)
            {
                response = WebExceptionHandler<T>(webex, referenceNo);
            }
            catch (Exception exception)
            {
                Logger.WriteLog(logType: CommonEnum.LogLevelEnum.Error, methodBase: System.Reflection.MethodBase.GetCurrentMethod(), referenceNo: referenceNo, exception: exception);
            }
            return response;
        }
        #endregion

        #region Private - Methods
        private HTTPResponseDTO<T> WebExceptionHandler<T>(WebException webex, string referenceNo) where T : class
        {
            HTTPResponseDTO<T> response = null;
            if (webex.Response != null)
            {
                WebResponse errResp = webex.Response;
                HttpWebResponse resp = (HttpWebResponse)webex.Response;
                using Stream respStream = errResp.GetResponseStream();
                if (resp.StatusCode == HttpStatusCode.BadRequest)
                {
                    string content = new StreamReader(respStream).ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        response = new HTTPResponseDTO<T>()
                        {
                            HttpStatusCode = resp.StatusCode,
                            Body = JsonHandler.Deserialize<T>(content)
                        };
                    }
                    else
                    {
                        Logger.WriteLog(logType: CommonEnum.LogLevelEnum.Error, methodBase: System.Reflection.MethodBase.GetCurrentMethod(), referenceNo: referenceNo, exception: webex);
                    }
                }
                else
                {
                    Logger.WriteLog(logType: CommonEnum.LogLevelEnum.Error, methodBase: System.Reflection.MethodBase.GetCurrentMethod(), referenceNo: referenceNo, message: new StreamReader(respStream).ReadToEnd(), exception: webex);
                }
            }
            else
            {
                Logger.WriteLog(logType: CommonEnum.LogLevelEnum.Error, methodBase: System.Reflection.MethodBase.GetCurrentMethod(), referenceNo: referenceNo, exception: webex);
            }
            return response;
        }
        #endregion
    }
}
