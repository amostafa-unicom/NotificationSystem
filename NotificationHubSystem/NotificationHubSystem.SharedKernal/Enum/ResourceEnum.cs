using NotificationHubSystem.SharedKernal.Helper;

namespace NotificationHubSystem.SharedKernal.Enum
{
    /// <summary>
    /// Resources enum
    /// </summary>
    public sealed class ResourceEnum
    {
        /// <summary>
        /// Localization Type used to identify whether the resource type.
        /// </summary>
        public enum LocalizationType
        {
            [EnumMessage("Controls")]
            Controls = 1,
            [EnumMessage("Actions")]
            Actions = 2,
            [EnumMessage("ValidationMessage")]
            ValidationMessage = 3,
            [EnumMessage("Messages_{0}")]
            Message = 4,
            [EnumMessage("IntegrationMessage")]
            IntegrationMessage = 5
        }
        /// <summary>
        /// AppLanguage used to define the api response message language.
        /// </summary>
        public enum Language
        {
            [EnumMessage("en")]
            en,
            [EnumMessage("ar")]
            ar
        }
    }
}
