using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class NotificationHelper
    {
        public delegate void Notify(object data);

        public event Notify OnNotificationReceived;

        public void SendNotification(object data)
        {
            OnNotificationReceived?.Invoke(data);
        }
    }
}
