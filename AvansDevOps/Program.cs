// See https://aka.ms/new-console-template for more information
using AvansDevOps.Factory.User.Roles;
using AvansDevOps.Factory.User;
using AvansDevOps.State.Sprints;
using AvansDevOps.State.Forums;
using AvansDevOps.State.BacklogItems;

var sprint = new Sprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(7));
var item1 = new BacklogItem("Backlog 1");
var forum = new Forum(1, "Hello");

var productOwner = UserFactory.CreateUserWithRole("Bob", "ProductOwner");
var developer = UserFactory.CreateUserWithRole("John", "Developer");
var scrumMaster = UserFactory.CreateUserWithRole("Jane", "ScrumMaster");
var tester = UserFactory.CreateUserWithRole("Tina", "Tester");

var message = new Message("Hello all", developer.Name);
sprint.AddBacklogItem(item1);

// Registreer observers

forum.RegisterObserver(productOwner);
forum.RegisterObserver(developer);
forum.RegisterObserver(scrumMaster);
forum.RegisterObserver(tester);

forum.PostMessage(message);

forum.Close();

sprint.RegisterObserver(productOwner);
sprint.RegisterObserver(developer);
sprint.RegisterObserver(scrumMaster);
sprint.RegisterObserver(tester);

sprint.StartProgress();
sprint.Finish();
sprint.StartReleasing();
sprint.FinishRelease();

item1.RegisterObserver(productOwner);
item1.RegisterObserver(developer);
item1.RegisterObserver(scrumMaster);
item1.RegisterObserver(tester);

item1.StartProgress();
item1.MarkAsReadyForTesting();
item1.Reopen();