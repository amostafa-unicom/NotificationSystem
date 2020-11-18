using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationHubSystem.SharedKernal.Settings
{
   public class PushNotificationSettings
    {
        public int RequestTimeout { get; set; }
        public string FirebaseUrl { get; set; }
        public string AuthKey { get; set; }
        public string SenderId { get; set; }
        public bool EnableSound { get; set; }
    }
}
