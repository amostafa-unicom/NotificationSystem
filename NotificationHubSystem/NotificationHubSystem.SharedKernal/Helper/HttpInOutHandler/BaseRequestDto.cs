using FluentValidation;
using NotificationHubSystem.SharedKernal.Enum;

namespace NotificationHubSystem.SharedKernal.Helper.HttpInOutHandler
{
    /// <summary>
    /// API request object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRequestDto<T>
    {
        /// <summary>
        /// End-point input.
        /// </summary>
        public T Data { get; set; }
    }
    public class BaseRequestValidator<T> : APIConfiguration.Base.BaseValidator<BaseRequestDto<T>>
    {
        public BaseRequestValidator() : base()
        {
            RuleFor(obj => obj.Data).NotNull().WithMessage(MessageResource.GetMessage(HttpEnum.ResponseStatus.InvalidData));
        }
    }
}
