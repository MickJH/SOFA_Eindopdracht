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
        public void SetName(Sprint sprint, string name) => throw new InvalidOperationException("Cannot change the name of a sprint that has been cancelled.");

        public void SetDates(Sprint sprint, DateTime start, DateTime end) => throw new InvalidOperationException("Cannot change the dates of a sprint that has been cancelled.");

        public void AddBacklogItem(Sprint sprint, BacklogItem item) => throw new InvalidOperationException("Cannot add backlog items to a sprint that has been cancelled.");

        public void Start(Sprint sprint) => throw new InvalidOperationException("Cannot start a sprint that has been cancelled.");

        public void Finish(Sprint sprint) => throw new InvalidOperationException("Cannot finish a sprint that has been cancelled.");

        public void Release(Sprint sprint) => throw new InvalidOperationException("Cannot release a sprint that has been cancelled.");

        public void Close(Sprint sprint) => throw new InvalidOperationException("Cannot close a sprint that has been cancelled.");

        public void Cancel(Sprint sprint) => throw new InvalidOperationException("The sprint is already in the cancelled state.");
    }

}
