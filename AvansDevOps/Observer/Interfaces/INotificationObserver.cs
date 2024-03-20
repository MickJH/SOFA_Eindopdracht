using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer.Interfaces
{
    public interface INotificationObserver
    {
        void Notify(string message);
    }
}
