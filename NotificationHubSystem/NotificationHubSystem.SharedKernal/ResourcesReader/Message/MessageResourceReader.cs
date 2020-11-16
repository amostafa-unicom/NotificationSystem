using NotificationHubSystem.SharedKernal.Enum;

namespace NotificationHubSystem.SharedKernal.ResourcesReader.Message
{
    internal class MessageResourceReader : BaseFileReader, IMessageResourceReader
    {
        public MessageResourceReader() : base(ResourceEnum.LocalizationType.Message)
        {
        }
        public string GetMessage(HttpEnum.ResponseStatus responseStatus) => GetKeyValue(responseStatus.ToString());
    }
}
