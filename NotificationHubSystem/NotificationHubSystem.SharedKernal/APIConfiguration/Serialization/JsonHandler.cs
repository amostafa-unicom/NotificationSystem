using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NotificationHubSystem.SharedKernal.AppConfiguration.Serialization
{
    public sealed class JsonHandler
    {
        private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        }
        public static T Deserialize<T>(string jsonObj) where T : class
        {
            return JsonConvert.DeserializeObject<T>(jsonObj, jsonSerializerSettings);
        }
    }
}
