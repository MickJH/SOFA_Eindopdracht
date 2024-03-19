using AvansDevOps.Factory.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Factory.User.Roles
{
    public class Tester : User, IUserActions
    {
        public void PerformAssignedActivities() => Console.WriteLine("Performing assigned activities.");
        public void AccessAndManageCodeRepository() => Console.WriteLine("Accessing and managing code repository.");
        public void ContributeToProjectProgress() => Console.WriteLine("Contributing to project progress.");
        public void ParticipateInSprints() => Console.WriteLine("Participating in sprints.");

        // Not relevant for Developers
        public void ManageBacklogItems() => Console.WriteLine("Not allowed for Developer.");
        public void AssignBacklogItemsToSprints() => Console.WriteLine("Not allowed for Developer.");
        public void DefineAcceptanceCriteria() => Console.WriteLine("Not allowed for Developer.");
        public void GenerateSprintReports() => Console.WriteLine("Not allowed for Developer.");
        public void ManageSprintBacklogs() => Console.WriteLine("Not allowed for Developer.");
        public void AssignActivitiesToDevelopers() => Console.WriteLine("Not allowed for Developer.");
        public void FacilitateScrumProcess() => Console.WriteLine("Not allowed for Developer.");
        public void CommunicateWithTeamAndStakeholders() => Console.WriteLine("Not allowed for Developer.");
    }
}
