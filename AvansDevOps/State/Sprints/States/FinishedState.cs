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
        public void Start(Sprint sprint) => throw new InvalidOperationException("Sprint has already finished.");
        public void Finish(Sprint sprint) => throw new InvalidOperationException("Sprint is already finished.");
        public void Release(Sprint sprint) => sprint.CurrentState = new ReleasingState();
        public void Close(Sprint sprint) => throw new InvalidOperationException("Cannot close a sprint that has not been released."); 
        public void Cancel(Sprint sprint) => sprint.CurrentState = new CancelledState();
    }

}
