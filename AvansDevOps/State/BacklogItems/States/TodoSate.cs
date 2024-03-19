using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.BacklogItems.States
{
        public class TodoState : IBacklogItemState
        {
            public void StartProgress(BacklogItem item)
            {
                item.CurrentState = new DoingState();
            }

            public void MarkAsReadyForTesting(BacklogItem item)
            {
                // Cannot be marked as ready for testing if it is still in Todo
                throw new InvalidOperationException("Cannot mark as ready for testing while in Todo state.");
            }

            public void StartTesting(BacklogItem item)
            {
                // Cannot start testing if it is still in Todo
                throw new InvalidOperationException("Cannot start testing while in Todo state.");
            }

            public void FinishTesting(BacklogItem item, bool isSuccessful)
            {
                // Cannot finish testing if testing has not started
                throw new InvalidOperationException("Cannot finish testing while in Todo state.");
            }

            public void Complete(BacklogItem item)
            {
                // Cannot complete if it hasn't been tested
                throw new InvalidOperationException("Cannot complete while in Todo state.");
            }

            public void Reopen(BacklogItem item)
            {
                // Already in Todo state, maybe log a message or simply do nothing
            }
        }
}
