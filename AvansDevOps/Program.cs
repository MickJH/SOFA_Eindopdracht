// See https://aka.ms/new-console-template for more information
using AvansDevOps.Factory.User.Roles;
using AvansDevOps.Factory.User;
using AvansDevOps.State.Sprints;
using AvansDevOps.State.Forums;
using AvansDevOps.State.BacklogItems;
using AvansDevOps.Notification.Interfaces;
using AvansDevOps.Notification.ExternalSystems;
using AvansDevOps.State;

// Services
var slackService = new SlackService();
var teamsService = new TeamsService();

// Users
var productOwner = UserFactory.CreateUserWithRole("Bob", "ProductOwner", new[] { slackService });
var developer = UserFactory.CreateUserWithRole("John", "Developer", new[] { teamsService });
var scrumMaster = UserFactory.CreateUserWithRole("Jane", "ScrumMaster", new INotificationAdapter[] { slackService, teamsService });
var tester = UserFactory.CreateUserWithRole("Tina", "Tester");

var project1 = new Project(1, "Project 1", "My first project", "Tests written");

var sprint = new Sprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(7));
var sprint2 = new Sprint("Sprint 2", DateTime.Now.AddDays(7), DateTime.Now.AddDays(14));

var item1 = new BacklogItem("Backlog 1", 10);
var item2 = new BacklogItem("Backlog 2", 10);

var forum = new Forum(item1);
item1.AddForum(forum);

var activity1 = new Activity(1, "Activity 1");
var activity2 = new Activity(2, "Activity 2");
activity2.AssingDeveloper(scrumMaster);

var activity3 = new Activity(3, "Activity 3");
var activity4 = new Activity(4, "Activity 4");

// Adding activities to backlog item
item1.AddActivity(activity1);
item1.AddActivity(activity2);
item1.AddActivity(activity3);
item2.AddActivity(activity4);

// Adding backlog items to sprint
sprint.AddBacklogItem(item1);
sprint2.AddBacklogItem(item2);

project1.AddSprint(sprint);
project1.AddSprint(sprint2);

project1.Display();

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