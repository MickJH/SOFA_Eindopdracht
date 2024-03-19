using AvansDevOps.State.Sprints.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Forums.States
{
        public class OpenState : IForumState
        {
            public void Open(Forum thread)
            {
                // The thread is already open, so maybe log this event or simply do nothing.
            }

            public void Close(Forum thread)
            {
                // Transition the thread to the Closed state
                thread.CurrentState = new ClosedState();
            }
        }
}
