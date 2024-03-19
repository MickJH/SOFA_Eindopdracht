// See https://aka.ms/new-console-template for more information
using AvansDevOps.Factory.User.Roles;
using AvansDevOps.Factory.User;
using AvansDevOps.State.Sprints;
using AvansDevOps.State.Forums;


var sprint = new Sprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(7));
var forum = new Forum(1, "Hello");

var productOwner = UserFactory.CreateUser<ProductOwner>();
var developer = UserFactory.CreateUser<Developer>();
var scrumMaster = UserFactory.CreateUser<ScrumMaster>();

var message = new Message("Hello all", developer.GetType().Name);

// Registreer observers
forum.RegisterObserver(scrumMaster);
forum.RegisterObserver(productOwner);

forum.PostMessage(message);

forum.Close();