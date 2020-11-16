using NotificationHubSystem.SharedKernal.AppConfiguration.Handler;
using Microsoft.AspNetCore.Builder;

namespace NotificationHubSystem.SharedKernal.AppConfiguration.Middleware
{
    public static class MiddlewareRegister
    {
        public static void UseAppMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestLocalizationMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
