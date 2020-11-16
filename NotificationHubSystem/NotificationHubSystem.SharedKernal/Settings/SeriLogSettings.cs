using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using NotificationHubSystem.SharedKernal.Enum;

namespace NotificationHubSystem.SharedKernal.Settings
{
    [DataContract(Name = "SeriLog")]
    public class SeriLogSettings
    {
        [JsonProperty("LogLevel")]
        public int LogLevel { get; set; } = (int)(CommonEnum.LogLevelEnum.Debug & CommonEnum.LogLevelEnum.Information & CommonEnum.LogLevelEnum.Warning & CommonEnum.LogLevelEnum.Error & CommonEnum.LogLevelEnum.Fatal);
        [JsonProperty("RollingInterval")]
        public int RollingInterval { get; set; } = (int)Serilog.RollingInterval.Hour;
        [JsonProperty("FilePath")]
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Logs\\");
        [JsonProperty("SeqURI")]
        public string SeqURI { get; set; } = string.Empty;
    }
}
