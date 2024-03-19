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
        public void Start(Sprint sprint) => throw new InvalidOperationException("Cannot start a sprint that is releasing.");

        public void Finish(Sprint sprint) => throw new InvalidOperationException("Cannot finish a sprint that is releasing.");

        public void Release(Sprint sprint)
        {
            // Assuming deployment pipeline succeeds
            sprint.CurrentState = new ReleasedState();
        }

        public void Close(Sprint sprint) => throw new InvalidOperationException("Cannot directly close a sprint during releasing.");

        public void Cancel(Sprint sprint)
        {
            sprint.CurrentState = new CancelledState();
        }
    }

}
