using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationHubSystem.SharedKernal.AppConfiguration.Base
{
    public abstract class BaseController : ControllerBase
    {
        #region Properties
        public BasePresenter Presenter { get; set; }
        #endregion
    }
}
