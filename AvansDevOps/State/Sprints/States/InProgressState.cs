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
        public void StartProgress(Sprint sprint) { throw new InvalidOperationException("Sprint is already in progress."); }
        public void Finish(Sprint sprint) => sprint.CurrentState = new FinishedState();
        public void StartReleasing(Sprint sprint) => throw new InvalidOperationException("Cannot start releasing a sprint that has not been finished.");
        public void FinishRelease(Sprint sprint) => throw new InvalidOperationException("Cannot release a sprint that has not been finished.");
        public void Close(Sprint sprint) { throw new InvalidOperationException("Cannot close a sprint that has not been released."); }
        public void Cancel(Sprint sprint) => sprint.CurrentState = new CancelledState();
    }

}
