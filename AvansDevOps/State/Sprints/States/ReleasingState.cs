using AvansDevOps.State.BacklogItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Sprints.States
{
    public class ReleasingState : ISprintState
    {
        public void StartProgress(Sprint sprint) => throw new InvalidOperationException("Cannot start a sprint that is releasing.");
        public void Finish(Sprint sprint) => throw new InvalidOperationException("Cannot finish a sprint that is releasing.");
        public void StartReleasing(Sprint sprint) => throw new InvalidOperationException("The sprint is already releasing.");
        public void FinishRelease(Sprint sprint)
        {
            // Assuming deployment pipeline succeeds
            sprint.CurrentState = new ReleasedState();
        }
        public void Close(Sprint sprint) => throw new InvalidOperationException("The sprint is not fully released yet.");

        public void Cancel(Sprint sprint)
        {
            sprint.CurrentState = new CancelledState();
        }
    }

}
