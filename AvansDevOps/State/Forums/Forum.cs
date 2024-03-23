using AvansDevOps.Factory.User;
using AvansDevOps.Factory.User.Roles;
using AvansDevOps.Notification.Interfaces;
using AvansDevOps.State.BacklogItems;
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
        public BacklogItem BacklogItem { get; set; }
        public string Title { get; private set; }
        private readonly List<MessageComponent> _messages = new();
        private readonly List<INotificationObserver> _notificationObservers = new();

        public Forum(BacklogItem backlogItem)
        {
            BacklogItem = backlogItem;
            Title = backlogItem.Title;
            CurrentState = new OpenState();
        }

        public void PostMessage(MessageComponent newMessage)
        {
            if (CurrentState is OpenState)
            {
                _messages.Add(newMessage);
                NotifyObservers("New message posted by " + newMessage.UserName);
            }
            else
            {
                throw new InvalidOperationException("Forum is closed, no new messages can be posted.");
            }
        }

        public void DisplayMessages()
        {
            Console.WriteLine("----------------------------- Forum -----------------------------");
            Console.WriteLine("\b" + Title);
            foreach (var message in _messages)
            {
                message.Display();
            }
            Console.WriteLine("----------------------------------------------------------------- \n");
        }

        public void Open()
        {
            CurrentState.Open(this);
        }
        public void Close()
        {
            CurrentState.Close(this);
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

        public void NotifyObservers(string message, Type[]? userRoles = null)
        {
            foreach (var observer in _notificationObservers)
            {
                observer.Notify(message);
            }
        }
    }
}
