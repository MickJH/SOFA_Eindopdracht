using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.BacklogItems.States
{
        public class ReadyForTestingState : IBacklogItemState
        {
            public void StartProgress(BacklogItem item)
            {
                // If needed, transition back to Doing state
                item.CurrentState = new DoingState();
            }

            public void MarkAsReadyForTesting(BacklogItem item)
            {
                // Already marked as ready for testing, maybe log a message or simply do nothing
            }

            public void StartTesting(BacklogItem item)
            {
                item.CurrentState = new TestingState();
            }

            public void FinishTesting(BacklogItem item, bool isSuccessful)
            {
                // Testing hasn't started yet, cannot finish testing
                throw new InvalidOperationException("Testing must start before it can be finished.");
            }

            public void Complete(BacklogItem item)
            {
                // Cannot complete if testing hasn't been finished
                throw new InvalidOperationException("Cannot complete if testing hasn't been finished.");
            }

            public void Reopen(BacklogItem item)
            {
                item.CurrentState = new TodoState();
            }
        }
}
