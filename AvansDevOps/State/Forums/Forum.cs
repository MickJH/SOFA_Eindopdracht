using AvansDevOps.Observer.Interfaces;
using AvansDevOps.State.Forums.States;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.State.Forums
{
    public class Forum : INotificationSubject
    {
        public IForumState CurrentState { get; set; }
        public string Title { get; private set; }
        private List<Message> Messages;
        private readonly List<INotificationObserver> _notificationObservers;

        public Forum(int backlogId ,string topic)
        {
            Title = backlogId + " " + topic;
            CurrentState = new OpenState();
            Messages = new List<Message>();
        }

        public void PostMessage(Message newMessage)
        {
            Messages.Add(newMessage);
        }

        public void Open() => CurrentState.Open(this);
        public void Close() => CurrentState.Close(this);

        public void RegisterObserver(INotificationObserver observer)
        {
            _notificationObservers.Add(observer);
        }

        public void RemoveObserver(INotificationObserver observer)
        {
            int i = _notificationObservers.IndexOf(observer);
            _notificationObservers.RemoveAt(i);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in _notificationObservers)
            {
                observer.Notify(message);
            }
        }
    }
}
