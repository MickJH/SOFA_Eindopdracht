using AvansDevOps.State.BacklogItems.States;
using AvansDevOps.State.BacklogItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.State.Forums;
using NSubstitute;
using AvansDevOps.State.Forums.States;
using AvansDevOps.State.Sprints.States;
using AvansDevOps.State.Sprints;
using AvansDevOps.Factory.User;
using AvansDevOps.State;

namespace AvansDevOpsTest
{
    public class StateTests
    {

        //BacklogItem
        [Fact]
        public void StartProgress_WhenInTodoState_ChangesStateToDoing()
        {
            // Arrange
            var backlogItem = new BacklogItem("Implement feature", 5);
            backlogItem.CurrentState = new TodoState();

            // Act
            backlogItem.StartProgress();

            // Assert
            Assert.IsType<DoingState>(backlogItem.CurrentState);
        }

        [Fact]
        public void MarkAsReadyForTesting_WhenInDoingState_ChangesStateToReadyForTesting()
        {
            // Arrange
            var backlogItem = new BacklogItem("Review code", 3);
            backlogItem.CurrentState = new DoingState();

            // Act
            backlogItem.MarkAsReadyForTesting();

            // Assert
            Assert.IsType<ReadyForTestingState>(backlogItem.CurrentState);
        }

        [Fact]
        public void StartTesting_WhenReadyForTesting_ChangesStateToTesting()
        {
            // Arrange
            var backlogItem = new BacklogItem("Test feature", 3);
            backlogItem.CurrentState = new ReadyForTestingState();

            // Act
            backlogItem.StartTesting();

            // Assert
            Assert.IsType<TestingState>(backlogItem.CurrentState);
        }

        [Fact]
        public void FinishTesting_WhenTestingAndSuccessful_ChangesStateToTested()
        {
            // Arrange
            var backlogItem = new BacklogItem("Deploy application", 8);
            backlogItem.CurrentState = new TestingState();

            // Act
            backlogItem.FinishTesting(isSuccessful: true);

            // Assert
            Assert.IsType<TestedState>(backlogItem.CurrentState);
        }

        [Fact]
        public void FinishTesting_WhenTestingAndNotSuccessful_RevertsStateToTodo()
        {
            // Arrange
            var backlogItem = new BacklogItem("Fix bug", 2);
            backlogItem.CurrentState = new TestingState();

            // Act
            backlogItem.FinishTesting(isSuccessful: false);

            // Assert
            Assert.IsType<TodoState>(backlogItem.CurrentState);
        }

        [Fact]
        public void Reopen_WhenInDoneState_ChangesStateToTodo()
        {
            // Arrange
            var backlogItem = new BacklogItem("Refactor code", 1);
            backlogItem.CurrentState = new DoneState();

            // Act
            backlogItem.Reopen();

            // Assert
            Assert.IsType<TodoState>(backlogItem.CurrentState);
        }

        //Forum
        [Fact]
        public void Open_ChangesStateToOpen()
        {
            // Arrange
            var backlogItem = new BacklogItem("Task", 1);
            var forum = new Forum(backlogItem);
            forum.Close(); // Initially close the forum

            // Act
            forum.Open();

            // Assert
            Assert.IsType<OpenState>(forum.CurrentState);
        }

        [Fact]
        public void Close_ChangesStateToClosed()
        {
            // Arrange
            var backlogItem = new BacklogItem("Issue", 2);
            var forum = new Forum(backlogItem);

            // Act
            forum.Close();

            // Assert
            Assert.IsType<AvansDevOps.State.Forums.States.ClosedState>(forum.CurrentState);
        }

        //Sprint
        [Fact]
        public void StartSprint_ChangesStateToInProgress()
        {
            // Arrange
            var sprint = new Sprint("New Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            sprint.CurrentState = new CreatedState();

            // Act
            sprint.StartProgress();

            // Assert
            Assert.IsType<InProgressState>(sprint.CurrentState);
        }

        [Fact]
        public void ReviewSprint_WhenInProgress_ChangesStateToReleasing()
        {
            // Arrange
            var sprint = new Sprint("Sprint Review", DateTime.Now, DateTime.Now.AddDays(14));
            sprint.CurrentState = new FinishedState();

            // Act
            sprint.StartReleasing();

            // Assert
            Assert.IsType<ReleasingState>(sprint.CurrentState);
        }

        [Fact]
        public void CompleteSprint_WhenInReview_ChangesStateToCompleted()
        {
            // Arrange
            var sprint = new Sprint("Sprint Complete", DateTime.Now, DateTime.Now.AddDays(14));
            sprint.CurrentState = new InProgressState();

            // Act
            sprint.Finish();

            // Assert
            Assert.IsType<FinishedState>(sprint.CurrentState);
        }

        [Fact]
        public void CancelSprint_FromAnyState_ChangesStateToCancelled()
        {
            // Arrange
            var sprint = new Sprint("Sprint Cancel", DateTime.Now, DateTime.Now.AddDays(14));
            sprint.CurrentState = new InProgressState();

            // Act
            sprint.Cancel();

            // Assert
            Assert.IsType<CancelledState>(sprint.CurrentState);
        }

        //Activity
        [Fact]
        public void Constructor_InitializesIdAndTitle()
        {
            // Arrange
            int id = 1;
            string title = "Task";

            // Act
            var activity = new Activity(id, title);

            // Assert
            Assert.Equal(id, activity.Id);
            Assert.Equal(title, activity.Title);
        }

        [Fact]
        public void AssignDeveloper_SetsDeveloperSuccessfully()
        {
            // Arrange
            var activity = new Activity(1, "Task");
            var developer = new User("John Doe", null);

            // Act
            activity.AssingDeveloper(developer);

            // Assert
            Assert.Equal(developer, activity.Developer);
        }

        //Project
        [Fact]
        public void Constructor_InitializesIdNameDescriptionAndDefOfDone()
        {
            // Arrange
            int id = 1;
            string name = "Project";
            string description = "Description";
            string defOfDone = "DoD";

            // Act
            var project = new Project(id, name, description, defOfDone);

            // Assert
            Assert.Equal(id, project.Id);
            Assert.Equal(name, project.Name);
            Assert.Equal(description, project.Description);
            Assert.Equal(defOfDone, project.defOfDone);
        }

        [Fact]
        public void AddSprint_AddsSprintToList()
        {
            // Arrange
            var project = new Project(1, "Project", "Description", "DoD");
            var sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act
            project.AddSprint(sprint);

            // Assert
            Assert.Contains(sprint, project.sprints);
        }
    }

}


