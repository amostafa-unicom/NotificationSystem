namespace NotificationHubSystem.SharedKernal.ResourcesReader.Message
{
    public interface IMessageResourceReader
    {
        string GetMessage(Enum.HttpEnum.ResponseStatus responseStatus);
    }
}
