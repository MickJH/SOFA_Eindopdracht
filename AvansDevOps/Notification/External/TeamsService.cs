using AvansDevOps.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Notification.ExternalSystems
{
    public class TeamsService : INotificationAdapter
    {
        public void SendNotification(string message, string user)
        {
            Console.WriteLine("[MICROSOFT TEAMS] \n \t" + user + "\n\t" + message);
        }
    }
}
