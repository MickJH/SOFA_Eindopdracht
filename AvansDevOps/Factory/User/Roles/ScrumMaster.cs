using AvansDevOps.Factory.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Factory.User.Roles
{
    public class ScrumMaster : IRole
    {
        public void PerformRoleDuties()
        {
            Console.WriteLine("All the actions a Scrum Master can perform: " + "Managing sprint backlogs, " + "Assigning activities to developers, " + "Facilitating the Scrum process, " + "Generating sprint reports, " + "Communicating with team members and stakeholders.");
        }
    }

}
