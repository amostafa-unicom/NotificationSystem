using NotificationHubSystem.SharedKernal.AppConfiguration.Serialization;
using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Helper;
using NotificationHubSystem.SharedKernal.Helper.SystemLogger;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using NotificationHubSystem.SharedKernal.Helper.HttpInOutHandler;

namespace NotificationHubSystem.SharedKernal.AppConfiguration.Handler
{
    public class ExceptionMiddleware
    {
        private RequestDelegate Next { get; }
        private readonly ILogger _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            Next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string requestBody = string.Empty;
            try
            {
                context.Request.EnableBuffering();
                using (StreamReader reader = new StreamReader(context.Request.Body))
                {
                    requestBody = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;
                    await Next(context);
                }
            }
            catch (System.Exception ex)
            {
                string referenceNo = Guid.NewGuid().ToString();
                _logger.WriteLog(logType: CommonEnum.LogLevelEnum.Error, methodBase: System.Reflection.MethodBase.GetCurrentMethod(), referenceNo: referenceNo, exception: ex);
                _logger.WriteLog(logType: CommonEnum.LogLevelEnum.Information, methodBase: System.Reflection.MethodBase.GetCurrentMethod(), referenceNo: referenceNo, message: $"Reqeust body: {JsonHandler.Serialize(requestBody)}");
                HandleException(context, referenceNo);
            }
        }
        private void HandleException(HttpContext httpContext, string referenceNo)
        {
            BaseResponseDto<object> baseResponseDto = new BaseResponseDto<object>();
            Exception exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            CommonException customExcep = null;
            if (exception is ValidationException)
                customExcep = (ValidationException)exception;

            if (exception is PermissionException)
                customExcep = (PermissionException)exception;

            if (exception is BusinessException)
                customExcep = (BusinessException)exception;

            if (exception is RepositoryException)
                customExcep = (RepositoryException)exception;

            if (customExcep != null)
            {
                baseResponseDto.ReturnError(customExcep.Result, exception.Message, referenceNo, ((PermissionException)exception).Errors);
            }
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            httpContext.Response.WriteAsync(baseResponseDto.ToString());
        }
    }
}
