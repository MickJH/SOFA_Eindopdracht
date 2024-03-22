using AvansDevOps.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Notification.ExternalSystems
{
    public class SlackService : INotificationAdapter
    {
        public void SendNotification(string message, string user)
        {
            Console.WriteLine("[SLACK] \n \t" + user + "\n\t" + message);
        }
    }
}
