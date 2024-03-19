using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.State.BacklogItems;

namespace AvansDevOps.State.Sprints
{
    public interface ISprintState
    {
        void Start(Sprint sprint);
        void Finish(Sprint sprint);
        void Release(Sprint sprint);
        void Close(Sprint sprint);
        void Cancel(Sprint sprint);
    }
}
