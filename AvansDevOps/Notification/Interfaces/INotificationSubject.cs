using AvansDevOps.Factory.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Notification.Interfaces
{
    public interface INotificationSubject
    {
        void RegisterObserver(INotificationObserver observer);
        void RemoveObserver(INotificationObserver observer);
        void NotifyObservers(string message, Type[]? userRoles = null);
    }
}
