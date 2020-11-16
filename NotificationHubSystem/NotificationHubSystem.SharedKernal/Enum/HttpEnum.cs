using NotificationHubSystem.SharedKernal.Helper;

namespace NotificationHubSystem.SharedKernal.Enum
{
    public class HttpEnum
    {
        public enum ResponseStatus
        {
            NullValue = -82,
            EmptyData = -81,
            InvalidData = -80,

            ItemAlreadyExist = -6,
            NoChanges = -5,
            LinkedWithAnotherEntity = -4,
            FailedToDelete = -3,
            FailedToUpdate = -2,
            FailedToInsert = -1,

            Success = 0,
            GeneralError = 1,
            InvalidLanguage = 2,
            NotDataFound = 3,
            FailedToInsertDataIsExists = 4,
            InvalidUserTaskId = 5,
            InvalidPercentage = 6,
            InvalidExpirationDate = 7
        }
        public enum HttpMethod
        {
            [EnumMessage("GET")]
            Get,
            [EnumMessage("POST")]
            Post,
            [EnumMessage("PUT")]
            Put,
            [EnumMessage("DELETE")]
            Delete
        }
        public enum HttpContentType
        {
            [EnumMessage("text/plain")]
            Text,
            [EnumMessage("text/html")]
            HTML,
            [EnumMessage("application/json")]
            JSON,
            [EnumMessage("application/javascript")]
            JavaScript,
            [EnumMessage("application/xml")]
            XML
        }
    }
}
