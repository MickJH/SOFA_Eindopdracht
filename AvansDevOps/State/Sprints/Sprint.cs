using AvansDevOps.State.Sprints;
using AvansDevOps.State.BacklogItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.State.Sprints.States;

namespace AvansDevOps.State.Sprints
{
    public class Sprint
    {

        public ISprintState CurrentState { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<BacklogItem> BacklogItems { get; private set; } = new List<BacklogItem>();

        public Sprint(string name, DateTime start, DateTime end)
        {
            Name = name;
            StartDate = start;
            EndDate = end;
            CurrentState = new CreatedState();
        }

        public void SetName(string name) => CurrentState.SetName(this, name);
        public void SetDates(DateTime start, DateTime end) => CurrentState.SetDates(this, start, end);
        public void AddBacklogItem(BacklogItem item) => CurrentState.AddBacklogItem(this, item);
        public void Start() => CurrentState.Start(this);
        public void Finish() => CurrentState.Finish(this);
        public void Release() => CurrentState.Release(this);
        public void Close() => CurrentState.Close(this);
        public void Cancel() => CurrentState.Cancel(this);
    }


}
