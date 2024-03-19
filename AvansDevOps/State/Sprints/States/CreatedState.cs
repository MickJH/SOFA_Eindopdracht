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
        public void StartProgress(Sprint sprint) => sprint.CurrentState = new InProgressState();

        // The following operations are not allowed in this state, so they will throw an exception or simply do nothing
        public void Finish(Sprint sprint) { throw new InvalidOperationException("Cannot finish a sprint that has not started."); }
        public void StartReleasing(Sprint sprint) => throw new InvalidOperationException("Cannot start releasing a sprint that has not finished.");
        public void FinishRelease(Sprint sprint) => throw new InvalidOperationException("Cannot release a sprint that has not finished.");

        public void Close(Sprint sprint) { throw new InvalidOperationException("Cannot close a sprint that has not been released."); }
        public void Cancel(Sprint sprint) => sprint.CurrentState = new CancelledState();
    }

}
