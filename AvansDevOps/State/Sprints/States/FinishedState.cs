using AvansDevOps.State.BacklogItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Sprints.States
{
    public class FinishedState : ISprintState
    {
        // Disallow all modifications and starting
        public void SetName(Sprint sprint, string name) { throw new InvalidOperationException("Cannot change the name of a finished sprint."); }
        public void SetDates(Sprint sprint, DateTime start, DateTime end) { throw new InvalidOperationException("Cannot change the dates of a finished sprint."); }
        public void AddBacklogItem(Sprint sprint, BacklogItem item) { throw new InvalidOperationException("Cannot add backlog items to a finished sprint."); }
        public void Start(Sprint sprint) { throw new InvalidOperationException("Sprint has already finished."); }
        public void Finish(Sprint sprint) { throw new InvalidOperationException("Sprint is already finished."); }

        public void Release(Sprint sprint) => sprint.CurrentState = new ReleasingState();
        public void Close(Sprint sprint) { throw new InvalidOperationException("Cannot close a sprint that has not been released."); }
        public void Cancel(Sprint sprint) => sprint.CurrentState = new CancelledState();
    }

}
