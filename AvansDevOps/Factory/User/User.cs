using AvansDevOps.Factory.User.Interfaces;
using AvansDevOps.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AvansDevOps.Factory.User
{
    public class User : INotificationObserver
    {
        public string Name { get; set; }
        public IRole? Role { get; private set; }
        private readonly INotificationAdapter[] _notificationServices;

        public User(string Name, INotificationAdapter[] notificationServices)
        {
            this.Name = Name;
            this._notificationServices = notificationServices;
        }

        public void AssignRole(IRole role)
        {
            Role = role;
        }

        public void PerformRoleDuties()
        {
            Role?.PerformRoleDuties();
        }

        public void Notify(string message)
        {
            foreach (var service in _notificationServices)
            {
                service.SendNotification(message, this.Name);
            }
        }
    }

}
