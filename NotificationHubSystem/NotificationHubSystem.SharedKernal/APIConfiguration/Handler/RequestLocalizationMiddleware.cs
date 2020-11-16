using NotificationHubSystem.SharedKernal.Enum;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using NotificationHubSystem.SharedKernal.ResourcesReader.Message;

namespace NotificationHubSystem.SharedKernal.AppConfiguration.Handler
{
    public class RequestLocalizationMiddleware
    {
        private RequestDelegate Next { get; }
        public RequestLocalizationMiddleware(RequestDelegate next)
        {
            Next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            SystemCulture.Language = System.Enum.TryParse(context.Request.GetTypedHeaders().AcceptLanguage.Where(i => !int.TryParse(i.Value, out int val)).FirstOrDefault()?.Value.ToString().ToLower(), out ResourceEnum.Language lang) ? lang : ResourceEnum.Language.en;
            await Next(context);
        }
    }
}
