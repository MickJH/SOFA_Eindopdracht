using AvansDevOps.Factory.User;
using AvansDevOps.Factory.User.Roles;
using AvansDevOps.Notification.Interfaces;

namespace AvansDevOpsTest
{
    public class UserTests
    {
        [Fact]
        public void CreateUser_Developer_ReturnsUserWithDeveloperRole()
        {
            // Arrange
            string name = "John Doe";
            INotificationAdapter[] notificationServices = Array.Empty<INotificationAdapter>();

            // Act
            var user = UserFactory.CreateUserWithRole(name, "Developer", notificationServices);

            // Assert
            Assert.NotNull(user.Role);
            Assert.IsType<Developer>(user.Role);
        }

        [Fact]
        public void CreateUser_ScrumMaster_ReturnsUserWithScrumMasterRole()
        {
            // Arrange
            string name = "John Doe";
            INotificationAdapter[] notificationServices = Array.Empty<INotificationAdapter>();

            // Act
            var user = UserFactory.CreateUserWithRole(name, "ScrumMaster", notificationServices);

            // Assert
            Assert.NotNull(user.Role);
            Assert.IsType<ScrumMaster>(user.Role);
        }

        [Fact]
        public void CreateUser_ProductOwner_ReturnsUserWithProductOwnerRole()
        {
            // Arrange
            string name = "John Doe";
            INotificationAdapter[] notificationServices = Array.Empty<INotificationAdapter>();

            // Act
            var user = UserFactory.CreateUserWithRole(name, "ProductOwner", notificationServices);

            // Assert
            Assert.NotNull(user.Role);
            Assert.IsType<ProductOwner>(user.Role);
        }

        [Fact]
        public void CreateUser_Tester_ReturnsUserWithTesterRole()
        {
            // Arrange
            string name = "John Doe";
            INotificationAdapter[] notificationServices = Array.Empty<INotificationAdapter>();

            // Act
            var user = UserFactory.CreateUserWithRole(name, "Tester", notificationServices);

            // Assert
            Assert.NotNull(user.Role);
            Assert.IsType<Tester>(user.Role);
        }
        [Fact]
        public void CreateUser_UnknownRole_ThrowsArgumentException()
        {
            string name = "John Doe";
            INotificationAdapter[] notificationServices = Array.Empty<INotificationAdapter>();

            var exception = Record.Exception(() => UserFactory.CreateUserWithRole(name, "UnknownRole", notificationServices));

            Assert.IsType<ArgumentException>(exception);
        }
    }

}