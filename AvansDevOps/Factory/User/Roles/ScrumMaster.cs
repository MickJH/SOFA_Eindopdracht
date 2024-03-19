using AvansDevOps.Factory.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Factory.User.Roles
{
    public class ScrumMaster : User, IUserActions
    {
        public void ManageSprintBacklogs() => Console.WriteLine("Managing sprint backlogs.");
        public void AssignActivitiesToDevelopers() => Console.WriteLine("Assigning activities to developers.");
        public void FacilitateScrumProcess() => Console.WriteLine("Facilitating the Scrum process.");
        public void GenerateSprintReports() => Console.WriteLine("Generating sprint reports.");
        public void CommunicateWithTeamAndStakeholders() => Console.WriteLine("Communicating with team members and stakeholders.");

        // Not relevant for Scrum Masters
        public void ManageBacklogItems() => Console.WriteLine("Not allowed for Scrum Master.");
        public void AssignBacklogItemsToSprints() => Console.WriteLine("Not allowed for Scrum Master.");
        public void DefineAcceptanceCriteria() => Console.WriteLine("Not allowed for Scrum Master.");
        public void PerformAssignedActivities() => Console.WriteLine("Not allowed for Scrum Master.");
        public void AccessAndManageCodeRepository() => Console.WriteLine("Not allowed for Scrum Master.");
        public void ContributeToProjectProgress() => Console.WriteLine("Not allowed for Scrum Master.");
        public void ParticipateInSprints() => Console.WriteLine("Not allowed for Scrum Master, except as a facilitator.");
    }

}
