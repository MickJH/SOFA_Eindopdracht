using AvansDevOps.State.BacklogItems.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.BacklogItems
{
    public class BacklogItem
    {
       
            public IBacklogItemState CurrentState { get; set; }
            public string Title { get; private set; }

            public BacklogItem(string title)
            {
                Title = title;
                CurrentState = new TodoState();
            }

            public void StartProgress() => CurrentState.StartProgress(this);
            public void MarkAsReadyForTesting() => CurrentState.MarkAsReadyForTesting(this);
            public void StartTesting() => CurrentState.StartTesting(this);
            public void FinishTesting(bool isSuccessful) => CurrentState.FinishTesting(this, isSuccessful);
            public void Complete() => CurrentState.Complete(this);
            public void Reopen() => CurrentState.Reopen(this);
        

    }
}
