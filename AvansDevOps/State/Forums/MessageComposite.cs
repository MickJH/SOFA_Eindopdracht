using AvansDevOps.Factory.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvansDevOps.State.Forums
{
    public class MessageComposite : MessageComponent
    {
        private readonly List<MessageComponent> _messages = new List<MessageComponent>();

        public MessageComposite(string content, string userName) : base(content, userName)
        {
        }

        public void PostChildMessage(MessageComponent message) => _messages.Add(message);
        public void RemoveMessage(MessageComponent message) => _messages.Remove(message);
        public List<MessageComponent> GetMessages() => _messages;

        public override void Display(int indentationLevel = 0)
        {
            base.Display(indentationLevel);
            foreach (var childMessage in _messages)
            {
                // Increase the indentation for child nodes
                childMessage.Display(indentationLevel + 1);
            }
        }
    }
};
