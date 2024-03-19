using AvansDevOps.Factory.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Factory.User.Roles
{
    public class ProductOwner : IRole
    {
        public void PerformRoleDuties()
        {
            Console.WriteLine( "All the actions a Product Owner can perform: " + "Managing backlog items, " + "Assigning backlog items to sprints, " + "Defining acceptance criteria, " + "Generating sprint reports.");
        }
    }

}
