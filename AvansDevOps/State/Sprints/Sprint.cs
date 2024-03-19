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

        public void SetName(string name)
        {
            if (CurrentState is CreatedState)
            {
                Name = name;
            }
            else
            {
                throw new InvalidOperationException("Cannot change the name of a sprint that has already started.");
            }
        }

        public void SetDates(DateTime start, DateTime end)
        {
            if (CurrentState is CreatedState)
            {
                StartDate = start;
                EndDate = end;
            }
            else
            {
                throw new InvalidOperationException("Cannot change the dates of a sprint that has already started.");
            }
        }

        public void AddBacklogItem(BacklogItem item)
        {
            if (CurrentState is CreatedState)
            {
                BacklogItems.Add(item);
            }
            else
            {
                throw new InvalidOperationException("Cannot change the backlog of a sprint that has already started.");
            }
        }
        public void Start() => CurrentState.Start(this);
        public void Finish() => CurrentState.Finish(this);
        public void Release() => CurrentState.Release(this);
        public void Close() => CurrentState.Close(this);
        public void Cancel() => CurrentState.Cancel(this);
    }


}
