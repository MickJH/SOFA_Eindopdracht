// See https://aka.ms/new-console-template for more information
using AvansDevOps.Factory.User.Roles;
using AvansDevOps.Factory.User;
using AvansDevOps.State.Sprints;
using AvansDevOps.State.Forums;
using AvansDevOps.State.BacklogItems;
using AvansDevOps.Notification.Interfaces;
using AvansDevOps.Notification.ExternalSystems;

var sprint = new Sprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(7));
var item1 = new BacklogItem("Backlog 1");
var forum = new Forum(item1);

var slackService = new SlackService();
var teamsService = new TeamsService();

var productOwner = UserFactory.CreateUserWithRole("Bob", "ProductOwner", new[] { slackService });
var developer = UserFactory.CreateUserWithRole("John", "Developer", new[] { teamsService });
var scrumMaster = UserFactory.CreateUserWithRole("Jane", "ScrumMaster", new INotificationAdapter[] { slackService, teamsService });
var tester = UserFactory.CreateUserWithRole("Tina", "Tester");

sprint.AddBacklogItem(item1);

// Registreer observers

forum.RegisterObserver(productOwner);
forum.RegisterObserver(developer);
forum.RegisterObserver(scrumMaster);
forum.RegisterObserver(tester);

// Test composite and observer forum
var rootMessage = new MessageComposite("I started a new project", scrumMaster.Name);
forum.PostMessage(rootMessage);

var reply1 = new MessageLeaf("That sounds great, Jane!", productOwner.Name);
rootMessage.PostChildMessage(reply1);

var reply2 = new MessageComposite("Can I contribute?", developer.Name);
forum.PostMessage(reply2);

var reply2_1 = new MessageLeaf("Sure, John!", scrumMaster.Name);
reply2.PostChildMessage(reply2_1);

forum.DisplayMessages();

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