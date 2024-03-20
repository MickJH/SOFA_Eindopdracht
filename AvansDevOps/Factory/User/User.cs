using AvansDevOps.Factory.User.Interfaces;
using AvansDevOps.Observer.Interfaces;
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

        public User(string Name) { this.Name = Name; }

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
            Console.WriteLine(Role!.GetType().Name + ": " + message);
        }
    }

}
