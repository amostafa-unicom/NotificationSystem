using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NotificationHubSystem.SharedKernal.ResourcesReader.Message;
using NotificationHubSystem.SharedKernal.Settings;

namespace NotificationHubSystem.SharedKernal.APIConfiguration.Base
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        #region Properties
        protected IMessageResourceReader MessageResource { get; }
        #endregion

        #region Constructor
        public BaseValidator()
        {
            MessageResource = Helper.AutoFacHelper.Container.GetRequiredService<IMessageResourceReader>();
        }
        #endregion
    }
}
