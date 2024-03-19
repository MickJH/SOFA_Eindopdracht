using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.BacklogItems
{
    public interface IBacklogItemState
    {
        void StartProgress(BacklogItem item);
        void MarkAsReadyForTesting(BacklogItem item);
        void StartTesting(BacklogItem item);
        void FinishTesting(BacklogItem item, bool isSuccessful);
        void Complete(BacklogItem item);
        void Reopen(BacklogItem item);
    }

}
