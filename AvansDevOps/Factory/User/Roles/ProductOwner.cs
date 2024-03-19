using AvansDevOps.Factory.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Factory.User.Roles
{
    public class ProductOwner : User, IUserActions
    {
        public void ManageBacklogItems() => Console.WriteLine("Managing backlog items.");
        public void AssignBacklogItemsToSprints() => Console.WriteLine("Assigning backlog items to sprints.");
        public void DefineAcceptanceCriteria() => Console.WriteLine("Defining acceptance criteria.");
        public void GenerateSprintReports() => Console.WriteLine("Generating sprint reports.");

        // Not relevant for Product Owners
        public void PerformAssignedActivities() => Console.WriteLine("Not allowed for Product Owner.");
        public void AccessAndManageCodeRepository() => Console.WriteLine("Not allowed for Product Owner.");
        public void ContributeToProjectProgress() => Console.WriteLine("Not allowed for Product Owner.");
        public void ParticipateInSprints() => Console.WriteLine("Not allowed for Product Owner.");
        public void ManageSprintBacklogs() => Console.WriteLine("Not allowed for Product Owner.");
        public void AssignActivitiesToDevelopers() => Console.WriteLine("Not allowed for Product Owner.");
        public void FacilitateScrumProcess() => Console.WriteLine("Not allowed for Product Owner.");
        public void CommunicateWithTeamAndStakeholders() => Console.WriteLine("Not allowed for Product Owner.");
    }

}
