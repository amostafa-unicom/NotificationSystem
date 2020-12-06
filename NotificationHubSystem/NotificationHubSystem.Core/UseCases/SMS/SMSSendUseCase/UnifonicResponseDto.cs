namespace NotificationHubSystem.Core.UseCases.SMS.SMSSendUseCase
{
    class UnifonicResponseDto
    {

        /// <summary>
        /// Result of calling API,True if success,otherwise False
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Error Message if any
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Error code if any
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// The type of object to create and populate with the returned data
        /// </summary>
        public object Data { get; set; }
    }
}
