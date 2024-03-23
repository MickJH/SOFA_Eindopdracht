using AvansDevOps.Factory.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Forums
{
    public abstract class MessageComponent
    {
        protected string Content { get; set; }
        protected DateTime TimeStamp { get; set; }
        public string UserName { get; set; }

        public MessageComponent(string content, string userName)
        {
            this.Content = content;
            this.UserName = userName;
            this.TimeStamp = DateTime.Now;
        }

        public virtual void Display(int indentationLevel = 0)
        {
            var indentation = new string('\t', indentationLevel);
            Console.WriteLine($"{indentation}{UserName} [{TimeStamp.ToShortDateString()} {TimeStamp.ToShortTimeString()}]: {Content}");
        }
    }
}
