using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.BacklogItems.States
{
        public class DoingState : IBacklogItemState
        {
            public void StartProgress(BacklogItem item)
            {
                // Already in progress, maybe log a message or simply do nothing
            }

            public void MarkAsReadyForTesting(BacklogItem item)
            {
                item.CurrentState = new ReadyForTestingState();
            }

            public void StartTesting(BacklogItem item)
            {
                // Cannot start testing until it's marked as ready for testing
                throw new InvalidOperationException("Cannot start testing until item is marked as ready for testing.");
            }

            public void FinishTesting(BacklogItem item, bool isSuccessful)
            {
                // Cannot finish testing until testing has started
                throw new InvalidOperationException("Cannot finish testing until testing has started.");
            }

            public void Complete(BacklogItem item)
            {
                // Cannot complete until it's been tested
                throw new InvalidOperationException("Cannot complete until item has been tested.");
            }

            public void Reopen(BacklogItem item)
            {
                item.CurrentState = new TodoState();
            }
        }
}
