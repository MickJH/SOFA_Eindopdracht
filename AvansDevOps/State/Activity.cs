using AvansDevOps.Factory.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State
{
    public class Activity
    {
        public int Id;
        public User Developer;
        public string Title;

        public Activity(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public void AssingDeveloper(User developer) { 
            this.Developer = developer;
        }
    }
}
