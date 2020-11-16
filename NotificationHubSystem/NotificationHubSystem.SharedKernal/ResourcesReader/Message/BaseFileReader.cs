using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Helper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NotificationHubSystem.SharedKernal.ResourcesReader.Message
{
    public static class SystemCulture
    {
        public static ResourceEnum.Language Language { get; set; }
    }
    public abstract class BaseFileReader
    {
        #region Vars
        private Dictionary<string, string> ResourceData { get; set; }
        private ResourceEnum.LocalizationType LocalizationType { get; set; }
        #endregion
        #region Constructor
        public BaseFileReader(ResourceEnum.LocalizationType localizationType)
        {
            this.LocalizationType = localizationType;
        }
        #endregion
        #region Get Data
        protected string GetKeyValue(string key)
        {
            return LoadData(this.LocalizationType) ? ResourceData[key] : key;
        }
        #endregion
        #region Load Data
        private bool LoadData(ResourceEnum.LocalizationType localizationType)
        {
            string fileName = string.Format(localizationType.GetDescription(), SystemCulture.Language.GetDescription());
            string rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            ResourceData = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(Path.Combine(rootDir, "ResourceFiles", $"{fileName}.json")));
            return ResourceData?.Any() ?? default;
        }
        #endregion
    }
}
