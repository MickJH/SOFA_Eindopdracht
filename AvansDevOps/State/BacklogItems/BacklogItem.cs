using AvansDevOps.Factory.User;
using AvansDevOps.Factory.User.Roles;
using AvansDevOps.Notification.Interfaces;
using AvansDevOps.State.BacklogItems.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.BacklogItems
{
    public class BacklogItem : INotificationSubject
    {

        public IBacklogItemState CurrentState { get; set; }
        public string Title { get; private set; }
        private readonly List<INotificationObserver> _notificationObservers = new List<INotificationObserver>();
        private int StoryPoints;
        private readonly List<Activity> _activities = new List<Activity>();
        private User Developer;

        public BacklogItem(string title, int storypoints, User? developer = null)
        {
            Title = title;
            StoryPoints = storypoints;
            CurrentState = new TodoState();
            Developer = developer;
        }

        public void AddActivity(Activity activity)
        {
            _activities.Add(activity);
        }

        public void DeleteActivity(Activity activity)
        {
            _activities.Remove(activity);
        }

        public void Display()
        {
            Console.WriteLine(this.Title + (this.Developer != null ? " - " + this.Developer : "") + " (" + StoryPoints + " points) ---");
            foreach (var activity in _activities)
            {
                Console.WriteLine("\t * " + activity.Id + " - " + activity.Title + " - " + (activity.Developer != null ? activity.Developer.Name : "No developer assigned"));
            }
        }

        // States
        public void StartProgress() => CurrentState.StartProgress(this);
        public void MarkAsReadyForTesting()
        {
            CurrentState.MarkAsReadyForTesting(this);
            NotifyObservers(Title + " is ready for testing.", new[] { typeof(Tester) });
        }

        public void StartTesting()
        {
            CurrentState.StartTesting(this);

            // Als er iets ontbreekt of fout gaat terug naar ToDo --> CurrentState.StartProgress
            // NotifyObservers("Testen van " + Title + " is niet succesvol afgerond.
            //                  Het item wordt terggeplaatst naar ToDo.", new[] { typeof(ScrumMaster) });
        }
        public void FinishTesting(bool isSuccessful) => CurrentState.FinishTesting(this, isSuccessful);
        public void Complete() => CurrentState.Complete(this);
        public void Reopen() => CurrentState.Reopen(this);


        // Observers
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
