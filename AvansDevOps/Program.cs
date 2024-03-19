// See https://aka.ms/new-console-template for more information
using AvansDevOps.Factory.User.Roles;
using AvansDevOps.Factory.User;

Console.WriteLine("Hello, World!");

var productOwnerUser = UserFactory.CreateUserWithRole("Bob", "ProductOwner");
productOwnerUser.PerformRoleDuties();
Console.WriteLine(productOwnerUser.Name);