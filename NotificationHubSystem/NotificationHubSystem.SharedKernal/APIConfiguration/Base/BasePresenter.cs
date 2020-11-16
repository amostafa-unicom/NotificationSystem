using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.AppConfiguration.Serialization;
using System.Net;
using System;
using System.Threading.Tasks;
using NotificationHubSystem.SharedKernal.Helper.HttpInOutHandler;
using FluentValidation;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;

namespace NotificationHubSystem.SharedKernal.AppConfiguration.Base
{
    public sealed class BasePresenter
    {
        #region Properties
        public JsonContentResult ContentResult { get; }
        #endregion
        #region Constructor
        public BasePresenter()
        {
            ContentResult = new JsonContentResult();
        }
        #endregion
        #region Methods
        public async Task<JsonContentResult> Handle<TRequest, TResponse>(Func<BaseRequestDto<TRequest>, Task<BaseResponseDto<TResponse>>> useCaseRequest, BaseRequestDto<TRequest> request)
        {
            ValidationResult validationResult = ValidateRequestDto(request);
            BaseResponseDto<TResponse> response = new BaseResponseDto<TResponse>();
            if (validationResult.IsValid)
            {
                response = await useCaseRequest.Invoke(request);
                if (response != null)
                {
                    ContentResult.StatusCode = (int)HttpStatusCode.OK;
                    ContentResult.Content = JsonHandler.Serialize(response);
                }
            }
            else
            {
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                validationResult.Errors.GroupBy(p => p.PropertyName).ToList().ForEach(item => dict.Add(item.Key, item.Select(e => e.ErrorMessage).ToList()));
                response.ReturnError(HttpEnum.ResponseStatus.InvalidData, HttpEnum.ResponseStatus.InvalidData.ToString(), Guid.NewGuid().ToString(), propErrors: dict);
            }
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonHandler.Serialize(response);
            return ContentResult;
        }
        #endregion
        #region Private - Methods
        /// <summary>
        /// Validate API request input dto.
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request">request input.</param>
        /// <returns>ValidationResult</returns>
        private ValidationResult ValidateRequestDto<TRequest>(BaseRequestDto<TRequest> request)
        {
            ValidationResult results = new ValidationResult();
            IValidator<BaseRequestDto<TRequest>> baseValidator = new BaseRequestValidator<TRequest>();
            results = baseValidator.Validate(request);
            if (results.IsValid)
            {
                Type customValidator = System.Reflection.Assembly.Load(typeof(TRequest).Assembly.GetName()).GetTypes().Where(x => x.IsSubclassOf(typeof(AbstractValidator<TRequest>))).FirstOrDefault();
                if (customValidator != null)
                {
                    IValidator<TRequest> innerDataValidator = (IValidator<TRequest>)Activator.CreateInstance(customValidator);
                    results = innerDataValidator.Validate(request.Data);
                }
            }
            return results;
        }
        #endregion
    }
}
