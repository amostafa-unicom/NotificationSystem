namespace NotificationHubSystem.SharedKernal.Helper
{
    /// <summary>
    /// Enum message used to adding a description to the enum value.
    /// </summary>
    internal sealed class EnumMessage : System.Attribute
    {
        /// <summary>
        /// Enum value message.
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// EnumMessage constructor to add the description to the enum value.
        /// </summary>
        /// <param name="message"></param>
        public EnumMessage(string message) => Message = message;
    }
}
