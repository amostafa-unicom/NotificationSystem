using NotificationHubSystem.SharedKernal.Enum;
using System;
using System.Reflection;
using System.Threading.Tasks;
using NotificationHubSystem.SharedKernal.Settings;
using Serilog;
using System.Text;

namespace NotificationHubSystem.SharedKernal.Helper.SystemLogger
{
    public interface ILogger
    {
        void WriteLog(CommonEnum.LogLevelEnum logType, MethodBase methodBase, string referenceNo = default, string message = default, Exception exception = null);
        Task WriteLogAsync(CommonEnum.LogLevelEnum logType, MethodBase methodBase, string referenceNo = default, string message = default, Exception exception = null);
    }
    internal class Logger : ILogger
    {
        #region Properties
        private SeriLogSettings _seriLogSettings { get; }
        #endregion
        #region Constructor
        public Logger(SeriLogSettings seriLogSettings)
        {
            _seriLogSettings = seriLogSettings;
            InitializeLogger();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Writting a log message in file.
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="message"></param>
        /// <param name="methodBase"></param>
        /// <param name="exception"></param>
        public void WriteLog(CommonEnum.LogLevelEnum logType, MethodBase methodBase, string referenceNo = null, string message = null, Exception exception = null)
        {
            string refNo = !string.IsNullOrWhiteSpace(referenceNo) ? referenceNo : Guid.NewGuid().ToString();
            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendLine($"Method: {methodBase.DeclaringType.FullName}.{methodBase.Name}");
            logMessage.AppendLine($"Issued Date: {DateTime.Now}");
            logMessage.AppendLine($"Reference No.: {refNo}");
            if (!string.IsNullOrWhiteSpace(message))
            {
                logMessage.AppendLine($"Message: {message}");
            }

            Array logLevelEnums = System.Enum.GetValues(typeof(CommonEnum.LogLevelEnum));
            CommonEnum.LogLevelEnum availableLogTypes = (CommonEnum.LogLevelEnum)_seriLogSettings.LogLevel;
            foreach (CommonEnum.LogLevelEnum item in logLevelEnums)
            {
                if ((availableLogTypes & item) == logType && System.Enum.TryParse(logType.ToString(), out Serilog.Events.LogEventLevel logLevel))
                    Log.Logger.Write(logLevel, exception, logMessage.ToString());
            }
        }
        /// <summary>
        /// Writting a log message in file async.
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="message"></param>
        /// <param name="methodBase"></param>
        /// <param name="exception"></param>
        public async Task WriteLogAsync(CommonEnum.LogLevelEnum logType, MethodBase methodBase, string referenceNo = null, string message = null, Exception exception = null)
        {
            await Task.Run(() => WriteLog(logType, methodBase, referenceNo, message, exception));
        }
        #endregion
        #region Private - Methods
        /// <summary>
        /// Initialize Logger
        /// </summary>
        /// <returns>ILog</returns>
        private void InitializeLogger()
        {
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration().MinimumLevel.Verbose().WriteTo.File($"{_seriLogSettings.FilePath}.txt", rollingInterval: (RollingInterval)_seriLogSettings.RollingInterval);
            if (!string.IsNullOrWhiteSpace(_seriLogSettings.SeqURI))
            {
                loggerConfiguration.WriteTo.Seq(_seriLogSettings.SeqURI, Serilog.Events.LogEventLevel.Verbose);
            }
            Log.Logger = loggerConfiguration.CreateLogger();
        }
        #endregion

    }
}
