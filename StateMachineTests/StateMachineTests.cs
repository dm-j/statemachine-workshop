using Microsoft.VisualStudio.TestTools.UnitTesting;
using StateMachine.WorkshopSM;

namespace StateMachineTests
{
    [TestClass]
    public class StateMachineTests
    {
        [TestMethod]
        public void WalkThroughOpenDoor()
        {
            Door door = new Door(1, "test").AddState<Open>() as Door;
            door.WalkThrough();
        }

        [TestMethod]
        public void WalkThroughClosedDoor()
        {
            Door door = new Door(1, "test").AddState<Closed>() as Door;
            door.WalkThrough();
        }


        [TestMethod]
        public void OpenAClosedDoor()
        {
            Door door = new Door(1, "test").AddState<Closed>() as Door;
            door.Open();

            Assert.IsTrue(door.DoorState is Open);
        }

        [TestMethod]
        public void CloseAnOpenDoor()
        {
            Door door = new Door(1, "test").AddState<Open>() as Door;
            door.Close();

            Assert.IsTrue(door.DoorState is Closed);
        }

        [TestMethod]
        public void CloseAClosedDoor()
        {
            Door door = new Door(1, "test").AddState<Closed>() as Door;
            door.Close();

            Assert.IsTrue(door.DoorState is Closed);
        }

        [TestMethod]
        public void OpenAnOpenedDoor()
        {
            Door door = new Door(1, "test").AddState<Open>() as Door;
            door.Open();

            Assert.IsTrue(door.DoorState is Open);
        }

        [TestMethod]
        public void WalkThroughClosedThenOpen()
        {
            Door door = new Door(1, "test").AddState<Closed>() as Door;

            door.WalkThrough();

            door.Open();

            door.WalkThrough();
        }
    }
}
