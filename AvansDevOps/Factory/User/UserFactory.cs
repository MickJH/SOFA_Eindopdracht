using AvansDevOps.Factory.User.Interfaces;
using AvansDevOps.Notification.Interfaces;
using System;
using System.Reflection;

namespace AvansDevOps.Factory.User
{
    public static class UserFactory
    {
        public static User CreateUserWithRole(string name, string roleName, INotificationAdapter[]? notificationServices = null)
        {
            var user = new User(name, notificationServices ?? Array.Empty<INotificationAdapter>());

            // Dynamically load the role based on roleName
            var roleType = Type.GetType($"AvansDevOps.Factory.User.Roles.{roleName}");
            if (roleType == null || !typeof(IRole).IsAssignableFrom(roleType))
            {
                throw new ArgumentException("Unknown role", nameof(roleName));
            }

            var role = (IRole)Activator.CreateInstance(roleType)!;
            user.AssignRole(role);

            return user;
        }
    }
}
