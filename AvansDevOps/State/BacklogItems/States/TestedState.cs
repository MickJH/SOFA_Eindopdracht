using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.BacklogItems.States
{
        public class TestedState : IBacklogItemState
        {
            public void StartProgress(BacklogItem item)
            {
                // Not applicable in this state
                throw new InvalidOperationException("Cannot start progress on an item that is already tested.");
            }

            public void MarkAsReadyForTesting(BacklogItem item)
            {
                // If needed, could transition back to ReadyForTestingState
                item.CurrentState = new ReadyForTestingState();
            }

            public void StartTesting(BacklogItem item)
            {
                // Already tested
                throw new InvalidOperationException("Cannot start testing on an item that is already tested.");
            }

            public void FinishTesting(BacklogItem item, bool isSuccessful)
            {
                // Already finished testing
                throw new InvalidOperationException("Cannot finish testing on an item that is already tested.");
            }

            public void Complete(BacklogItem item)
            {
                // If it passes the Definition of Done, it can be marked as complete
                item.CurrentState = new DoneState();
            }

            public void Reopen(BacklogItem item)
            {
                // If not done according to the Definition of Done, reopen it
                item.CurrentState = new TodoState();
            }
        }
}
