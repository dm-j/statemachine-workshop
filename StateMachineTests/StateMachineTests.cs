using Microsoft.VisualStudio.TestTools.UnitTesting;
using StateMachine.WorkshopSM;

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
            door.AddState<Open>();

            Assert.IsTrue(door.DoorState is Open);
        }

        [TestMethod]
        public void DoorIsClosed()
        {
            door.AddState<Closed>();

            Assert.IsTrue(door.DoorState is Closed);
        }

        [TestMethod]
        public void OpenAClosedDoor()
        {
            door.AddState<Closed>();

            door.Open();

            Assert.IsTrue(door.DoorState is Open);
        }

        [TestMethod]
        public void CloseAnOpenDoor()
        {
            door.AddState<Open>();

            door.Close();

            Assert.IsTrue(door.DoorState is Closed);
        }

        [TestMethod]
        public void CloseAClosedDoor()
        {
            door.AddState<Closed>();

            door.Close();

            Assert.IsTrue(door.DoorState is Closed);
        }

        [TestMethod]
        public void OpenAnOpenedDoor()
        {
            door.AddState<Open>();

            door.Open();

            Assert.IsTrue(door.DoorState is Open);
        }

        // Tests without an Assert are considered to pass if they don't throw
        // an exception. For more information on the test, check the Output 
        // section in the Test Explorer.

        [TestMethod]
        public void WalkThroughOpenDoor()
        {
            door.AddState<Open>();

            door.WalkThrough();
        }

        [TestMethod]
        public void WalkThroughClosedDoor()
        {
            door.AddState<Closed>();

            door.WalkThrough();
        }

        [TestMethod]
        public void WalkThroughClosedThenOpen()
        {
            door.AddState<Closed>();

            door.WalkThrough();

            door.Open();

            door.WalkThrough();
        }

        [TestMethod]
        public void WalkThroughOpenThenClosed()
        {
            door.AddState<Open>();

            door.WalkThrough();

            door.Close();

            door.WalkThrough();
        }
    }
}
