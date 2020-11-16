using System;
using System.Collections.Generic;
using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.AppConfiguration.Serialization;

namespace NotificationHubSystem.SharedKernal.Helper.HttpInOutHandler
{
    /// <summary>
    /// API response object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponseDto<T>
    {
        #region Properties
        /// <summary>
        /// Http response result.
        /// </summary>
        public KeyValuePair<HttpEnum.ResponseStatus, string> Result { get; private set; }
        /// <summary>
        /// Http response message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Error reference no to catch the errors in logs.
        /// </summary>
        public string ReferenceNo { get; private set; }
        /// <summary>
        /// List of all errors.
        /// </summary>
        public List<string> Errors { get; private set; }
        /// <summary>
        /// List of all properties validation.
        /// </summary>
        public Dictionary<string, List<string>> PropErrors { get; private set; }
        /// <summary>
        /// Http response data.
        /// </summary>
        public T InnerData { get; private set; }
        #endregion
        #region Contructor
        public BaseResponseDto()
        {
            ReturnError(HttpEnum.ResponseStatus.GeneralError, HttpEnum.ResponseStatus.GeneralError.ToString());
        }
        public BaseResponseDto(HttpEnum.ResponseStatus resultStatus, string message)
        {
            ReturnError(resultStatus, message);
        }
        #endregion
        #region Methods
        public void ReturnSuccess(T data, HttpEnum.ResponseStatus resultStatus, string message)
        {
            Result = new KeyValuePair<HttpEnum.ResponseStatus, string>(resultStatus, resultStatus.ToString());
            Message = !string.IsNullOrWhiteSpace(message) ? message : resultStatus.ToString();
            InnerData = data;
            ReferenceNo = default;
            Errors = default;
            PropErrors = default;
        }
        public void ReturnError(HttpEnum.ResponseStatus resultStatus, string message, string referenceNo = default, List<string> errors = null, Dictionary<string, List<string>> propErrors = null)
        {
            Result = new KeyValuePair<HttpEnum.ResponseStatus, string>(resultStatus, resultStatus.ToString());
            Message = !string.IsNullOrWhiteSpace(message) ? message : resultStatus.ToString();
            ReferenceNo = !string.IsNullOrWhiteSpace(referenceNo) ? referenceNo : Guid.NewGuid().ToString();
            Errors = errors;
            PropErrors = propErrors;
            InnerData = default;
        }
        public override string ToString()
        {
            return JsonHandler.Serialize(this);
        }
        #endregion
    }
}
