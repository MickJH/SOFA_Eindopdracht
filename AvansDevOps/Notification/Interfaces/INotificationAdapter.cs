using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Notification.Interfaces
{
    public interface INotificationAdapter
    {
        public void SendNotification(string message, string user);
    }
}
