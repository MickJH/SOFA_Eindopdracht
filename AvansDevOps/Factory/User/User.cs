using AvansDevOps.Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AvansDevOps.Factory.User
{
    public abstract class User : INotificationObserver
    {
        public string Name { get; set; }

        public void Notify(string message)
        {
            Console.WriteLine("User: " + message);
        }
    }
}
