using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.BacklogItems.States
{
        public class DoneState : IBacklogItemState
        {
            public void StartProgress(BacklogItem item)
            {
                // Not applicable in this state
                throw new InvalidOperationException("Cannot start progress on a completed item.");
            }

            public void MarkAsReadyForTesting(BacklogItem item)
            {
                // Not applicable for a done item
                throw new InvalidOperationException("Cannot mark as ready for testing a completed item.");
            }

            public void StartTesting(BacklogItem item)
            {
                // Not applicable for a done item
                throw new InvalidOperationException("Cannot start testing a completed item.");
            }

            public void FinishTesting(BacklogItem item, bool isSuccessful)
            {
                // Not applicable for a done item
                throw new InvalidOperationException("Cannot finish testing a completed item.");
            }

            public void Complete(BacklogItem item)
            {
                // Already complete
            }

            public void Reopen(BacklogItem item)
            {
                // Item can be reopened and moved back to Todo
                item.CurrentState = new TodoState();
            }
        }
}
