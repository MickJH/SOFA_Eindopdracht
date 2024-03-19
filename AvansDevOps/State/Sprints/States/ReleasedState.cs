using AvansDevOps.State.BacklogItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Sprints.States
{
    public class ReleasedState : ISprintState
    {
        public void Start(Sprint sprint) => throw new InvalidOperationException("Cannot start a sprint that has already been released.");

        public void Finish(Sprint sprint) => throw new InvalidOperationException("Cannot finish a sprint that has already been released.");

        public void Release(Sprint sprint) => throw new InvalidOperationException("The sprint is already in the released state.");

        public void Close(Sprint sprint)
        {
            // Transition to the ClosedState indicates completion of all release activities.
            sprint.CurrentState = new ClosedState();
        }

        public void Cancel(Sprint sprint) => throw new InvalidOperationException("Cannot cancel a sprint that has already been released.");
    }

}
