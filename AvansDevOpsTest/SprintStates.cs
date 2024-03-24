using AvansDevOps.State.Sprints;
using AvansDevOps.State.Sprints.States;
using Xunit;
using System;

namespace AvansDevOpsTest
{
    public class SprintStates
    {
        [Fact]
        public void FinishTransition_ChangesStateToFinishedInProgress()
        {
            //Arrange
            var _state = new InProgressState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act 
            _state.Finish(sprint);
            //Assert
            Assert.IsType<FinishedState>(sprint.CurrentState);
        }

        [Fact]
        public void CancelTransition_ChangesStateToCancelledInProgress()
        {
            //Arrange
            var _state = new InProgressState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act
            _state.Cancel(sprint);
            //Assert
            Assert.IsType<CancelledState>(sprint.CurrentState);
        }

        [Fact]
        public void StartProgress_ThrowsInvalidOperationExceptionInProgress()
        {
            //Arrange
            var _state = new InProgressState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _state.StartProgress(sprint));
        }

        [Fact]
        public void StartReleasing_ThrowsInvalidOperationExceptionInProgress()
        {
            //Arrange
            var _state = new InProgressState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _state.StartReleasing(sprint));
        }

        [Fact]
        public void FinishRelease_ThrowsInvalidOperationExceptionInProgress()
        {
            //Arrange
            var _state = new InProgressState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _state.FinishRelease(sprint));
        }

        [Fact]
        public void Close_ThrowsInvalidOperationExceptionInProgress()
        {
            //Arrange
            var _state = new InProgressState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _state.Close(sprint));
        }

        [Fact]
        public void StartProgress_ThrowsInvalidOperationExceptionCancelledState()
        {
            //Arrange
            var _state = new CancelledState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _state.StartProgress(sprint));
        }

        [Fact]
        public void Finish_ThrowsInvalidOperationExceptionCancelledState()
        {
            //Arrange
            var _state = new CancelledState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _state.Finish(sprint));
        }

        [Fact]
        public void StartReleasing_ThrowsInvalidOperationExceptionCancelledState()
        {
            //Arrange
            var _state = new CancelledState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _state.StartReleasing(sprint));
        }

        [Fact]
        public void FinishRelease_ThrowsInvalidOperationExceptionCancelledState()
        {
            //Arrange
            var _state = new CancelledState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _state.FinishRelease(sprint));
        }

        [Fact]
        public void Close_ThrowsInvalidOperationExceptionCancelledState()
        {
            //Arrange
            var _state = new CancelledState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _state.Close(sprint));
        }

        [Fact]
        public void Cancel_ThrowsInvalidOperationExceptionCancelledState()
        {
            //Arrange
            var _state = new CancelledState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => _state.Cancel(sprint));
        }

        [Fact]
        public void StartProgress_ThrowsInvalidOperationExceptionClosedState()
        {
            var state = new ClosedState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.StartProgress(sprint));
        }

        [Fact]
        public void Finish_ThrowsInvalidOperationExceptionClosedState()
        {
            var state = new ClosedState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.Finish(sprint));
        }

        [Fact]
        public void StartReleasing_ThrowsInvalidOperationExceptionClosedState()
        {
            var state = new ClosedState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.StartReleasing(sprint));
        }

        [Fact]
        public void FinishRelease_ThrowsInvalidOperationExceptionClosedState()
        {
            var state = new ClosedState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.FinishRelease(sprint));
        }

        [Fact]
        public void Close_ThrowsInvalidOperationExceptionClosedState()
        {
            var state = new ClosedState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.Close(sprint));
        }

        [Fact]
        public void Cancel_ThrowsInvalidOperationExceptionClosedState()
        {
            var state = new ClosedState();
            Sprint sprint = new Sprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.Cancel(sprint));
        }

        [Fact]
        public void StartProgress_ChangesStateToInProgressCreatedState()
        {
            // Arrange
            var state = new CreatedState();
            Sprint sprint = new Sprint("New Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act
            state.StartProgress(sprint);

            // Assert
            Assert.IsType<InProgressState>(sprint.CurrentState);
        }

        [Fact]
        public void Cancel_ChangesStateToCancelledCreatedState()
        {
            // Arrange
            var state = new CreatedState();
            Sprint sprint = new Sprint("New Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act
            state.Cancel(sprint);

            // Assert
            Assert.IsType<CancelledState>(sprint.CurrentState);
        }

        [Fact]
        public void Finish_ThrowsInvalidOperationExceptionCreatedState()
        {
            // Arrange
            var state = new CreatedState();
            Sprint sprint = new Sprint("New Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => state.Finish(sprint));
        }

        [Fact]
        public void StartReleasing_ThrowsInvalidOperationExceptionCreatedState()
        {
            // Arrange
            var state = new CreatedState();
            Sprint sprint = new Sprint("New Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => state.StartReleasing(sprint));
        }

        [Fact]
        public void FinishRelease_ThrowsInvalidOperationExceptionCreatedState()
        {
            // Arrange
            var state = new CreatedState();
            Sprint sprint = new Sprint("New Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => state.FinishRelease(sprint));
        }

        [Fact]
        public void Close_ThrowsInvalidOperationExceptionCreatedState()
        {
            // Arrange
            var state = new CreatedState();
            Sprint sprint = new Sprint("New Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => state.Close(sprint));
        }

        [Fact]
        public void StartReleasing_ChangesStateToReleasingFinishedState()
        {
            // Arrange
            var state = new FinishedState();
            Sprint sprint = new Sprint("Finished Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act
            state.StartReleasing(sprint);

            // Assert
            Assert.IsType<ReleasingState>(sprint.CurrentState);
        }

        [Fact]
        public void Cancel_ChangesStateToCancelledFinishedState()
        {
            // Arrange
            var state = new FinishedState();
            Sprint sprint = new Sprint("Finished Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act
            state.Cancel(sprint);

            // Assert
            Assert.IsType<CancelledState>(sprint.CurrentState);
        }

        [Fact]
        public void StartProgress_ThrowsInvalidOperationExceptionFinishedState()
        {
            // Arrange
            var state = new FinishedState();
            Sprint sprint = new Sprint("Finished Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => state.StartProgress(sprint));
        }

        [Fact]
        public void Finish_ThrowsInvalidOperationExceptionFinishedState()
        {
            // Arrange
            var state = new FinishedState();
            Sprint sprint = new Sprint("Finished Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => state.Finish(sprint));
        }

        [Fact]
        public void FinishRelease_ThrowsInvalidOperationExceptionFinishedState()
        {
            // Arrange
            var state = new FinishedState();
            Sprint sprint = new Sprint("Finished Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => state.FinishRelease(sprint));
        }

        [Fact]
        public void Close_ThrowsInvalidOperationExceptionFinishedState()
        {
            // Arrange
            var state = new FinishedState();
            Sprint sprint = new Sprint("Finished Sprint", DateTime.Now, DateTime.Now.AddDays(14));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => state.Close(sprint));
        }

        [Fact]
        public void StartProgress_ThrowsInvalidOperationExceptionReleasedState()
        {
            var state = new ReleasedState();
            Sprint sprint = new Sprint("Released Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.StartProgress(sprint));
        }

        [Fact]
        public void Finish_ThrowsInvalidOperationExceptionReleasedState()
        {
            var state = new ReleasedState();
            Sprint sprint = new Sprint("Released Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.Finish(sprint));
        }

        [Fact]
        public void StartReleasing_ThrowsInvalidOperationExceptionReleasedState()
        {
            var state = new ReleasedState();
            Sprint sprint = new Sprint("Released Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.StartReleasing(sprint));
        }

        [Fact]
        public void FinishRelease_ThrowsInvalidOperationExceptionReleasedState()
        {
            var state = new ReleasedState();
            Sprint sprint = new Sprint("Released Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.FinishRelease(sprint));
        }

        [Fact]
        public void Close_ChangesStateToClosedReleasedState()
        {
            var state = new ReleasedState();
            Sprint sprint = new Sprint("Released Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            state.Close(sprint);
            Assert.IsType<ClosedState>(sprint.CurrentState);
        }

        [Fact]
        public void Cancel_ThrowsInvalidOperationExceptionReleasedState()
        {
            var state = new ReleasedState();
            Sprint sprint = new Sprint("Released Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.Cancel(sprint));
        }

        [Fact]
        public void StartProgress_ThrowsInvalidOperationExceptionReleasingState()
        {
            var state = new ReleasingState();
            Sprint sprint = new Sprint("Releasing Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.StartProgress(sprint));
        }

        [Fact]
        public void Finish_ThrowsInvalidOperationExceptionReleasingState()
        {
            var state = new ReleasingState();
            Sprint sprint = new Sprint("Releasing Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.Finish(sprint));
        }

        [Fact]
        public void StartReleasing_ThrowsInvalidOperationExceptionReleasingState()
        {
            var state = new ReleasingState();
            Sprint sprint = new Sprint("Releasing Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.StartReleasing(sprint));
        }

        [Fact]
        public void FinishRelease_ChangesStateToReleasedReleasingState()
        {
            var state = new ReleasingState();
            Sprint sprint = new Sprint("Releasing Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            state.FinishRelease(sprint);
            Assert.IsType<ReleasedState>(sprint.CurrentState);
        }

        [Fact]
        public void Close_ThrowsInvalidOperationExceptionReleasingState()
        {
            var state = new ReleasingState();
            Sprint sprint = new Sprint("Releasing Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            Assert.Throws<InvalidOperationException>(() => state.Close(sprint));
        }

        [Fact]
        public void Cancel_ChangesStateToCancelledReleasingState()
        {
            var state = new ReleasingState();
            Sprint sprint = new Sprint("Releasing Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            state.Cancel(sprint);
            Assert.IsType<CancelledState>(sprint.CurrentState);
        }
    }
}

