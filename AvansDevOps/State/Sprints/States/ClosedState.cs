using AvansDevOps.State.BacklogItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Sprints.States
{
    public class ClosedState : ISprintState
    {
        public void StartProgress(Sprint sprint) => throw new InvalidOperationException("Cannot start a sprint that is closed.");

        public void Finish(Sprint sprint) => throw new InvalidOperationException("Cannot finish a sprint that is already closed.");

        public void StartReleasing(Sprint sprint) => throw new InvalidOperationException("Cannot start releasing a sprint that is already closed.");
        public void FinishRelease(Sprint sprint) => throw new InvalidOperationException("Cannot release a sprint that is already closed.");

        public void Close(Sprint sprint) => throw new InvalidOperationException("The sprint is already in the closed state.");

        public void Cancel(Sprint sprint) => throw new InvalidOperationException("Cannot cancel a sprint that is closed.");
    }

}
