using AvansDevOps.State.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string defOfDone { get; set; }
        public List<Sprint> sprints = new List<Sprint>();

        public Project(int id, string name, string description, string defOfDone)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.defOfDone = defOfDone;
        }


        public void AddSprint(Sprint sprint)
        {
            sprints.Add(sprint);
        }

        public void Display()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);
            Console.WriteLine("DoD: " + defOfDone + "\n");
            foreach (var sprint in sprints)
            {
                sprint.Display();
            }
        }
    }
}
