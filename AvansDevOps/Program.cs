// See https://aka.ms/new-console-template for more information
using AvansDevOps.Factory.User.Roles;
using AvansDevOps.Factory.User;

Console.WriteLine("Hello, World!");

var productOwner = UserFactory.CreateUser<ProductOwner>();
var developer = UserFactory.CreateUser<Developer>();
var scrumMasterTwo = UserFactory.CreateUser<ScrumMaster>();


productOwner.Name = "Bob";
Console.WriteLine($"{productOwner.Name}");