using AvansDevOps.State.BacklogItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Sprints.States
{
    public class InProgressState : ISprintState
    {
        // These operations are now disallowed, so they throw an exception or simply do nothing
        public void SetName(Sprint sprint, string name) { throw new InvalidOperationException("Cannot change the name of a sprint in progress."); }
        public void SetDates(Sprint sprint, DateTime start, DateTime end) { throw new InvalidOperationException("Cannot change the dates of a sprint in progress."); }
        public void AddBacklogItem(Sprint sprint, BacklogItem item) { throw new InvalidOperationException("Cannot add backlog items to a sprint in progress."); }
        public void Start(Sprint sprint) { throw new InvalidOperationException("Sprint is already in progress."); }

        public void Finish(Sprint sprint) => sprint.CurrentState = new FinishedState();
        public void Release(Sprint sprint) { throw new InvalidOperationException("Sprint must be finished before it can be released."); }
        public void Close(Sprint sprint) { throw new InvalidOperationException("Cannot close a sprint that has not been released."); }
        public void Cancel(Sprint sprint) => sprint.CurrentState = new CancelledState();
    }

}
