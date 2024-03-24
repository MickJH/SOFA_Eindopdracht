using AvansDevOps.State.BacklogItems;
using AvansDevOps.State.BacklogItems.States;
using Xunit;

namespace AvansDevOpsTest
{
    public class BacklogItemStatesTests
    {
        [Fact]
        public void TodoState_StartProgress_ChangesStateToDoing()
        {
            var item = new BacklogItem("Item in Todo", 1);
            item.StartProgress();
            Assert.IsType<DoingState>(item.CurrentState);
        }

        [Fact]
        public void DoingState_MarkAsReadyForTesting_ChangesStateToReadyForTesting()
        {
            var item = new BacklogItem("Item in Doing", 1);
            item.CurrentState = new DoingState();
            item.MarkAsReadyForTesting();
            Assert.IsType<ReadyForTestingState>(item.CurrentState);
        }

        [Fact]
        public void ReadyForTestingState_StartTesting_ChangesStateToTesting()
        {
            var item = new BacklogItem("Item Ready for Testing", 1);
            item.CurrentState = new ReadyForTestingState();
            item.StartTesting();
            Assert.IsType<TestingState>(item.CurrentState);
        }

        [Fact]
        public void TestingState_FinishTesting_Successful_ChangesStateToTested()
        {
            var item = new BacklogItem("Item in Testing", 1);
            item.CurrentState = new TestingState();
            item.FinishTesting(true);
            Assert.IsType<TestedState>(item.CurrentState);
        }

        [Fact]
        public void TestingState_FinishTesting_Unsuccessful_RevertsToTodoState()
        {
            var item = new BacklogItem("Item in Testing", 1);
            item.CurrentState = new TestingState();
            item.FinishTesting(false);
            Assert.IsType<TodoState>(item.CurrentState);
        }

        [Fact]
        public void TestedState_Complete_ChangesStateToDone()
        {
            var item = new BacklogItem("Item Tested", 1);
            item.CurrentState = new TestedState();
            item.Complete();
            Assert.IsType<DoneState>(item.CurrentState);
        }

        [Fact]
        public void DoneState_Reopen_ChangesStateToTodo()
        {
            var item = new BacklogItem("Item Done", 1);
            item.CurrentState = new DoneState();
            item.Reopen();
            Assert.IsType<TodoState>(item.CurrentState);
        }


        [Fact]
        public void TodoState_Complete_ThrowsInvalidOperationException()
        {
            var item = new BacklogItem("Item in Todo", 1);
            Assert.Throws<System.InvalidOperationException>(() => item.Complete());
        }

        [Fact]
        public void ReadyForTestingState_Complete_ThrowsInvalidOperationException()
        {
            var item = new BacklogItem("Item Ready for Testing", 1);
            item.CurrentState = new ReadyForTestingState();
            Assert.Throws<System.InvalidOperationException>(() => item.Complete());
        }

        [Fact]
        public void TestingState_MarkAsReadyForTesting_ThrowsInvalidOperationException()
        {
            var item = new BacklogItem("Item in Testing", 1);
            item.CurrentState = new TestingState();
            Assert.Throws<System.InvalidOperationException>(() => item.MarkAsReadyForTesting());
        }

        [Fact]
        public void TestedState_StartTesting_ThrowsInvalidOperationException()
        {
            var item = new BacklogItem("Item Tested", 1);
            item.CurrentState = new TestedState();
            Assert.Throws<System.InvalidOperationException>(() => item.StartTesting());
        }

        [Fact]
        public void DoneState_StartTesting_ThrowsInvalidOperationException()
        {
            var item = new BacklogItem("Item Done", 1);
            item.CurrentState = new DoneState();
            Assert.Throws<System.InvalidOperationException>(() => item.StartTesting());
        }
    }
}
