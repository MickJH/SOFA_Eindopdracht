using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.BacklogItems.States
{
        public class TestingState : IBacklogItemState
        {
            public void StartProgress(BacklogItem item)
            {
                // Not applicable in this state
                throw new InvalidOperationException("Cannot start progress while testing.");
            }

            public void MarkAsReadyForTesting(BacklogItem item)
            {
                // Not applicable, as testing has already started
                throw new InvalidOperationException("Cannot mark as ready for testing when testing has started.");
            }

            public void StartTesting(BacklogItem item)
            {
                // Already in testing state
            }

            public void FinishTesting(BacklogItem item, bool isSuccessful)
            {
                if (isSuccessful)
                {
                    item.CurrentState = new TestedState();
                }
                else
                {
                    // If the test is not successful, it goes back to Todo
                    item.CurrentState = new TodoState();
                }
            }

            public void Complete(BacklogItem item)
            {
                // Cannot complete if testing hasn't been finished
                throw new InvalidOperationException("Cannot complete until testing has been finished.");
            }

            public void Reopen(BacklogItem item)
            {
                // Testing not successful, move back to Todo
                item.CurrentState = new TodoState();
            }
        }
}
