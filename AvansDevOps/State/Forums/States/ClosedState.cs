using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Forums.States
{
    public class ClosedState : IForumState
    {
        public void Open(Forum thread)
        {
            // Transition the thread back to the Open state if needed.
            // Note: Depending on the business rules, this operation might not be allowed.
            thread.CurrentState = new OpenState();
        }

        public void Close(Forum thread)
        {
            // The thread is already closed, so maybe log this event or simply do nothing.
        }
    }
}
