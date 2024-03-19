using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Factory.User.Interfaces
{
    public interface IUserActions
    {
        void ManageBacklogItems();
        void AssignBacklogItemsToSprints();
        void DefineAcceptanceCriteria();
        void GenerateSprintReports();
        void PerformAssignedActivities();
        void AccessAndManageCodeRepository();
        void ContributeToProjectProgress();
        void ParticipateInSprints();
        void ManageSprintBacklogs();
        void AssignActivitiesToDevelopers();
        void FacilitateScrumProcess();
        void CommunicateWithTeamAndStakeholders();
    }
}
