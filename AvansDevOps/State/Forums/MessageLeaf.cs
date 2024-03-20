using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Forums
{
    public class MessageLeaf : MessageComponent
    {
        public MessageLeaf(string content, string userName) : base(content, userName)
        {
        }
    }
}
