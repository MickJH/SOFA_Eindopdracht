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
        public string Title { get; private set; }
        private List<Message> Messages;

        public Forum(int backlogId ,string topic)
        {
            Title = backlogId + " " + topic;
            CurrentState = new OpenState();
            Messages = new List<Message>();
        }

        public void PostMessage(Message newMessage)
        {
            Messages.Add(newMessage);
        }

        public void Open() => CurrentState.Open(this);
        public void Close() => CurrentState.Close(this);
    }
}
