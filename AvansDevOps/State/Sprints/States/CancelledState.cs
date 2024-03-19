using AvansDevOps.State.BacklogItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Sprints.States
{
    public class CancelledState : ISprintState
    {
        public void Start(Sprint sprint) => throw new InvalidOperationException("Cannot start a sprint that has been cancelled.");

        public void Finish(Sprint sprint) => throw new InvalidOperationException("Cannot finish a sprint that has been cancelled.");

        public void Release(Sprint sprint) => throw new InvalidOperationException("Cannot release a sprint that has been cancelled.");

        public void Close(Sprint sprint) => throw new InvalidOperationException("Cannot close a sprint that has been cancelled.");

        public void Cancel(Sprint sprint) => throw new InvalidOperationException("The sprint is already in the cancelled state.");
    }

}
