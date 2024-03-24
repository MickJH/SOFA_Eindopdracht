using System;
using System.IO;
using Xunit;
using AvansDevOps.Notification.ExternalSystems;
using AvansDevOps.Factory.User;
using AvansDevOps.Notification.Interfaces;
using NSubstitute;
using AvansDevOps.Factory.User.Roles;

namespace AvansDevOpsTest
{
    public class NotificationServiceTests
    {
        [Fact]
        public void SendNotificationUsingEmailService_WritesExpectedMessageToConsole()
        {
            // Arrange
            var service = new EmailService();
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            service.SendNotification("Hello World", "John Doe");

            // Assert
            var expected = "[EMAIL]  - John Doe\n\tHello World\n\n";
            var actual = sw.ToString().Replace("\r\n", "\n"); // Normalize line endings to Unix style for the assertion
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void SendNotificationUsingSlackService_WritesExpectedMessageToConsole()
        {
            // Arrange
            var service = new SlackService();
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            service.SendNotification("Hello World", "John Doe");

            // Assert
            var expected = "[SLACK]  - John Doe\n\tHello World\n\n";
            var actual = sw.ToString().Replace("\r\n", "\n"); // Normalize line endings to Unix style for the assertion
            Assert.Equal(expected, actual);

        }


        [Fact]
        public void SendNotificationUsingTeamsService_WritesExpectedMessageToConsole()
        {
            // Arrange
            var service = new TeamsService();
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            service.SendNotification("Hello World", "John Doe");

            // Assert
            var expected = "[TEAMS]  - John Doe\n\tHello World\n\n";
            var actual = sw.ToString().Replace("\r\n", "\n"); // Normalize line endings to Unix style for the assertion
            Assert.Equal(expected, actual);

        }

            //Reset the standard output after each test
            public NotificationServiceTests()
        {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        public class NotificationManager : INotificationSubject
        {
            private readonly List<INotificationObserver> _observers = new List<INotificationObserver>();

            public void RegisterObserver(INotificationObserver observer)
            {
                if (!_observers.Contains(observer))
                {
                    _observers.Add(observer);
                }
            }

            public void RemoveObserver(INotificationObserver observer)
            {
                _observers.Remove(observer);
            }

            public void NotifyObservers(string message, Type[]? userRoles = null)
            {
                foreach (var observer in _observers)
                {
                    // If roles are provided, only notify observers of those roles.
                    if (userRoles == null || userRoles.Contains(observer.GetType()))
                    {
                        observer.Notify(message);
                    }
                }
            }
        }

        [Fact]
        public void RegisterObserver_AddsObserverToList()
        {
            // Arrange
            var observer = Substitute.For<INotificationObserver>();
            var manager = new NotificationManager();

            // Act
            manager.RegisterObserver(observer);

            // Assert
            manager.NotifyObservers("Test Message");
            observer.Received(1).Notify("Test Message");
        }

        [Fact]
        public void RemoveObserver_RemovesObserverFromList()
        {
            // Arrange
            var observer = Substitute.For<INotificationObserver>();
            var manager = new NotificationManager();
            manager.RegisterObserver(observer);

            // Act
            manager.RemoveObserver(observer);

            // Assert
            manager.NotifyObservers("Test Message");
            observer.DidNotReceive().Notify(Arg.Any<string>());
        }

    }

}
