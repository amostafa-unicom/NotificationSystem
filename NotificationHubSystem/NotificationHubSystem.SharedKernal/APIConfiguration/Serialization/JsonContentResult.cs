using Microsoft.AspNetCore.Mvc;

namespace NotificationHubSystem.SharedKernal.AppConfiguration.Serialization
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
