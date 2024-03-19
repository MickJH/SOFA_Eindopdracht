using AvansDevOps.State.BacklogItems;
using AvansDevOps.State.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Sprints.States
{
    public class CreatedState : ISprintState
    {
        
        public void SetName(Sprint sprint, string name) => sprint.Name = name;

        public void SetDates(Sprint sprint, DateTime start, DateTime end)
        {
            sprint.StartDate = start;
            sprint.EndDate = end;
        }

        public void AddBacklogItem(Sprint sprint, BacklogItem item) => sprint.BacklogItems.Add(item);

        public void Start(Sprint sprint) => sprint.CurrentState = new InProgressState();

        // The following operations are not allowed in this state, so they will throw an exception or simply do nothing
        public void Finish(Sprint sprint) { throw new InvalidOperationException("Cannot finish a sprint that has not started."); }
        public void Release(Sprint sprint) { throw new InvalidOperationException("Cannot release a sprint that has not finished."); }
        public void Close(Sprint sprint) { throw new InvalidOperationException("Cannot close a sprint that has not been released."); }
        public void Cancel(Sprint sprint) => sprint.CurrentState = new CancelledState();
    }

}
