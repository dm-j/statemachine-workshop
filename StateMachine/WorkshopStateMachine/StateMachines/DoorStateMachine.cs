using Dots.Standard.StateMachine.State;
using System.Linq;

namespace StateMachine.WorkshopSM
{
    // Your state machines go here

    // A Door contains one state, which is DoorState, and you can try to 
    // Walk Through the door.

    public class Door : RootStateMachine<int>
    {
        public Door(int ID, string user) 
            : base(new DummySaver(), user)
        {
            this.ID = ID;
        }

        public DoorState DoorState => 
            State<DoorState>().Single();

        public void Open() =>
            Broadcast(Event.Open);

        public void Close() =>
            Broadcast(Event.Close);

        public void WalkThrough() =>
            DoorState.WalkThrough();
    }
}
