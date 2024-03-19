using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Forums
{
    public class Message
    {
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public string User { get; set; }

        public Message(string content, string userName)
        {
            this.Content = content;
            this.User = userName;
            this.TimeStamp = DateTime.Now;
        }
    }
}
