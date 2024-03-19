using AvansDevOps.State.Forums.States;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Forums
{
    public class Forum
    {
        public IForumState CurrentState { get; set; }
        public string Topic { get; private set; }

        public Forum(string topic)
        {
            Topic = topic;
            CurrentState = new OpenState();
        }

        public void Open() => CurrentState.Open(this);
        public void Close() => CurrentState.Close(this);
    }
}
