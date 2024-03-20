using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Forums
{
    public interface IForumState
    {
        void Open(Forum thread);
        void Close(Forum thread);
    }
}
