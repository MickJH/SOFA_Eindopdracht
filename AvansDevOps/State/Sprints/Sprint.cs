using AvansDevOps.State.Sprints;
using AvansDevOps.State.BacklogItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.State.Sprints.States;
using AvansDevOps.Observer.Interfaces;
using AvansDevOps.Factory.User.Roles;
using AvansDevOps.Factory.User;
using AvansDevOps.Factory.User.Interfaces;

namespace AvansDevOps.State.Sprints
{
    public class Sprint : INotificationSubject
    {

        public ISprintState CurrentState { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<BacklogItem> BacklogItems { get; private set; } = new();
        private readonly List<INotificationObserver> _notificationObservers = new();

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
        public void StartProgress() => CurrentState.StartProgress(this);
        public void Finish() => CurrentState.Finish(this);
        public void StartReleasing()
        {
            CurrentState.StartReleasing(this);

            // Als er een error optreedt tijdens de development pipeline
            // NotifyObservers("Something went wrong, restart the pipeline.", new [] { typeof(ScrumMaster) });
        }
        public void FinishRelease()
        {
            CurrentState.FinishRelease(this);
            // Samenvatting toevoegen als er een sprint review plaatsvindt

            NotifyObservers("Release finished.", new[] { typeof(ScrumMaster), typeof(ProductOwner) });
        }
        public void Close()
        {
            CurrentState.Close(this);
            // Genereer rapportage
        }
        public void Cancel()
        {
            CurrentState.Cancel(this);
            NotifyObservers("Sprint has been cancelled.", new[] { typeof(ScrumMaster), typeof(ProductOwner) });
        }

        public void RegisterObserver(INotificationObserver observer)
        {
            _notificationObservers.Add(observer);
        }

        public void RemoveObserver(INotificationObserver observer)
        {
            int i = _notificationObservers.IndexOf(observer);
            _notificationObservers.RemoveAt(i);
        }

        public void NotifyObservers(string message, Type[]? userRoles)
        {
            foreach (var observer in _notificationObservers)
            {
                if (userRoles != null)
                {
                    foreach (var role in userRoles)
                    {
                        var user = observer as User;

                        if (user!.Role!.GetType().IsAssignableFrom(role))
                        {
                            observer.Notify(message);
                        }
                    }
                }
                else
                {
                    observer.Notify(message);
                }
            }
        }
    }


}
