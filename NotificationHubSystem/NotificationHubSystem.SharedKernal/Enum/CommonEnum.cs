using NotificationHubSystem.SharedKernal.Helper;

namespace NotificationHubSystem.SharedKernal.Enum
{
    /// <summary>
    /// Generic enums
    /// </summary>
    public sealed class CommonEnum
    {
        /// <summary>
        /// Active status used to identify whether the active or not active.
        /// </summary>
        public enum EnvironmentType
        {
            [EnumMessage("Mobile")]
            Mobile = 1,
            [EnumMessage("WebSite")]
            WebSite = 2,
            [EnumMessage("Callcenter app")]
            CallcenterApp = 2
        }

        /// <summary>
        /// Active status used to identify whether the active or not active.
        /// </summary>
        public enum ActiveStatus
        {
            [EnumMessage("InActive")]
            InActive = 1,
            [EnumMessage("Active")]
            Active = 2
        }
        /// <summary>
        /// Delete status used to identify whether the deleted or not deleted.
        /// </summary>
        public enum DeleteStatus
        {
            [EnumMessage("Not Deleted")]
            NotDeleted = 0,
            [EnumMessage("Deleted")]
            Deleted = 1
        }
        /// <summary>
        /// Sort Direction used to identify whether the pagination will be ordered ascending or descending.
        /// </summary>
        public enum SortDirection
        {
            [EnumMessage("ASC")]
            Ascending = 0,
            [EnumMessage("DESC")]
            Descending = 1
        }
        /// <summary>
        /// GeoDistanceUnit used to define the distance unit
        /// </summary>
        public enum GeoDistanceUnit
        {
            Miles,
            KiloMeters,
            NauticalMiles
        }
        /// <summary>
        /// Log types used to writting a specific log.
        /// LogLevel value will be:
        ///  1 => [Debug]
        ///  2 => [Information]
        ///  3 => [Debug & Information]
        ///  4 => [Warning]
        ///  5 => [Warning & Debug]
        ///  6 => [Warning & Information]
        ///  7 => [Warning & Information & Debug]
        ///  8 => [Error]
        ///  9 => [Error & Debug]
        /// 10 => [Error & Information]
        /// 11 => [Error & Information & Debug]
        /// 12 => [Error & Warning]
        /// 13 => [Error & Warning & Debug]
        /// 14 => [Error & Warning & Information]
        /// 15 => [Error & Warning & Information & Debug]
        /// 16 => [Fatal]
        /// 17 => [Fatal & Debug]
        /// 18 => [Fatal & Information]
        /// 19 => [Fatal & Information & Debug]
        /// 20 => [Fatal & Warning]
        /// 21 => [Fatal & Warning & Debug]
        /// 22 => [Fatal & Warning & Information]
        /// 23 => [Fatal & Warning & Information & Debug]
        /// 24 => [Fatal & Error]
        /// 25 => [Fatal & Error & Debug]
        /// 26 => [Fatal & Error & Information]
        /// 27 => [Fatal & Error & Information & Debug]
        /// 28 => [Fatal & Error & Warning]
        /// 29 => [Fatal & Error & Warning & Debug]
        /// 30 => [Fatal & Error & Warning & Information]
        /// 31 => [Fatal & Error & Warning & Information & Debug]
        /// </summary>
        public enum LogLevelEnum
        {
            Debug = 1,
            Information = 2,
            Warning = 4,
            Error = 8,
            Fatal = 16
        }

        public enum SendingStatus
        {
            New=1,
            Success=2,
            Failed=3
        }
        public enum NotificationType
        {
            Mail = 1,
            PushNotification = 2,
            SMS = 3,
            RealTime=4
        }
    }
}
