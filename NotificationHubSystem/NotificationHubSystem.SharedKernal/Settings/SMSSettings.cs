using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationHubSystem.SharedKernal.Settings
{
    public class SMSSettings
    {
        public string AppSid { get; set; }
        public string SenderID { get; set; }
        public string UnifonicBaseUrl { get; set; }
        public string SendSMSUrl { get; set; }
    }
}
