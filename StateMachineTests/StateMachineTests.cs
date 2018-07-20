using Microsoft.VisualStudio.TestTools.UnitTesting;
using SM.WorkshopSM;

namespace StateMachineTests
{
    [TestClass]
    public class StateMachineTests
    {
        private readonly ConsoleOutputSaver save = new ConsoleOutputSaver();
        private Door door;

        /// <summary>
        /// This method runs before every single test. It creates a new Door state machine
        /// and assigns it to the test class's private door property. This ensures we're 
        /// using a fresh state machine every time.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            door = new Door(1, save, "test");
        }

        // These tests set up the Door and run it through some common scenarios to verify
        // its behavior. Having these tests means we can tell straight away if the state
        // machine's behavior changes in unexpected ways after we've made alterations.

        [TestMethod]
        public void DoorIsOpen()
        {
            door.AddState<Open>()
                .AddStateMachine(new DoorLock(2).AddState<Unlocked>());

            Assert.IsTrue(door.Position is Open);
        }

        [TestMethod]
        public void DoorIsClosed()
        {
            door.AddState<Closed>()
                .AddStateMachine(new DoorLock(2).AddState<Unlocked>());

            Assert.IsTrue(door.Position is Closed);
        }

        [TestMethod]
        public void OpenAClosedDoor()
        {
            door.AddState<Closed>()
                .AddStateMachine(new DoorLock(2).AddState<Unlocked>());

            door.Open();

            Assert.IsTrue(door.Position is Open);
        }

        [TestMethod]
        public void OpenALockedDoor()
        {
            door.AddState<Closed>()
                .AddStateMachine(new DoorLock(2).AddState<Locked>());

            door.Open();

            Assert.IsTrue(door.Position is Closed);
        }

        [TestMethod]
        public void CloseAnOpenDoor()
        {
            door.AddState<Open>()
                .AddStateMachine(new DoorLock(2).AddState<Unlocked>());

            door.Close();

            Assert.IsTrue(door.Position is Closed);
        }

        [TestMethod]
        public void CloseALockedOpenDoor()
        {
            door.AddState<Open>()
                .AddStateMachine(new DoorLock(2).AddState<Locked>());

            door.Close();

            Assert.IsTrue(door.Position is Closed);
        }

        [TestMethod]
        public void CloseAClosedDoor()
        {
            door.AddState<Closed>()
                .AddStateMachine(new DoorLock(2).AddState<Unlocked>());

            door.Close();

            Assert.IsTrue(door.Position is Closed);
        }

        [TestMethod]
        public void CloseAClosedLockedDoor()
        {
            door.AddState<Closed>()
                .AddStateMachine(new DoorLock(2).AddState<Locked>());

            door.Close();

            Assert.IsTrue(door.Position is Closed);
        }

        [TestMethod]
        public void OpenAnOpenedDoor()
        {
            door.AddState<Open>()
                .AddStateMachine(new DoorLock(2).AddState<Unlocked>());

            door.Open();

            Assert.IsTrue(door.Position is Open);
        }

        // Tests without an Assert are considered to pass if they don't throw
        // an exception. For more information on the test, check the Output 
        // section in the Test Explorer.

        [TestMethod]
        public void WalkThroughOpenDoor()
        {
            door.AddState<Open>()
                .AddStateMachine(new DoorLock(2).AddState<Unlocked>());

            door.WalkThrough();
        }

        [TestMethod]
        public void WalkThroughClosedDoor()
        {
            door.AddState<Closed>()
                .AddStateMachine(new DoorLock(2).AddState<Unlocked>());

            door.WalkThrough();
        }

        [TestMethod]
        public void WalkThroughClosedThenOpen()
        {
            door.AddState<Closed>()
                .AddStateMachine(new DoorLock(2).AddState<Unlocked>());

            door.WalkThrough();

            door.Open();

            door.WalkThrough();
        }

        [TestMethod]
        public void WalkThroughOpenThenClosed()
        {
            door.AddState<Open>()
                .AddStateMachine(new DoorLock(2).AddState<Unlocked>());

            door.WalkThrough();

            door.Close();

            door.WalkThrough();
        }
    }
}
