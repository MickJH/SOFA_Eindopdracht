using AvansDevOps.Factory.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Factory.User.Roles
{
    public class Developer : IRole
    {
        public void PerformRoleDuties()
        {
            Console.WriteLine("All the actions a Developer can perform: " + "Performing assigned activities, " + "Accessing and managing code repository, " + "Contributing to project progress, " + "Participating in sprints.");
        }
    }

}
